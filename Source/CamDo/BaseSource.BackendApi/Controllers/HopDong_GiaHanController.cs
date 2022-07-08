using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HopDong;
using BaseSource.ViewModels.HopDong_GianHan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class HopDong_GiaHanController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly IHopDongService _hopDongService;
        private readonly ICuaHang_TransactionLogService _cuaHang_TransactionLogService;
        public HopDong_GiaHanController(BaseSourceDbContext db, IHopDongService hopDongService,
            ICuaHang_TransactionLogService cuaHang_TransactionLogService)
        {
            _db = db;
            _hopDongService = hopDongService;
            _cuaHang_TransactionLogService = cuaHang_TransactionLogService;
        }
        [HttpGet("GetByHopDong")]
        public async Task<IActionResult> GetByHopDong(int hopDongId)
        {
            var result = await _db.HopDong_GiaHans.Where(x => x.HopDongId == hopDongId)
                   .Select(x => new HopDong_GiaHanVm()
                   {
                       Id = x.Id,
                       CountDate = x.CountDate,
                       OldDate = x.OldDate,
                       NewDate = x.NewDate,
                       Note = x.Note,
                   }).ToListAsync();

            return Ok(new ApiSuccessResult<List<HopDong_GiaHanVm>>(result));
        }
        #region Gia hạn
        [HttpPost("GiaHan")]
        public async Task<IActionResult> GiaHan(GiaHanRequestVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd != null)
            {
                var ngayDaoHanOld = hd.HD_NgayDaoHan;
                hd.HD_TongThoiGianVay += model.SoNgayGiaHan ?? 0;
                hd.HD_NgayDaoHan = await _hopDongService.TinhNgayDaoHan(hd.HD_HinhThucLai, hd.HD_NgayVay, hd.HD_TongThoiGianVay, hd.HD_KyLai);
                hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
                await _db.SaveChangesAsync();
                var hd_Giahan = new HopDong_GiaHan()
                {
                    HopDongId = hd.Id,
                    OldDate = ngayDaoHanOld,
                    NewDate = hd.HD_NgayDaoHan,
                    CountDate = (hd.HD_NgayDaoHan - ngayDaoHanOld).Days + 1,
                    CreatedDate = DateTime.Now,
                    Note = model.Note,
                    UserId = UserId
                };
                _db.HopDong_GiaHans.Add(hd_Giahan);
                await _db.SaveChangesAsync();

                var tranLog = new CreateCuaHang_TransactionLogVm()
                {
                    HopDongId = hd.Id,
                    ActionType = EHopDong_ActionType.GiaHan,
                    FeatureType = EFeatureType.Camdo,
                    UserId = UserId,
                    FromDate = ngayDaoHanOld,
                    ToDate = hd.HD_NgayDaoHan
                };
                var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));

                return Ok(new ApiSuccessResult<string>(hd.HD_NgayDaoHan.ToString("dd/MM/yyyy"), "Gia hạn thành công"));
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
