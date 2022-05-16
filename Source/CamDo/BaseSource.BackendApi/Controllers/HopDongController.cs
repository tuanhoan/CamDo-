using AutoMapper;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public HopDongController(BaseSourceDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
                                  MaTaiSan = hh.MaTS,
                                  TenKhachHang = kh.Ten,
                                  SDT = kh.SDT,
                                  TenTaiSan = hd.TenTaiSan,
                                  TienNo = 0,
                                  TongTienDaThanhToan = hd.TongTienDaThanhToan,
                                  TyLeLai = hd.HD_LaiSuat + htl.TyLeLai,
                                  ThoiGian = htl.ThoiGian

                              }).ToPagedListAsync(request.Page, request.PageSize);

            foreach (var item in data)
            {
                item.TongSoNgayVay = TinhTongSoNgayVay(item.ThoiGian, item.HD_NgayVay, item.HD_TongThoiGianVay);
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
            hd.KhachHangId = khachHangId;
            hd.CuaHangId = CuaHangId;
            hd.UserIdCreated = UserId;
            hd.UserIdAssigned = UserId;
            //gán tạm
            hd.HD_Loai = ELoaiHopDong.Camdo;
            _db.HopDongs.Add(hd);
            await _db.SaveChangesAsync();
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
            var result = _mapper.Map<HopDongVm>(hd);
            var kh = await _db.KhachHangs.FindAsync(hd.KhachHangId);
            result.TenKhachHang = kh.Ten;
            result.SDT = kh.SDT;
            result.DiaChi = kh.DiaChi;
            result.CMND = kh.CMND;
            result.CMND_NgayCap = kh.CMND_NgayCap;
            result.CMND_NoiCap = kh.CMND_NoiCap;
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
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Cập nhật hợp đồng thành công"));
        }

        private int TinhTongSoNgayVay(EThoiGianVay type, DateTime hd_NgayVay, int hd_TongThoiGianVay)
        {
            int totalDay = 0;
            switch (type)
            {
                case EThoiGianVay.Ngay:
                    totalDay = (hd_NgayVay.AddDays(hd_TongThoiGianVay) - hd_NgayVay).Days;
                    break;
                case EThoiGianVay.Tuan:
                    totalDay = (hd_NgayVay.AddDays(hd_TongThoiGianVay * 7) - hd_NgayVay).Days;
                    break;
                case EThoiGianVay.Thang:
                    totalDay = (hd_NgayVay.AddMonths(hd_TongThoiGianVay) - hd_NgayVay).Days;
                    break;
                default:
                    return 0;
            }
            return totalDay;
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
    }
}
