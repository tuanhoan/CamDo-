using AutoMapper;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
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
                              select new HopDongVm()
                              {
                                  Id = hd.Id,
                                  HD_LaiSuat = hd.HD_LaiSuat,
                                  HD_NgayVay = hd.HD_NgayVay,
                                  HD_TongThoiGianVay = hd.HD_TongThoiGianVay,
                                  HD_TongTienVayBanDau = hd.HD_TongTienVayBanDau,
                                  MaTaiSan = hh.MaTS,
                                  TenKhachHang = kh.Ten,
                                  TenTaiSan = hd.TenTaiSan,
                                  TienNo = 0,
                                  TongTienDaThanhToan = hd.TongTienDaThanhToan
                              }).ToPagedListAsync(request.Page, request.PageSize);


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
            var khachHang = await _db.KhachHangs.FindAsync(model.KhachHangId);
            int khachHangId = 0;
            if (khachHang == null)
            {
                var kh = _mapper.Map<KhachHang>(model);
                _db.KhachHangs.Add(kh);
                await _db.SaveChangesAsync();
                khachHangId = kh.Id;
            }

            model.KhachHangId = khachHangId;
            var hd = _mapper.Map<HopDong>(model);
            _db.HopDongs.Add(hd);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Tạo yêu cầu thành công, chúng tôi sẽ xử lý sớm nhất!"));
        }
    }
}
