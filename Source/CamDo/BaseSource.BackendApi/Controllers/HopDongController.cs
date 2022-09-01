using Antlr3.ST;
using AutoMapper;
using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.Utilities.Extensions;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet("GetMaxID")]
        public async Task<IActionResult> GetMaxID([FromQuery] ELoaiHopDong type)
        {
            var maxHd = (await _db.HopDongs.Where(x => x.HD_Loai == type)
                .MaxAsync(x => (int?)x.Id)) ?? 1;
            return Ok(new ApiSuccessResult<int>(maxHd));
        }

        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetHopDongPagingRequest request)
        {
            var model = _db.HopDongs.AsQueryable();
            model = model.Where(x => x.CuaHangId == CuaHangId && x.HD_Loai == request.LoaiHopDong && x.IsHidden == false);

            if (!string.IsNullOrEmpty(request.Info))
            {
                model = model.Where(x => x.HD_Ma.Contains(request.Info.Trim()));
            }

            if (request.FormDate != null)
            {
                model = model.Where(x => x.CreatedDate >= request.FormDate);
            }
            if (request.ToDate != null)
            {
                model = model.Where(x => x.CreatedDate <= request.ToDate);
            }
            if (request.LoaiHangHoa != null)
            {
                model = model.Where(x => x.HangHoaId == request.LoaiHangHoa.Value);
            }
            if (request.Status != null)
            {
                model = model.Where(x => x.HD_Status == (byte)request.Status);
            }

            if (request.LoaiHopDong == ELoaiHopDong.GopVon)
            {
                var totalVonDauTu = await model.SumAsync(x => x.HD_TongTienVayBanDau);
                var totalLai = await model.SumAsync(x => x.TongTienLaiDaThanhToan);

                var dataGopVon = await (from hd in model
                                        join htl in _db.MoTaHinhThucLais on hd.HD_HinhThucLai equals htl.HinhThucLai into htls
                                        from xhtl in htls.DefaultIfEmpty()
                                        join kh in _db.KhachHangs on hd.KhachHangId equals kh.Id
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
                                            TenKhachHang = kh.Ten,
                                            SDT = kh.SDT,
                                            TenTaiSan = hd.TenTaiSan,
                                            TienNo = hd.TongTienDaThanhToan - hd.TongTienGhiNo,
                                            TongTienDaThanhToan = hd.TongTienDaThanhToan,
                                            TyLeLai = xhtl != null ? hd.HD_LaiSuat + xhtl.TyLeLai : "Không tính lãi",
                                            ThoiGian = xhtl != null ? xhtl.ThoiGian : EThoiGianVay.Ngay,
                                            NgayDongLaiTiepTheo = hd.NgayDongLaiTiepTheo,
                                            HD_NgayDaoHan = hd.HD_NgayDaoHan,
                                            TongTienVayHienTai = hd.TongTienVayHienTai,
                                            HD_Loai = hd.HD_Loai,
                                            HD_Status = hd.HD_Status,
                                        }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);


                foreach (var item in dataGopVon)
                {
                    item.TongSoNgayVay = await _hopDongService.TinhTongSoNgayVay(item.HD_HinhThucLai, item.HD_KyLai, item.HD_TongThoiGianVay);
                    item.StatusName = GetTrangThaiHopDong(item.HD_Loai, item.HD_Status);
                }
                var pagedResult = new PagedResult<HopDongVm>()
                {
                    TotalItemCount = dataGopVon.TotalItemCount,
                    PageSize = dataGopVon.PageSize,
                    PageNumber = dataGopVon.PageNumber,
                    Items = dataGopVon.ToList()
                };
                //add record total
                pagedResult.Items.Add(new HopDongVm
                {
                    TongTienLaiDaThanhToan = totalLai,
                    HD_TongTienVayBanDau = totalVonDauTu
                });

                return Ok(new ApiSuccessResult<PagedResult<HopDongVm>>(pagedResult));
            }
            else
            {
                var tongTienCam = await model.SumAsync(x => x.HD_TongTienVayBanDau);
                var tongLaiDaDong = await model.SumAsync(x => x.TongTienLaiDaThanhToan);
                var tongGhiNo = await model.SumAsync(x => x.TongTienGhiNo);
                var tongDaThanhToan = await model.SumAsync(x => x.TongTienDaThanhToan);
                var tongLaiDenHomNay = await model.SumAsync(x => x.TienLaiToiNgayHienTai);

                var khs = await _db.KhachHangs.Select(x => x.Id).ToListAsync();
                var hhs = await _db.CauHinhHangHoas.Select(x => x.Id).ToListAsync();

                var data = await (from hd in model
                                  join kh in _db.KhachHangs on hd.KhachHangId equals kh.Id
                                  join hh in _db.CauHinhHangHoas on hd.HangHoaId equals hh.Id into chhh
                                  from hh in chhh.DefaultIfEmpty()
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
                                      TienNo = hd.TongTienDaThanhToan - hd.TongTienGhiNo,
                                      MaTaiSan = hh.MaTS,
                                      TenKhachHang = kh.Ten,
                                      SDT = kh.SDT,
                                      TenTaiSan = hd.TenTaiSan,
                                      TongTienGhiNo = hd.TongTienGhiNo,
                                      TongTienDaThanhToan = hd.TongTienDaThanhToan,
                                      TyLeLai = hd.HD_LaiSuat + htl.TyLeLai,
                                      ThoiGian = htl.ThoiGian,
                                      NgayDongLaiTiepTheo = hd.NgayDongLaiTiepTheo,
                                      HD_NgayDaoHan = hd.HD_NgayDaoHan,
                                      TongTienVayHienTai = hd.TongTienVayHienTai,
                                      HD_Loai = hd.HD_Loai,
                                      HD_Status = hd.HD_Status,
                                      TienLaiToiNgayHienTai = hd.TienLaiToiNgayHienTai

                                  }).OrderByDescending(x => x.Id)
                                  .ToPagedListAsync(request.Page, request.PageSize);

                foreach (var item in data)
                {
                    item.TongSoNgayVay = await _hopDongService.TinhTongSoNgayVay(item.HD_HinhThucLai, item.HD_KyLai, item.HD_TongThoiGianVay);
                    item.StatusName = GetTrangThaiHopDong(item.HD_Loai, item.HD_Status);
                }
                var pagedResult = new PagedResult<HopDongVm>()
                {
                    TotalItemCount = data.TotalItemCount,
                    PageSize = data.PageSize,
                    PageNumber = data.PageNumber,
                    Items = data.ToList()
                };

                //add record total
                pagedResult.Items.Add(new HopDongVm
                {
                    HD_TongTienVayBanDau = tongTienCam,
                    TongTienLaiDaThanhToan = tongLaiDaDong,
                    TienNo = tongDaThanhToan - tongGhiNo,
                    TienLaiToiNgayHienTai = tongLaiDenHomNay
                });

                return Ok(new ApiSuccessResult<PagedResult<HopDongVm>>(pagedResult));
            }
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
                Ten = model.TenKhachHang,
                CMND = model.CMND,
                SDT = model.SDT,
                DiaChi = model.DiaChi,
                CuaHangId = CuaHangId,
                CMND_NgayCap = model.CMND_NgayCap,
                CMND_NoiCap = model.CMND_NoiCap
            };

            int khachHangId = await AddOrUpDateCustomer(model.KhachHangId, kh);

            var hd = _mapper.Map<HopDong>(model);
            string prefix = "";
            switch (model.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    prefix = "CĐ";
                    break;
                case ELoaiHopDong.Vaylai:
                    prefix = "TC";
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }
            if (model.HD_Loai == ELoaiHopDong.GopVon)
            {
                hd.HD_Ma = "0";
            }
            else
            {
                hd.HD_Ma = $"{prefix}-{model.HD_MaTemp}";
            }
            hd.TongTienVayHienTai = hd.HD_TongTienVayBanDau;
            hd.KhachHangId = khachHangId;
            hd.CuaHangId = CuaHangId;
            hd.UserIdCreated = UserId;
            hd.UserIdAssigned = UserId;
            hd.TongTienVayHienTai = hd.HD_TongTienVayBanDau;
            hd.ListThuocTinhHangHoa = JsonConvert.SerializeObject(hd.ListThuocTinhHangHoa, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            switch (hd.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    hd.HD_Status = (byte)EHopDong_CamDoStatusFilter.DangCam;
                    break;
                case ELoaiHopDong.Vaylai:
                    hd.HD_Status = (byte)EHopDong_VayLaiStatusFilter.DangVay;
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }
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
            if (hd.HD_Loai != ELoaiHopDong.GopVon)
            {
                result.HD_MaTemp = int.Parse(result.HD_Ma.Split("-")[1]);
            }

            result.StatusName = GetTrangThaiHopDong(result.HD_Loai, result.HD_Status);

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

            _mapper.Map(model, hd);

            string prefix = "";
            switch (model.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    prefix = "CĐ";
                    break;
                case ELoaiHopDong.Vaylai:
                    prefix = "TC";
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }
            if (model.HD_Loai == ELoaiHopDong.GopVon)
            {
                hd.HD_Ma = "0";
            }
            else
            {
                hd.HD_Ma = $"{prefix}-{model.HD_MaTemp}";
            }
            hd.HD_NgayDaoHan = await _hopDongService.TinhNgayDaoHan(hd.HD_HinhThucLai, hd.HD_NgayVay, hd.HD_TongThoiGianVay, hd.HD_KyLai);
            hd.TongTienLai = await _hopDongService.TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            hd.ListThuocTinhHangHoa = JsonConvert.SerializeObject(hd.ListThuocTinhHangHoa, settings);
            await _db.SaveChangesAsync();

            if (isChangeKyLai)
            {
                var rs = Task.Run(() => TaoKyDongLai(hd.Id));
            }

            return Ok(new ApiSuccessResult<string>("Cập nhật hợp đồng thành công"));
        }



        [HttpPost("DeleteHopDong")]
        public async Task<IActionResult> DeleteHopDong([FromForm] int hopDongId)
        {
            var hd = await _db.HopDongs.FindAsync(hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            switch (hd.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    var currentStatus = (EHopDong_CamDoStatusFilter)hd.HD_Status;
                    if (currentStatus == EHopDong_CamDoStatusFilter.DaXoa)
                    {
                        return Ok(new ApiErrorResult<string>("Hợp đồng này đã bị xóa trước đó"));
                    }
                    else
                    {
                        hd.HD_Status = (byte)EHopDong_CamDoStatusFilter.DaXoa;
                    }
                    break;
                case ELoaiHopDong.Vaylai:
                    var currentStatusVL = (EHopDong_VayLaiStatusFilter)hd.HD_Status;
                    if (currentStatusVL == EHopDong_VayLaiStatusFilter.DaXoa)
                    {
                        return Ok(new ApiErrorResult<string>("Hợp đồng này đã bị xóa trước đó"));
                    }
                    else
                    {
                        hd.HD_Status = (byte)EHopDong_VayLaiStatusFilter.DaXoa;
                    }
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }

            await _db.SaveChangesAsync();
            var tranLog = new CreateCuaHang_TransactionLogVm()
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.XoaHD,
                FeatureType = eFeatureType(hd.HD_Loai),
                UserId = UserId,
                TotalMoneyLoan = hd.TongTienVayHienTai

            };
            var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
            return Ok(new ApiSuccessResult<string>("Xóa hợp đồng thành công"));
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
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
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
                    FeatureType = eFeatureType(hd.HD_Loai),
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
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
            }
            hd.TongTienDaThanhToan += model.SoTienTraNo ?? 0;
            await _db.SaveChangesAsync();

            var tranLog = new CreateCuaHang_TransactionLogVm()
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.TraNo,
                FeatureType = eFeatureType(hd.HD_Loai),
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

        #region In hợp đồng

        [HttpGet("InKyDongLai")]
        public async Task<IActionResult> InKyDongLai(long paymentId)
        {
            var payment = await _db.HopDong_PaymentLogs.FindAsync(paymentId);
            if (payment == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            var hd = await _db.HopDongs.FindAsync(payment.HopDongId);
            var kh = await _db.KhachHangs.FindAsync(hd.KhachHangId);
            var user = await _db.UserProfiles.FindAsync(UserId);

            var response = new InDongLaiResponseVm()
            {
                FromDate = payment.FromDate,
                ToDate = payment.ToDate,
                MaHD = hd.HD_Ma,
                NgayDongLaiTiepTheo = hd.NgayDongLaiTiepTheo,
                TenKhachHang = kh.Ten,
                TienLai = payment.MoneyPay,
                TenNhanVien = user.FullName
            };
            return Ok(new ApiSuccessResult<InDongLaiResponseVm>(response));
        }

        [HttpGet("InChuocDo")]
        public async Task<IActionResult> InChuocDo(int hopDongId)
        {
            var hd = await _db.HopDongs.FindAsync(hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            var kh = await _db.KhachHangs.FindAsync(hd.KhachHangId);
            var user = await _db.UserProfiles.FindAsync(UserId);
            var response = new InChuocDoResponseVm()
            {
                MaHD = hd.HD_Ma,
                NgayChuoc = hd?.NgayTatToan,
                NgayVay = hd.HD_NgayVay,
                TenKhachHang = kh.Ten,
                TenNhanVien = user?.FullName,
                TenTaiSan = hd.TenTaiSan,
                TienChuoc = hd.TongTienChuoc,
                TienVay = hd.TongTienVayHienTai
            };
            return Ok(new ApiSuccessResult<InChuocDoResponseVm>(response));
        }


        [HttpGet("InHopDong")]
        public async Task<IActionResult> InHopDong(int hopDongId)
        {
            var hd = await _db.HopDongs.AsNoTracking()
                .Include(x => x.CuaHang)
                .FirstOrDefaultAsync(x => x.Id == hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            var kh = await _db.KhachHangs.FindAsync(hd.KhachHangId);
            var user = await _db.UserProfiles.AsNoTracking().Include(x=>x.AppUser).FirstOrDefaultAsync(x=>x.UserId == hd.UserIdAssigned);
            // If using Professional version, put your serial key below.

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            //using (StreamReader reader = new StreamReader(Server.MapPath(@"C:\Users\Nino\Downloads\HD cầm đồ 1.docx")))

            var template = new StringTemplate();

            var text = System.IO.File.ReadAllText(_appEnvironment.ContentRootPath + "\\wwwroot\\Resource\\" + "HD cầm đồ 1.html");

            //remove all tabs - it used only to format template code, not output code
            template.Template = text.Replace("\t", "");

            template.SetAttribute("UserName", user.FullName);
            template.SetAttribute("TenCuaHang", hd.CuaHang.Ten);
            template.SetAttribute("SDTCuaHang", hd.CuaHang.SDT);
            template.SetAttribute("MGD", hd.HD_Ma);
            template.SetAttribute("NgayKiHD", hd.HD_NgayVay);
            template.SetAttribute("TenCuaHang", hd.CuaHang.Ten);
            template.SetAttribute("TenNhanVien", user.FullName);
            template.SetAttribute("SDTNhanVien", user.AppUser.PhoneNumber);
            template.SetAttribute("DiaChiCuaHang", hd.CuaHang.DiaChi);
            template.SetAttribute("TenKhachHang", kh.Ten);
            template.SetAttribute("SDTKhachHang", kh.SDT);
            template.SetAttribute("DiaChiKhachHang", kh.SDT);
            template.SetAttribute("CMND", kh.CMND);
            template.SetAttribute("NgayCap", kh.CMND_NgayCap?.ToString("dd-MM-yyyy"));
            template.SetAttribute("NoiCap", kh.CMND_NoiCap);
            template.SetAttribute("LoaiTaiSan", kh.CMND_NoiCap);
            template.SetAttribute("TenTaiSan", hd.TenTaiSan);
            template.SetAttribute("SoTienVay", hd.HD_TongTienVayBanDau);
            template.SetAttribute("NgayVay", hd.HD_NgayVay);
            template.SetAttribute("NgayTra", hd.NgayTatToan);

            var output = template.ToString();

            return Ok(output);
        }
        #endregion

        #region Thanh lý
        [HttpPost("ChuyenTrangThaiChoThanhLy")]
        public async Task<IActionResult> ChuyenTrangThaiChoThanhLy([FromForm] int hopDongId)
        {
            var hd = await _db.HopDongs.FindAsync(hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
            }
            switch (hd.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    var currentStatus = (EHopDong_CamDoStatusFilter)hd.HD_Status;
                    if (currentStatus == EHopDong_CamDoStatusFilter.DaThanhLy)
                    {
                        return Ok(new ApiErrorResult<string>("Hợp đồng này đã thanh lý trước đó"));
                    }
                    else
                    {
                        hd.HD_Status = (byte)EHopDong_CamDoStatusFilter.ChoThanhLy;
                    }
                    break;
                case ELoaiHopDong.Vaylai:
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }

            await _db.SaveChangesAsync();
            //var tranLog = new CreateCuaHang_TransactionLogVm()
            //{
            //    HopDongId = hd.Id,
            //    ActionType = EHopDong_ActionType.ChoThanhLy,
            //    FeatureType = EFeatureType.Camdo,
            //    UserId = UserId,
            //    TotalMoneyLoan = hd.TongTienVayHienTai

            //};
            //var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
            return Ok(new ApiSuccessResult<string>("Xóa hợp đồng thành công"));
        }

        [HttpPost("ThanhLyHopDong")]
        public async Task<IActionResult> ThanhLyHopDong([FromForm] int hopDongId)
        {
            var hd = await _db.HopDongs.FindAsync(hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
            }
            switch (hd.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    var currentStatus = (EHopDong_CamDoStatusFilter)hd.HD_Status;
                    if (currentStatus == EHopDong_CamDoStatusFilter.DaThanhLy)
                    {
                        return Ok(new ApiErrorResult<string>("Hợp đồng này đã thanh lý trước đó"));
                    }
                    else
                    {
                        hd.HD_Status = (byte)EHopDong_CamDoStatusFilter.DaThanhLy;
                    }
                    break;
                case ELoaiHopDong.Vaylai:
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }

            await _db.SaveChangesAsync();
            var tranLog = new CreateCuaHang_TransactionLogVm()
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.ThanhLyDo,
                FeatureType = EFeatureType.Camdo,
                UserId = UserId,
                TotalMoneyLoan = hd.TongTienVayHienTai

            };
            var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
            return Ok(new ApiSuccessResult<string>("Xóa hợp đồng thành công"));
        }
        [HttpPost("ChuyenTrangThaiVeDangVay")]
        public async Task<IActionResult> ChuyenTrangThaiVeDangVay([FromForm] int hopDongId)
        {
            var hd = await _db.HopDongs.FindAsync(hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Hợp đồng này đã kết thúc"));
            }
            switch (hd.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    var currentStatus = (EHopDong_CamDoStatusFilter)hd.HD_Status;
                    if (currentStatus == EHopDong_CamDoStatusFilter.ChoThanhLy)
                    {
                        hd.HD_Status = (byte)EHopDong_CamDoStatusFilter.DangCam;
                    }
                    else
                    {
                        return Ok(new ApiErrorResult<string>("Bạn không thể chuyển trạng thái đơn hàng"));
                    }
                    break;
                case ELoaiHopDong.Vaylai:
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }

            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Xóa hợp đồng thành công"));
        }
        #endregion

        #region Report 
        [HttpGet("GetReportHeader")]
        public async Task<IActionResult> GetReportHeader(ELoaiHopDong type)
        {
            var response = new HopDong_ReportVm();
            var cuaHang = await _db.CuaHangs.FindAsync(CuaHangId);
            //gắn tạm chưa biết công thức
            response.QuyTienMat = cuaHang.VonDauTu;
            var listHopDong = _db.HopDongs.AsQueryable();
            listHopDong = listHopDong.Where(x => x.CuaHangId == CuaHangId && x.HD_Loai == type);
            switch (type)
            {
                case ELoaiHopDong.Camdo:
                    listHopDong = listHopDong.Where(x => x.HD_Status != (byte)EHopDong_CamDoStatusFilter.DaThanhLy && x.HD_Status != (byte)EHopDong_CamDoStatusFilter.DaXoa && x.HD_Status != (byte)EHopDong_CamDoStatusFilter.KetThuc);
                    break;
                case ELoaiHopDong.Vaylai:
                    listHopDong = listHopDong.Where(x => x.HD_Status != (byte)EHopDong_VayLaiStatusFilter.DaXoa && x.HD_Status != (byte)EHopDong_CamDoStatusFilter.KetThuc);
                    break;
                case ELoaiHopDong.GopVon:
                    listHopDong = listHopDong.Where(x => x.HD_Status != (byte)EHopDong_GopVonStatusFilter.KetThuc);
                    break;
                default:
                    break;
            }
            var tienChoVay = await listHopDong.SumAsync(x => x.TongTienVayHienTai);
            var tienGhiNo = await listHopDong.SumAsync(x => x.TongTienGhiNo);
            var tienDaThanhToan = await listHopDong.SumAsync(x => x.TongTienDaThanhToan);
            var laiDuKien = await listHopDong.SumAsync(x => x.TienLaiToiNgayHienTai);
            var laiDaThu = await listHopDong.SumAsync(x => x.TongTienLaiDaThanhToan);

            response.TienChoVay = tienChoVay;
            response.TienNo = tienDaThanhToan - tienGhiNo;
            response.LaiDuKien = laiDuKien;
            response.LaiDaThu = laiDaThu;
            return Ok(new ApiSuccessResult<HopDong_ReportVm>(response));
        }
        #endregion

        #region Mở lại hợp đồng
        [HttpPost("MoLaiHopDong")]
        public async Task<IActionResult> MoLaiHopDong([FromForm] int hopDongId)
        {
            var hd = await _db.HopDongs.FindAsync(hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            var isKetThuc = await _hopDongService.CheckHopDongKetThuc(hd.HD_Status, hd.HD_Loai);
            if (!isKetThuc)
            {
                return Ok(new ApiErrorResult<string>("Bạn không thể mở lại hợp đồng"));
            }
            switch (hd.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    hd.HD_Status = (byte)EHopDong_CamDoStatusFilter.DangCam;
                    break;
                case ELoaiHopDong.Vaylai:
                    hd.HD_Status = (byte)EHopDong_VayLaiStatusFilter.DangVay;
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }
            hd.NgayTatToan = null;
            await _db.SaveChangesAsync();
            var tranLog = new CreateCuaHang_TransactionLogVm()
            {
                HopDongId = hd.Id,
                ActionType = EHopDong_ActionType.MoLaiHD,
                FeatureType = eFeatureType(hd.HD_Loai),
                UserId = UserId,
                TotalMoneyLoan = hd.TongTienChuoc

            };
            var result = Task.Run(() => CreateCuaHang_TransactionLog(tranLog));
            return Ok(new ApiSuccessResult<string>("Xóa hợp đồng thành công"));
        }
        #endregion
        #region Ẩn lại hợp đồng
        [HttpPost("AnHopDong")]
        public async Task<IActionResult> AnHopDong([FromForm] int hopDongId)
        {
            var hd = await _db.HopDongs.FindAsync(hopDongId);
            if (hd == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }
            switch (hd.HD_Loai)
            {
                case ELoaiHopDong.Camdo:
                    if (hd.HD_Status != (byte)EHopDong_CamDoStatusFilter.DaThanhLy && hd.HD_Status != (byte)EHopDong_CamDoStatusFilter.KetThuc)
                    {
                        return Ok(new ApiErrorResult<string>("Bạn không thể ẩn hợp đồng"));
                    }
                    break;
                case ELoaiHopDong.Vaylai:
                    if (hd.HD_Status != (byte)EHopDong_VayLaiStatusFilter.ChamLai && hd.HD_Status != (byte)EHopDong_VayLaiStatusFilter.KetThuc)
                    {
                        return Ok(new ApiErrorResult<string>("Bạn không thể ẩn hợp đồng"));
                    }
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }
            hd.IsHidden = true;
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Ẩn hợp đồng thành công"));
        }
        #endregion

        #region mẫu hợp đồng
        [HttpGet("GetPrintDefault")]
        public async Task<IActionResult> GetPrintDefault(ELoaiHopDong type)
        {
            var response = new HopDongPrintDefaulVm();
            response.LoaiHopDong = type;
            var cuaHang = await _db.CuaHangs.FirstOrDefaultAsync(x => x.Id == CuaHangId);
            switch (type)
            {
                case ELoaiHopDong.Camdo:
                    if (cuaHang != null)
                    {
                        response.CamDo_HopDongPrintTemplate = cuaHang.CamDo_HopDongPrintTemplate;
                        response.CamDo_HopDongPrintTemplate = cuaHang.CamDo_HopDongPrintTemplate;
                    }
                    break;
                case ELoaiHopDong.Vaylai:
                    if (cuaHang != null)
                    {
                        response.VayLai_HopDongPrintTemplate = cuaHang.VayLai_HopDongPrintTemplate;
                        response.VayLai_HopDongPrintTemplate = cuaHang.VayLai_HopDongPrintTemplate;
                    }
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }
            return Ok(new ApiSuccessResult<HopDongPrintDefaulVm>(response));
        }
        [HttpPost("SavePrintDefault")]
        public async Task<IActionResult> SavePrintDefault(HopDongPrintDefaulVm model)
        {
            var cuaHang = await _db.CuaHangs.FirstOrDefaultAsync(x => x.Id == CuaHangId);
            switch (model.LoaiHopDong)
            {
                case ELoaiHopDong.Camdo:
                    if (cuaHang != null)
                    {
                        cuaHang.CamDo_HopDongPrintTemplate = model.CamDo_HopDongPrintTemplate;
                    }
                    break;
                case ELoaiHopDong.Vaylai:
                    if (cuaHang != null)
                    {
                        cuaHang.VayLai_HopDongPrintTemplate = model.VayLai_HopDongPrintTemplate;
                    }
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>());
        }
        #endregion
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
        private async Task<int> AddOrUpDateCustomer(int id, KhachHang model)
        {
            int khachHangId = 0;
            var khachHang = await _db.KhachHangs.FindAsync(id);
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
                khachHang.CMND_NgayCap = model.CMND_NgayCap;
                khachHang.CMND_NoiCap = model.CMND_NoiCap;
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
        private EFeatureType eFeatureType(ELoaiHopDong loaiHd)
        {
            var featureType = EFeatureType.Camdo;
            switch (loaiHd)
            {
                case ELoaiHopDong.Camdo:
                    featureType = EFeatureType.Camdo;
                    break;
                case ELoaiHopDong.Vaylai:
                    featureType = EFeatureType.Vaylai;
                    break;
                case ELoaiHopDong.GopVon:
                    featureType = EFeatureType.GopVon;
                    break;
            }
            return featureType;
        }
        #endregion

        [HttpPost("TinhLaiNgay")]
        public async Task TinhLaiNgay()
        {
            await _hopDongService.TinhLaiToiNgayHienTai();
        }
    }
}
