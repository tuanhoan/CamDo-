﻿using AutoMapper;
using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Controllers
{
    public class HopDongController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHopDongService _hopDongService;
        private readonly ICuaHang_TransactionLogService _cuaHang_TransactionLogService;
        public HopDongController(BaseSourceDbContext db, IMapper mapper,
            IServiceScopeFactory serviceScopeFactory, IHopDongService hopDongService,
            ICuaHang_TransactionLogService cuaHang_TransactionLogService)
        {
            _db = db;
            _mapper = mapper;
            _serviceScopeFactory = serviceScopeFactory;
            _hopDongService = hopDongService;
            _cuaHang_TransactionLogService = cuaHang_TransactionLogService;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetHopDongPagingRequest request)
        {
            var model = _db.HopDongs.AsQueryable();
            model = model.Where(x => x.CuaHangId == CuaHangId && x.HD_Loai == request.LoaiHopDong);

            var data = await (from hd in model
                              join kh in _db.KhachHangs on hd.KhachHangId equals kh.Id
                              join hh in _db.CauHinhHangHoas on hd.HangHoaId equals hh.Id
                              join htl in _db.MoTaHinhThucLais on hd.HD_HinhThucLai equals htl.HinhThucLai
                              select new HopDongVm()
                              {
                                  Id = hd.Id,
                                  HD_Ma = hd.HD_Ma,
                                  HD_LaiSuat = hd.HD_LaiSuat,
                                  HD_NgayVay = hd.HD_NgayVay,
                                  HD_TongThoiGianVay = hd.HD_TongThoiGianVay,
                                  HD_TongTienVayBanDau = hd.HD_TongTienVayBanDau,
                                  HD_HinhThucLai = hd.HD_HinhThucLai,
                                  HD_KyLai = hd.HD_KyLai,
                                  TongTienLaiDaThanhToan = hd.TongTienLaiDaThanhToan,
                                  MaTaiSan = hh.MaTS,
                                  TenKhachHang = kh.Ten,
                                  SDT = kh.SDT,
                                  TenTaiSan = hd.TenTaiSan,
                                  TienNo = 0,
                                  TongTienDaThanhToan = hd.TongTienDaThanhToan,
                                  TyLeLai = hd.HD_LaiSuat + htl.TyLeLai,
                                  ThoiGian = htl.ThoiGian

                              }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            foreach (var item in data)
            {
                item.TongSoNgayVay = await _hopDongService.TinhTongSoNgayVay(item.HD_HinhThucLai, item.HD_KyLai, item.HD_TongThoiGianVay);

            }

            var pagedResult = new PagedResult<HopDongVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<HopDongVm>>(pagedResult));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateHopDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var kh = new KhachHang()
            {
                Id = model.KhachHangId,
                Ten = model.TenKhachHang,
                CMND = model.CMND,
                SDT = model.SDT,
                DiaChi = model.DiaChi,
                CuaHangId = CuaHangId
            };

            int khachHangId = await AddOrUpDateCustomer(kh);

            var hd = _mapper.Map<HopDong>(model);
            hd.TongTienVayHienTai = hd.HD_TongTienVayBanDau;
            hd.KhachHangId = khachHangId;
            hd.CuaHangId = CuaHangId;
            hd.UserIdCreated = UserId;
            hd.UserIdAssigned = UserId;
            hd.TongTienVayHienTai = hd.HD_TongTienVayBanDau;
            //gán tạm
            hd.HD_Loai = ELoaiHopDong.Camdo;
            hd.HD_NgayDaoHan = await _hopDongService.TinhNgayDaoHan(hd.HD_HinhThucLai, hd.HD_NgayVay, hd.HD_TongThoiGianVay, hd.HD_KyLai);
            hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
            _db.HopDongs.Add(hd);
            await _db.SaveChangesAsync();

            var rs = Task.Run(() => TaoKyDongLai(hd.Id));
            return Ok(new ApiSuccessResult<string>("Tạo mới hợp đồng thành công"));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var hd = await _db.HopDongs.FindAsync(id);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var htl = await _db.MoTaHinhThucLais.FirstOrDefaultAsync(x => x.HinhThucLai == hd.HD_HinhThucLai);
            var result = _mapper.Map<HopDongVm>(hd);
            var kh = await _db.KhachHangs.FindAsync(hd.KhachHangId);
            result.TenKhachHang = kh.Ten;
            result.SDT = kh.SDT;
            result.DiaChi = kh.DiaChi;
            result.CMND = kh.CMND;
            result.CMND_NgayCap = kh.CMND_NgayCap;
            result.CMND_NoiCap = kh.CMND_NoiCap;
            result.TyLeLai = hd.HD_LaiSuat + htl.TyLeLai;


            return Ok(new ApiSuccessResult<HopDongVm>(result));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditHopDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var hd = await _db.HopDongs.FindAsync(model.Id);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            bool isChangeKyLai = false;
            if (hd.HD_HinhThucLai != model.HD_HinhThucLai || hd.HD_KyLai != model.HD_KyLai || hd.HD_LaiSuat != model.HD_LaiSuat)
            {
                isChangeKyLai = true;
            }

            var kh = new KhachHang()
            {
                Id = hd.KhachHangId,
                Ten = model.TenKhachHang,
                CMND = model.CMND,
                SDT = model.SDT,
                DiaChi = model.DiaChi,
                CuaHangId = CuaHangId
            };
            await AddOrUpDateCustomer(kh);
            model.KhachHangId = kh.Id;
            _mapper.Map(model, hd);
            hd.HD_NgayDaoHan = await _hopDongService.TinhNgayDaoHan(hd.HD_HinhThucLai, hd.HD_NgayVay, hd.HD_TongThoiGianVay, hd.HD_KyLai);
            hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
            await _db.SaveChangesAsync();

            if (isChangeKyLai)
            {
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));
            }

            return Ok(new ApiSuccessResult<string>("Cập nhật hợp đồng thành công"));
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
        public async Task<IActionResult> XoaTraBotGoc([FromForm] long tranLogId)
        {
            var tran = await _db.CuaHang_TransactionLogs.FindAsync(tranLogId);
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

                hd.TongTienDaThanhToan -= tran.MoneyPay;
                hd.TongTienVayHienTai += tran.MoneyPay;
                hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
                _db.CuaHang_TransactionLogs.Remove(tran);
                await _db.SaveChangesAsync();

                var tranLog = new CreateCuaHang_TransactionLogVm()
                {
                    HopDongId = hd.Id,
                    ActionType = EHopDong_ActionType.HuyTraGoc,
                    FeatureType = EFeatureType.Camdo,
                    UserId = UserId,
                    SoTienTraGoc = tran.MoneyPay

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

        private async Task<int> AddOrUpDateCustomer(KhachHang model)
        {
            int khachHangId = 0;
            var khachHang = await _db.KhachHangs.FindAsync(model.Id);
            if (khachHang == null)
            {
                _db.KhachHangs.Add(model);
                await _db.SaveChangesAsync();
                khachHangId = model.Id;
            }
            else
            {
                khachHang.Ten = model.Ten;
                khachHang.CMND = model.CMND;
                khachHang.SDT = model.SDT;
                khachHang.DiaChi = model.DiaChi;
                await _db.SaveChangesAsync();
                khachHangId = khachHang.Id;
            }

            return khachHangId;
        }
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
