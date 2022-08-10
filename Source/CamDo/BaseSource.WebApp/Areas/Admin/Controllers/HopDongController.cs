using AutoMapper;
using BaseSource.ApiIntegration.WebApi;
using BaseSource.ApiIntegration.WebApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.WebApi.CuaHang_TransactionLog;
using BaseSource.ApiIntegration.WebApi.HD_PaymentLog;
using BaseSource.ApiIntegration.WebApi.HopDong;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.CauHinhHangHoa;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLog;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BaseSource.Utilities.Extensions;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDongController : BaseAdminController
    {
        private readonly ICauHinhHangHoaApiClient _cauHinhHangHoaApiClient;
        private readonly IHopDongApiClient _hopDongApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IHD_PaymentLogApiClient _hdPaymentLogApiClient;
        private readonly ICuaHang_TransactionLogApiClient _cuaHang_TransactionLog;
        private readonly IWebHostEnvironment _appEnvironment;
        public HopDongController(ICauHinhHangHoaApiClient cauHinhHangHoaApiClient,
            IHopDongApiClient hopDongApiClient, IUserApiClient userApiClient,
            IHD_PaymentLogApiClient hdPaymentLogApiClient, ICuaHang_TransactionLogApiClient cuaHang_TransactionLog,
            IWebHostEnvironment appEnvironment)
        {
            _cauHinhHangHoaApiClient = cauHinhHangHoaApiClient;
            _hopDongApiClient = hopDongApiClient;
            _userApiClient = userApiClient;
            _hdPaymentLogApiClient = hdPaymentLogApiClient;
            _cuaHang_TransactionLog = cuaHang_TransactionLog;
            _appEnvironment = appEnvironment;

        }
        public async Task<IActionResult> Create()
        {
            var requestCauHinhHH = new GetCauHinhHangHoaPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue
            };
            var requestUser = _userApiClient.GetUserByCuaHang();
            var resultCuaHinhHH = _cauHinhHangHoaApiClient.GetPagings(requestCauHinhHH);

            await Task.WhenAll(requestUser, resultCuaHinhHH);

            ViewData["ListHangHoa"] = new SelectList(resultCuaHinhHH.Result.ResultObj.Items, "Id", "Ten");
            ViewData["ListUser"] = new SelectList(requestUser.Result.ResultObj, "Id", "FullName");

            var model = new CreateHopDongVm()
            {
                HD_NgayVay = DateTime.Now.Date
            };

            return PartialView("_Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHopDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _hopDongApiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _hopDongApiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditHopDongVm()
            {
                Id = result.ResultObj.Id,
                TenKhachHang = result.ResultObj.TenKhachHang,
                SDT = result.ResultObj.SDT,
                CMND = result.ResultObj.CMND,
                DiaChi = result.ResultObj.DiaChi,
                CMND_NoiCap = result.ResultObj.CMND_NoiCap,
                CMND_NgayCap = result.ResultObj.CMND_NgayCap,
                HD_Ma = result.ResultObj.HD_Ma,
                HD_LaiSuat = result.ResultObj.HD_LaiSuat,
                HD_NgayVay = result.ResultObj.HD_NgayVay,
                HD_TongThoiGianVay = result.ResultObj.HD_TongThoiGianVay,
                HD_TongTienVayBanDau = result.ResultObj.HD_TongTienVayBanDau,
                TenTaiSan = result.ResultObj.TenTaiSan,
                HD_HinhThucLai = result.ResultObj.HD_HinhThucLai,
                HD_GhiChu = result.ResultObj.HD_GhiChu,
                HD_IsThuLaiTruoc = result.ResultObj.HD_IsThuLaiTruoc,
                HD_KyLai = result.ResultObj.HD_KyLai,
                HangHoaId = result.ResultObj.HangHoaId,
                ListThuocTinhHangHoa = result.ResultObj.ListThuocTinhHangHoa,
                UserIdAssigned = result.ResultObj.UserIdAssigned,
            };
            var requestCauHinhHH = new GetCauHinhHangHoaPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue
            };
            var requestUser = _userApiClient.GetUserByCuaHang();
            var resultCuaHinhHH = _cauHinhHangHoaApiClient.GetPagings(requestCauHinhHH);

            await Task.WhenAll(requestUser, resultCuaHinhHH);

            ViewData["ListHangHoa"] = new SelectList(resultCuaHinhHH.Result.ResultObj.Items, "Id", "Ten");
            ViewData["ListUser"] = new SelectList(requestUser.Result.ResultObj, "Id", "FullName");


            return PartialView("_Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditHopDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _hopDongApiClient.Edit(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }

            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }

        public async Task<IActionResult> GetListThuocTinhByTaiSan(int id, int hdID = 0)
        {
            var result = await _cauHinhHangHoaApiClient.GetById(id, hdID);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new List<ThuocTinhHangHoaVm>();
            if (!string.IsNullOrEmpty(result.ResultObj.ListThuocTinh))
            {
                var lstThuocTinhTemp = JsonConvert.DeserializeObject<dynamic>(result.ResultObj.ListThuocTinh);
                var lstThuocTinh = JsonConvert.DeserializeObject<List<ThuocTinhHangHoaVm>>(lstThuocTinhTemp);
                foreach (var item in lstThuocTinh)
                {
                    model.Add(new ThuocTinhHangHoaVm()
                    {
                        Name = item.Name,
                        Value = "",
                    });
                }
            }
            return Json(model);
        }
        public async Task<IActionResult> Detail(int id, string tabActive)
        {
            var hd = await _hopDongApiClient.GetById(id);
            ViewData["TabActive"] = tabActive;
            return PartialView("_Detail", hd.ResultObj);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hopDongApiClient.DeleteHopDong(id);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));

        }
        #region In hợp đồng
        public async Task<IActionResult> InKyDongLai(long paymentId)
        {
            var result = await _hopDongApiClient.InKyDongLai(paymentId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            var pathToFile = System.IO.Path.Combine(_appEnvironment.WebRootPath, "PrintTemplate", "InPhieuDongLai.html");
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                var source = await SourceReader.ReadToEndAsync();
                source = source.Replace("{mahopdong}", result.ResultObj.MaHD);
                source = source.Replace("{ngay}", DateTime.Now.Day.ToString());
                source = source.Replace("{thang}", DateTime.Now.Month.ToString());
                source = source.Replace("{nam}", DateTime.Now.Year.ToString());
                source = source.Replace("{tenkhachhang}", result.ResultObj.TenKhachHang);
                source = source.Replace("{tennhanvien}", result.ResultObj.TenNhanVien);
                source = source.Replace("{fromdate}", result.ResultObj.FromDate.ToString("dd/MM/yyyy"));
                source = source.Replace("{todate}", result.ResultObj.ToDate.ToString("dd/MM/yyyy"));
                source = source.Replace("{tienlai}", result.ResultObj.TienLai.ToString("N0"));
                source = source.Replace("{ngaydonglaitieptheo}", result.ResultObj.NgayDongLaiTiepTheo?.ToString("dd/MM/yyyy"));
                return Json(new ApiSuccessResult<string>(source));
            }

        }
        public async Task<IActionResult> InLichDongTien(int hopDongId)
        {
            var result = await _hdPaymentLogApiClient.GetPaymentLogByHD(hopDongId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            var pathToFile = System.IO.Path.Combine(_appEnvironment.WebRootPath, "PrintTemplate", "InLichDongLai.html");
            string strData = "";
            int i = 1;
            foreach (var item in result.ResultObj.ListPaymentLog)
            {
                var template = "<tr>" +
                                 "<td class='text-center'>{stt}</td>" +
                                 "<td class='text-center'>{fromDate} - {toDate}</td>" +
                                 "<td class='text-center'>{countday}</td>" +
                                 "<td class='text-right'>{tienlai}</td>" +
                                 "<td class='text-right'>{tienkhac}</td>" +
                                 "<td class='text-right'>{tonglai}</td>" +
                                 "<td class='text-right'>{tienkhachtra}</td>" +
                                 "<td class='text-center'><input type ='checkbox' {checked} /></td></tr>";

                template = template.Replace("{stt}", i.ToString());
                template = template.Replace("{fromDate}", item.FromDate.ToString("dd/MM/yyyy"));
                template = template.Replace("{toDate}", item.ToDate.ToString("dd/MM/yyyy"));
                template = template.Replace("{countday}", item.CountDay.ToString());
                template = template.Replace("{tienlai}", item.MoneyInterest.ToString("N0"));
                template = template.Replace("{tienkhac}", item.MoneyOther.ToString("N0"));
                template = template.Replace("{tonglai}", ((item.MoneyInterest + item.MoneyOther).ToString("N0")));
                template = template.Replace("{tienkhachtra}", item.MoneyPay.ToString("N0"));
                if (item.PaidDate != null)
                {
                    template = template.Replace("{checked}", "checked");
                }
                else
                {
                    template = template.Replace("{checked}", "");
                }
                strData += template;
                i++;

            }
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                var source = await SourceReader.ReadToEndAsync();
                source = source.Replace("{body}", strData);
                return Json(new ApiSuccessResult<string>(source));
            }

        }
        public async Task<IActionResult> InHDChuocDo(int hopDongId)
        {
            var result = await _hopDongApiClient.InChuocDo(hopDongId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            var pathToFile = System.IO.Path.Combine(_appEnvironment.WebRootPath, "PrintTemplate", "BienNhanChuocDo.html");
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                var source = await SourceReader.ReadToEndAsync();
                source = source.Replace("{mahopdong}", result.ResultObj.MaHD);
                source = source.Replace("{ngay}", DateTime.Now.ToString("dd/MM/yyyy"));
                source = source.Replace("{tentaisan}", result.ResultObj.TenTaiSan);
                source = source.Replace("{tenkhachhang}", result.ResultObj.TenKhachHang);
                source = source.Replace("{tennhanvien}", result.ResultObj.TenNhanVien);
                source = source.Replace("{ngayvay}", result.ResultObj.NgayVay.ToString("dd/MM/yyyy"));
                source = source.Replace("{ngaychuoc}", result.ResultObj.NgayChuoc?.ToString("dd/MM/yyyy"));
                source = source.Replace("{tiencam}", result.ResultObj.TienVay.ToString("N0"));
                source = source.Replace("{tienchuoc}", result.ResultObj.TienChuoc.ToString("N0"));
                return Json(new ApiSuccessResult<string>(source));
            }

        }
        #endregion


        #region Thanh toán lãi
        public async Task<IActionResult> GetListPaymentLog(int hdId)
        {
            var result = await _hdPaymentLogApiClient.GetPaymentLogByHD(hdId);
            return PartialView("_HD_PaymentLog", result.ResultObj);
        }
        public async Task<IActionResult> GetInfoPaymentByDate(int hdId)
        {
            var result = await _hdPaymentLogApiClient.GetPaymentByDate(hdId);
            return PartialView("_DongLaiTheoNgay", result.ResultObj);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePayment(int paymentId, int hdId, double customerPay)
        {
            var model = new CreateHDPaymentLogVm()
            {
                PaymentID = paymentId,
                HDId = hdId,
                CustomerPay = customerPay
            };
            var result = await _hdPaymentLogApiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<HD_PaymentLogReponse>(result.ResultObj, result.Message));
        }
        public async Task<IActionResult> DeletePayment(long paymentId)
        {
            var result = await _hdPaymentLogApiClient.Delete(paymentId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<HD_PaymentLogReponse>(result.ResultObj, result.Message));
        }
        public async Task<IActionResult> ChangePaymentDate(int hdId, string dateChange)
        {
            var model = new ChangePaymentDateRequestVm()
            {
                HdId = hdId,
                DateChange = Convert.ToDateTime(dateChange)
            };
            var result = await _hdPaymentLogApiClient.ChangePaymentDate(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<ChangePaymentDateResponseVm>(result.ResultObj));
        }
        public async Task<IActionResult> CreateHDPaymentByDate(HDPaymentByDateVm model)
        {
            var result = await _hdPaymentLogApiClient.CreatePaymentByDate(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<HD_PaymentLogReponse>(result.ResultObj, result.Message));
        }
        #endregion

        #region Ghi nợ - trả nợ
        [HttpPost]
        public async Task<IActionResult> NoLai(HopDongNoLaiVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var rs = await _hopDongApiClient.NoLai(model);
            if (!rs.IsSuccessed)
            {
                if (rs.ValidationErrors != null && rs.ValidationErrors.Count > 0)
                {
                    return Json(new ApiErrorResult<string>(rs.ValidationErrors));
                }
                else if (!string.IsNullOrEmpty(rs.Message))
                {
                    return Json(new ApiErrorResult<string>(rs.Message));
                }
            }
            return Json(new ApiSuccessResult<double>(double.Parse(rs.ResultObj), rs.Message));
        }
        public async Task<IActionResult> TraNo(HopDongTraNoVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var rs = await _hopDongApiClient.TraNo(model);
            if (!rs.IsSuccessed)
            {
                if (rs.ValidationErrors != null && rs.ValidationErrors.Count > 0)
                {
                    return Json(new ApiErrorResult<string>(rs.ValidationErrors));
                }
                else if (!string.IsNullOrEmpty(rs.Message))
                {
                    return Json(new ApiErrorResult<string>(rs.Message));
                }
            }
            return Json(new ApiSuccessResult<double>(double.Parse(rs.ResultObj), rs.Message));
        }
        #endregion

        #region Chứng từ
        public async Task<IActionResult> GetChungTu(int hopDongId)
        {
            var result = await _hopDongApiClient.GetChungTuByHopDong(hopDongId);
            return PartialView("_ChungTu", result.ResultObj);
        }
        [HttpPost]
        public async Task<IActionResult> UploadChungTu(HopDong_AddChungTuVm model)
        {
            var result = await _hopDongApiClient.UpdateChungTu(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>());
        }
        [HttpPost]
        public async Task<IActionResult> DeleteChungTu(DeleteChungTu_Vm model)
        {
            var result = await _hopDongApiClient.DeleteChungTu(model);
            if (result.IsSuccessed)
            {
                return Json(new ApiSuccessResult<string>());
            }
            return Json(new ApiErrorResult<string>(result.Message));
        }
        #endregion

        #region Export
        public async Task<IActionResult> Export(string info, DateTime? from, DateTime? to, int? loaihanghoa, int? status, ELoaiHopDong loaiHD, int page = 1)
        {
            var request = new GetHopDongPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue,
                LoaiHopDong = loaiHD,
                FormDate = from,
                ToDate = to,
                Info = info,
                LoaiHangHoa = loaihanghoa,
                Status = status
            };

            var result = await _hopDongApiClient.GetPagings(request);
            string fileName = loaiHD + "-" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Title = loaiHD.GetEnumDisplayName();

                //Create a sheet
                p.Workbook.Worksheets.Add(loaiHD.GetEnumDisplayName());
                ExcelWorksheet ws = p.Workbook.Worksheets[0];
                ws.Name = loaiHD.GetEnumDisplayName(); //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet


                // Create header column
                string[] arrColumnHeader = { "Mã HĐ", "Tên KH", "SĐT", "Tiền vay", "Lãi", "Ngày vay",
                                           "Ngày hết hạn","Đồ cầm","Đóng lãi đến","Tiền lãi đã đóng","Ngày đóng lãi tiếp theo"};
                var countColHeader = arrColumnHeader.Count();

                int colIndex = 1;
                int rowIndex = 1;

                //Creating Headings
                foreach (var item in arrColumnHeader)
                {
                    var cell = ws.Cells[rowIndex, colIndex];

                    //Setting the background color of header cells to Gray
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.MediumBlue);
                    cell.Style.Font.Color.SetColor(Color.White);
                    cell.Style.Font.Bold = true;

                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    cell.AutoFitColumns();
                    //Setting Value in cell
                    cell.Value = item;

                    colIndex++;
                }

                // Adding Data into rows

                foreach (var item in result.ResultObj.Items)
                {
                    colIndex = 1;
                    rowIndex++;
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_Ma;
                    ws.Cells[rowIndex, colIndex++].Value = item.TenKhachHang;
                    ws.Cells[rowIndex, colIndex++].Value = item.SDT;
                    ws.Cells[rowIndex, colIndex++].Value = item.TongTienVayHienTai.ToString("N0");
                    ws.Cells[rowIndex, colIndex++].Value = item.TyLeLai;
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_NgayVay.ToString("dd/MM/yyyy");
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_NgayDaoHan.ToString("dd/MM/yyyy");
                    ws.Cells[rowIndex, colIndex++].Value = item.TenTaiSan;
                    ws.Cells[rowIndex, colIndex++].Value = item.NgayDongLaiGanNhat?.ToString("dd/MM/yyyy");
                    ws.Cells[rowIndex, colIndex++].Value = item.TongTienLaiDaThanhToan.ToString("N0");
                    ws.Cells[rowIndex, colIndex++].Value = item.NgayDongLaiTiepTheo?.ToString("dd/MM/yyyy");
                }
                ws.Cells.AutoFitColumns();
                //Generate A File with name
                Byte[] bin = p.GetAsByteArray();
                return File(bin, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

        }
        #endregion

        #region Thanh lý
        public async Task<IActionResult> ChuyenTTChoThanhLy(int hopDongId)
        {
            var result = await _hopDongApiClient.ChuyenTrangThaiChoThanhLy(hopDongId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<IActionResult> ChuyenTTVeDangVay(int hopDongId)
        {
            var result = await _hopDongApiClient.ChuyenTrangThaiVeDangVay(hopDongId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<IActionResult> ThanhLy(int hopDongId)
        {
            var result = await _hopDongApiClient.ThanhLyHopDong(hopDongId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        #endregion
        #region Mở lại hợp đồng
        public async Task<IActionResult> MoLaiHopDong(int id)
        {
            var result = await _hopDongApiClient.MoLaiHopDong(id);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(result.Message));
        }
        #endregion

        #region Ẩn hợp đồng
        public async Task<IActionResult> AnHopDong(int id)
        {
            var result = await _hopDongApiClient.AnHopDong(id);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(result.Message));
        }
        #endregion

    }
}
