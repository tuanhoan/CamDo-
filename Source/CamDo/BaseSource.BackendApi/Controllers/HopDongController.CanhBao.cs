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
    public partial class HopDongController : BaseApiController
    {
        [HttpGet("GetCanhBaoPagings")]
        public async Task<IActionResult> GetCanhBaoPagings([FromQuery] GetCanhBaoPagingRequest request)
        {
            var model = _db.HopDongs.AsQueryable();
            model = model.Where(x => x.CuaHangId == CuaHangId && x.HD_Loai == request.LoaiHopDong && x.IsHidden == false);

            if (request.Status != null)
            {
                model = model.Where(x => x.HD_Status == (byte)request.Status);
            }
            if (request.KeySearch != null)
            {
                request.KeySearch = request.KeySearch.Trim();
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
                    Items = data.Where(x=> (x.HD_Ma.Contains(request.KeySearch) || x.TenKhachHang.Contains(request.KeySearch) || request.KeySearch == default)).ToList()
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
    }
}
