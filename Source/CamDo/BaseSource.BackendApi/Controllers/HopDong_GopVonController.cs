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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
     [Route("api/HopDongGopVon")]
    public class HopDong_GopVonController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHopDongService _hopDongService;
        private readonly ICuaHang_TransactionLogService _cuaHang_TransactionLogService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IConfiguration _configuration;
        private string baseAddressUploadApi = "";


        public HopDong_GopVonController(BaseSourceDbContext db, IMapper mapper,
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
        public async Task<IActionResult> CreateGopVon(CreateHopDongGopVonVm model)
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
            hd.TenTaiSan = "Góp vốn";
            //set  type HD
            hd.HD_Loai = ELoaiHopDong.GopVon;
            hd.HD_HinhThucLai = model.HD_HinhThucLai;
            hd.HD_Status = (byte)EHopDong_GopVonStatusFilter.DungHen;

            hd.HD_NgayDaoHan = await _hopDongService.TinhNgayDaoHan(hd.HD_HinhThucLai, hd.HD_NgayVay, hd.HD_TongThoiGianVay, hd.HD_KyLai);
            hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
            _db.HopDongs.Add(hd);
            await _db.SaveChangesAsync();

            //add log
            await CreateCuaHang_TransactionLog(new CreateCuaHang_TransactionLogVm
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.TaoMoiHD,
                FeatureType = EFeatureType.GopVon,
                UserId = UserId,
                TotalMoneyLoan = hd.TongTienVayHienTai
            });
            var rs = Task.Run(() => TaoKyDongLai(hd.Id));
            return Ok(new ApiSuccessResult<string>("Tạo mới hợp đồng góp vốn thành công"));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> EditGopVon(EditHopDongGopVonVm model)
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
            model.UserIdAssigned = UserId;

            _mapper.Map(model, hd);

            hd.TongTienVayHienTai = model.HD_TongTienVayBanDau;
            hd.HD_NgayDaoHan = await _hopDongService.TinhNgayDaoHan(hd.HD_HinhThucLai, hd.HD_NgayVay, hd.HD_TongThoiGianVay, hd.HD_KyLai);
            hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
            await _db.SaveChangesAsync();

            if (isChangeKyLai)
            {
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));
            }
            //add log
            await CreateCuaHang_TransactionLog(new CreateCuaHang_TransactionLogVm
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.UpdateHD,
                FeatureType = EFeatureType.GopVon,
                UserId = UserId,
                TotalMoneyLoan = hd.TongTienVayHienTai
            });
            return Ok(new ApiSuccessResult<string>("Cập nhật hợp đồng góp vốn thành công"));

        }

        #region helper
        private string GetTrangThaiHopDong(ELoaiHopDong type, byte status)
        {
            string statusName = "";
            switch (type)
            {
                case ELoaiHopDong.Camdo:
                    statusName = ((EHopDong_CamDoStatusFilter)status).GetEnumDisplayName();
                    break;
                case ELoaiHopDong.Vaylai:
                    statusName = ((EHopDong_VayLaiStatusFilter)status).GetEnumDisplayName();
                    break;
                case ELoaiHopDong.GopVon:
                    statusName = ((EHopDong_GopVonStatusFilter)status).GetEnumDisplayName();
                    break;
                default:
                    break;
            }
            return statusName;
        }
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
