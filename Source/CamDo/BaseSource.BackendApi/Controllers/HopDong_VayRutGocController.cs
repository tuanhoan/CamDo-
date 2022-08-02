using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HopDong_VayRutGoc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class HopDong_VayRutGocController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly IHopDongService _hopDongService;
        private readonly ICuaHang_TransactionLogService _cuaHang_TransactionLogService;
        public HopDong_VayRutGocController(BaseSourceDbContext db, IHopDongService hopDongService,
            ICuaHang_TransactionLogService cuaHang_TransactionLogService)
        {
            _db = db;
            _hopDongService = hopDongService;
            _cuaHang_TransactionLogService = cuaHang_TransactionLogService;
        }
        [HttpGet("GetByHopDong")]
        public async Task<IActionResult> GetByHopDong(int hopDongId)
        {
            var result = await _db.HopDong_VayRutGocs.Where(x => x.HopDongId == hopDongId)
                   .Select(x => new HopDong_VayRutGocVm()
                   {
                       Id = x.Id,
                       TotalMoney = x.TotalMoney,
                       ExtraDate = x.ExtraDate,
                       Note = x.Note,
                       ActionType = x.ActionType
                   }).ToListAsync();

            return Ok(new ApiSuccessResult<List<HopDong_VayRutGocVm>>(result));
        }
        #region Trả bớt gốc
        [HttpPost("TraBotGoc")]
        public async Task<IActionResult> TraBotGoc(TraBotGocRequestVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd != null)
            {
                if (hd.NgayDongLaiGanNhat != null)
                {
                    if (model.NgayTraGoc < hd.NgayDongLaiGanNhat)
                    {
                        return Ok(new ApiErrorResult<string>($"Ngày [Trả gốc] phải >= ngày đóng lãi cuối cùng là ngày: {hd.NgayDongLaiGanNhat.Value.ToString("dd/MM/yyyy")}"));
                    }
                }
                if (model.SoTienTraGoc > hd.TongTienVayHienTai)
                {
                    return Ok(new ApiErrorResult<string>($"Tiền [Trả gốc] phải <= tiền đang có của hợp đồng"));
                }
                hd.TongTienDaThanhToan += model.SoTienTraGoc ?? 0;
                hd.TongTienVayHienTai -= model.SoTienTraGoc ?? 0;
                hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
                await _db.SaveChangesAsync();
                var hd_vayRutGoc = new HopDong_VayRutGoc()
                {
                    HopDongId = hd.Id,
                    TotalMoney = model.SoTienTraGoc.Value,
                    ExtraDate = model.NgayTraGoc,
                    UserId = UserId,
                    CreatedDate = DateTime.Now,
                    Note = model.Note,
                    ActionType = EHopDong_ActionType.TraGoc
                };
                _db.HopDong_VayRutGocs.Add(hd_vayRutGoc);
                await _db.SaveChangesAsync();
                var tranLog = new CreateCuaHang_TransactionLogVm()
                {
                    HopDongId = hd.Id,
                    ActionType = EHopDong_ActionType.TraGoc,
                    FeatureType = EFeatureType.Camdo,
                    UserId = UserId,
                    Note = model.Note,
                    SoTienTraGoc = model.SoTienTraGoc,
                    NgayTraGoc = model.NgayTraGoc
                };
                var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));

                return Ok(new ApiSuccessResult<double>(hd.TongTienVayHienTai, "Trả bớt gốc thành công"));
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
        [HttpPost("XoaTraBotGoc")]
        public async Task<IActionResult> XoaTraBotGoc([FromForm] int tranLogId)
        {
            var tran = await _db.HopDong_VayRutGocs.FindAsync(tranLogId);
            if (tran != null)
            {
                var hd = await _db.HopDongs.FindAsync(tran.HopDongId);

                if (hd.NgayDongLaiGanNhat != null)
                {
                    if (hd.NgayDongLaiGanNhat > tran.CreatedDate)
                    {
                        return Ok(new ApiErrorResult<string>("Không thể hủy giao dịch vì ngày đóng lãi cuối cùng lớn hơn giao dịch này"));
                    }
                }

                hd.TongTienDaThanhToan -= tran.TotalMoney;
                hd.TongTienVayHienTai += tran.TotalMoney;
                hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
                _db.HopDong_VayRutGocs.Remove(tran);
                await _db.SaveChangesAsync();

                var tranLog = new CreateCuaHang_TransactionLogVm()
                {
                    HopDongId = hd.Id,
                    ActionType = EHopDong_ActionType.HuyTraGoc,
                    FeatureType = EFeatureType.Camdo,
                    UserId = UserId,
                    SoTienTraGoc = tran.TotalMoney

                };
                var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));

                return Ok(new ApiSuccessResult<double>(hd.TongTienVayHienTai, "Hủy trả bớt gốc thành công"));
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
        #endregion

        #region Vay Thêm
        [HttpPost("VayThem")]
        public async Task<IActionResult> VayThem(VayThemRequestVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd != null)
            {

                if (model.NgayVayThem < hd.HD_NgayVay)
                {
                    return Ok(new ApiErrorResult<string>("Ngày xử lý phải lớn hơn ngày vay của hợp đồng"));
                }

                hd.TongTienVayHienTai += model.SoTienVayThem.Value;
                hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
                await _db.SaveChangesAsync();
                var hd_vayRutGoc = new HopDong_VayRutGoc()
                {
                    HopDongId = hd.Id,
                    TotalMoney = model.SoTienVayThem ?? 0,
                    ExtraDate = model.NgayVayThem,
                    UserId = UserId,
                    CreatedDate = DateTime.Now,
                    Note = model.Note,
                    ActionType = EHopDong_ActionType.VayThemGoc
                };
                _db.HopDong_VayRutGocs.Add(hd_vayRutGoc);
                await _db.SaveChangesAsync();
                var tranLog = new CreateCuaHang_TransactionLogVm()
                {
                    HopDongId = hd.Id,
                    ActionType = EHopDong_ActionType.VayThemGoc,
                    FeatureType = EFeatureType.Camdo,
                    UserId = UserId,
                    TienVayThem = model.SoTienVayThem,
                    NgayVayThem = model.NgayVayThem
                };
                var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));

                return Ok(new ApiSuccessResult<double>(hd.TongTienVayHienTai, "Vay thêm gốc thành công"));
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
        #endregion

        #region helper

        private async Task TaoKyDongLai(int hopdongId)
        {
            await _hopDongService.TaoKyDongLai(hopdongId);
        }
        private async Task CreateCuaHang_TransactionLog(CreateCuaHang_TransactionLogVm model)
        {
            await _cuaHang_TransactionLogService.CreateTransactionLog(model);
        }
        #endregion
    }
}
