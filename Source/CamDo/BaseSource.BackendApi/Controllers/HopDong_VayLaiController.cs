using AutoMapper;
using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.Utilities.Extensions;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class HopDong_VayLaiController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHopDongService _hopDongService;
        private readonly ICuaHang_TransactionLogService _cuaHang_TransactionLogService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IConfiguration _configuration;
        private string baseAddressUploadApi = "";


        public HopDong_VayLaiController(BaseSourceDbContext db, IMapper mapper,
            IServiceScopeFactory serviceScopeFactory, IHopDongService hopDongService,
            ICuaHang_TransactionLogService cuaHang_TransactionLogService,
            IWebHostEnvironment appEnvironment, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _serviceScopeFactory = serviceScopeFactory;
            _hopDongService = hopDongService;
            _cuaHang_TransactionLogService = cuaHang_TransactionLogService;
            _appEnvironment = appEnvironment;
            _configuration = configuration;
            baseAddressUploadApi = _configuration["BaseAddressUploadApi"];
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateHopDongVayLaiVm model)
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

            int khachHangId = await _hopDongService.AddOrUpDateCustomer(kh);

            var hd = _mapper.Map<HopDong>(model);
            hd.TongTienVayHienTai = hd.HD_TongTienVayBanDau;
            hd.KhachHangId = khachHangId;
            hd.CuaHangId = CuaHangId;
            hd.UserIdCreated = UserId;
            hd.UserIdAssigned = UserId;
            hd.TongTienVayHienTai = hd.HD_TongTienVayBanDau;
            hd.HD_Status = (byte)EHopDong_VayLaiStatusFilter.DangVay;

            hd.HD_NgayDaoHan = await _hopDongService.TinhNgayDaoHan(hd.HD_HinhThucLai, hd.HD_NgayVay, hd.HD_TongThoiGianVay, hd.HD_KyLai);
            hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
            _db.HopDongs.Add(hd);
            await _db.SaveChangesAsync();

            var rs = Task.Run(() => TaoKyDongLai(hd.Id));
            return Ok(new ApiSuccessResult<string>("Tạo mới hợp đồng thành công"));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditHopDongVayLaiVm model)
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
            int khachHangId = await _hopDongService.AddOrUpDateCustomer(kh);
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
