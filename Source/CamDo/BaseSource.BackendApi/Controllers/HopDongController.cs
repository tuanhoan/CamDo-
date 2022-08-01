using AutoMapper;
using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IConfiguration _configuration;
        private string baseAddressUploadApi = "";


        public HopDongController(BaseSourceDbContext db, IMapper mapper,
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
        #region Hợp đồng
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
            result.ThoiGian = htl.ThoiGian;


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
        #endregion


        #region Ghi nợ - trả nợ
        [HttpPost("NoLai")]
        public async Task<IActionResult> NoLai(HopDongNoLaiVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            if (model.SoTienNoLai > hd.TongTienDaThanhToan)
            {
                return Ok(new ApiErrorResult<string>("Tiền nợ phải nhỏ hơn hoặc bằng số tiền đã thanh toán"));
            }

            else
            {
                hd.TongTienGhiNo += model.SoTienNoLai ?? 0;
                await _db.SaveChangesAsync();

                var tranLog = new CreateCuaHang_TransactionLogVm()
                {
                    HopDongId = hd.Id,
                    ActionType = EHopDong_ActionType.NoLai,
                    FeatureType = EFeatureType.Camdo,
                    UserId = UserId,
                    TienGhiNo = model.SoTienNoLai ?? 0

                };
                var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
            }
            var moneyResult = hd.TongTienDaThanhToan - hd.TongTienGhiNo;
            return Ok(new ApiSuccessResult<double>(moneyResult, "Nợ lại thành công"));
        }
        [HttpPost("TraNo")]
        public async Task<IActionResult> TraNo(HopDongTraNoVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            hd.TongTienDaThanhToan += model.SoTienTraNo ?? 0;
            await _db.SaveChangesAsync();

            var tranLog = new CreateCuaHang_TransactionLogVm()
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.TraNo,
                FeatureType = EFeatureType.Camdo,
                UserId = UserId,
                TienTraNo = model.SoTienTraNo ?? 0
            };
            var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
            var moneyResult = hd.TongTienDaThanhToan - hd.TongTienGhiNo;
            return Ok(new ApiSuccessResult<double>(moneyResult, "Trả nợ thành công"));
        }
        #endregion

        #region Chứng từ
        [HttpPost("UpdateChungTu")]
        public async Task<IActionResult> UpdateChungTu([FromForm] HopDong_AddChungTuVm model)
        {
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var lstPath = "";
            if (model.ListImage != null && model.ListImage.Count > 0)
            {
                var lstFilePath = new List<string>();
                foreach (var file in model.ListImage)
                {
                    if (file != null && file.Length > 0)
                    {
                        if (FileHelper.IsValidImage(file))
                        {
                            var filePath = await FileHelper.Upload(file, model.ChungTuType == EHopDong_ChungTuType.HopDong ? FileUploadType.HopDong : FileUploadType.KhachHang, _appEnvironment.WebRootPath);
                            lstFilePath.Add(filePath);
                        }
                    }
                }
                lstPath = string.Join(";", lstFilePath);
            }

            if (model.ChungTuType == EHopDong_ChungTuType.HopDong)
            {
                if (!string.IsNullOrEmpty(hd.ImageList))
                {
                    hd.ImageList += ";" + lstPath;
                }
                else
                {
                    hd.ImageList = lstPath;
                }

            }
            else
            {
                var kh = await _db.KhachHangs.FindAsync(hd.KhachHangId);
                if (kh != null)
                {
                    if (!string.IsNullOrEmpty(kh.ImageList))
                    {
                        kh.ImageList += ";" + lstPath;
                    }
                    else
                    {
                        kh.ImageList = lstPath;
                    }

                }
            }
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>());
        }

        [HttpGet("GetChungTuByHopDong")]
        public async Task<IActionResult> GetChungTuByHopDong(int hopDongId)
        {
            var hd = await _db.HopDongs.FindAsync(hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var kh = await _db.KhachHangs.FindAsync(hd.KhachHangId);
            var lstImagepathHD = new List<string>();
            var lstImagepathKH = new List<string>();
            if (!string.IsNullOrEmpty(hd.ImageList))
            {
                var lstPath = hd.ImageList.Split(";");
                foreach (var item in lstPath)
                {
                    var img = baseAddressUploadApi + item;
                    lstImagepathHD.Add(img);
                }
            }
            if (kh != null)
            {
                if (!string.IsNullOrEmpty(kh.ImageList))
                {
                    var lstPath = kh.ImageList.Split(";");
                    foreach (var item in lstPath)
                    {
                        var img = baseAddressUploadApi + item;
                        lstImagepathKH.Add(img);
                    }
                }
            }
            var response = new HopDong_ChungTuResponseVm()
            {
                HopDongId = hd.Id,
                ImageHopDong = lstImagepathHD.Count > 0 ? string.Join(";", lstImagepathHD) : "",
                ImageKhachHang = lstImagepathKH.Count > 0 ? string.Join(";", lstImagepathKH) : "",
            };
            return Ok(new ApiSuccessResult<HopDong_ChungTuResponseVm>(response));
        }
        [HttpPost("DeleteChungTu")]
        public async Task<IActionResult> DeleteChungTu(DeleteChungTu_Vm model)
        {
            var hd = await _db.HopDongs.FindAsync(model.HopDongId);
            if (hd != null)
            {
                if (model.ChungTuType == EHopDong_ChungTuType.HopDong)
                {
                    if (!string.IsNullOrEmpty(hd.ImageList))
                    {
                        var lstFilePathOld = hd.ImageList.Split(";").ToList();
                        var src = model.Src.Replace(baseAddressUploadApi, "");
                        lstFilePathOld.Remove(src);
                        hd.ImageList = string.Join(";", lstFilePathOld);
                    }
                }
                else
                {
                    var kh = await _db.KhachHangs.FindAsync(hd.KhachHangId);
                    if (kh != null && !string.IsNullOrEmpty(kh.ImageList))
                    {
                        var lstFilePathOld = kh.ImageList.Split(";").ToList();
                        var src = model.Src.Replace(baseAddressUploadApi, "");
                        lstFilePathOld.Remove(src);
                        kh.ImageList = string.Join(";", lstFilePathOld);

                    }
                }
                await _db.SaveChangesAsync();

            }
            return Ok(new ApiSuccessResult<string>());
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
