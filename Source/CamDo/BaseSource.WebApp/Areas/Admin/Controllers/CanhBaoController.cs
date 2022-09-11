using BaseSource.ApiIntegration.WebApi.HopDong;
using BaseSource.ApiIntegration.WebApi.HopDong_AlarmLog;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.HopDong;
using BaseSource.ViewModels.HopDong_AlarmLog;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class CanhBaoController : BaseAdminController
    {
        private readonly IHopDong_AlarmLog _apiClient;
        private readonly IHopDongApiClient _hopDongApiClient;
        public CanhBaoController(IHopDong_AlarmLog apiClient ,IHopDongApiClient hopDongApiClient)
        {
            _apiClient = apiClient;
            _hopDongApiClient = hopDongApiClient;
        }


        //Thông báo hẹn giờ
        public async Task<IActionResult> AlarmDate(ELoaiHopDong type , int page = 1)
        {
            var request = new HopDong_AlarmLogRQ()
            {
                Page = page,
                PageSize = 10,
                Type = type,      };
            var result =await _apiClient.GetPagings(request);
            return View( result.ResultObj);
        }
        //Cảnh báo góp vốn
        public async Task<IActionResult> Capital(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.GopVon,
                KeySearch = info,
                Status = status
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return View(data.ResultObj);
        }
        public async Task<IActionResult> PrintCapital()
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = 1,
                LoaiHopDong = ELoaiHopDong.GopVon,
                KeySearch = null,
                Status = null
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return PartialView("_PrintCapital", data.ResultObj); ;
        }
        #region Export Capital
        public async Task<IActionResult> Export_Capital(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.GopVon,
                KeySearch = info,
                Status = status
            };

            var result = await _hopDongApiClient.GetCanhBaoPagings(request);
            string fileName = "Capital" + "-" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Title = "Capital";

                //Create a sheet
                p.Workbook.Worksheets.Add("Capital");
                ExcelWorksheet ws = p.Workbook.Worksheets[0];
                ws.Name = "Capital"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet


                // Create header column
                string[] arrColumnHeader = { "Mã HĐ", "Khách hàng", "Địa chỉ","Tài sản",  "Nợ cũ", "Tiền lãi", "Tiền gốc",
                                           "Tổng tiền","Lý do","Trạng thái" };
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
                    ws.Cells[rowIndex, colIndex++].Value = item.DiaChi;
                    ws.Cells[rowIndex, colIndex++].Value = item.TenTaiSan;
                    ws.Cells[rowIndex, colIndex++].Value = item.TienNo;
                    ws.Cells[rowIndex, colIndex++].Value = item.TongTienLai;
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_TongTienVayBanDau;
                    ws.Cells[rowIndex, colIndex++].Value = item.TongTienVayHienTai;
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_GhiChu;
                    ws.Cells[rowIndex, colIndex++].Value = item.StatusName; 
                }
                ws.Cells.AutoFitColumns();
                //Generate A File with name
                Byte[] bin = p.GetAsByteArray();
                return File(bin, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

        }
        #endregion 
        //Cảnh báo cầm đồ
        public async Task<IActionResult> Pawn(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.Camdo,
                KeySearch = info,
                Status = status
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return View(data.ResultObj);
        }
        public async Task<IActionResult> PrintPawn()
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = 1,
                LoaiHopDong = ELoaiHopDong.Camdo,
                KeySearch = null,
                Status = null
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return PartialView("_PrintPawn", data.ResultObj); ;
        }
        #region Export Pawn
        public async Task<IActionResult> Export_Pawn(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.Camdo,
                KeySearch = info,
                Status = status
            };

            var result = await _hopDongApiClient.GetCanhBaoPagings(request);
            string fileName = "Pawn" + "-" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Title = "Pawn";

                //Create a sheet
                p.Workbook.Worksheets.Add("Pawn");
                ExcelWorksheet ws = p.Workbook.Worksheets[0];
                ws.Name = "Pawn"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet


                // Create header column
                string[] arrColumnHeader = { "Mã HĐ", "Khách hàng", "Địa chỉ","Tài sản",  "Nợ cũ", "Tiền lãi", "Tiền gốc",
                                           "Tổng tiền","Lý do","Trạng thái" };
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
                    ws.Cells[rowIndex, colIndex++].Value = item.DiaChi;
                    ws.Cells[rowIndex, colIndex++].Value = item.TenTaiSan;
                    ws.Cells[rowIndex, colIndex++].Value = item.TienNo;
                    ws.Cells[rowIndex, colIndex++].Value = item.TongTienLai;
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_TongTienVayBanDau;
                    ws.Cells[rowIndex, colIndex++].Value = item.TongTienVayHienTai;
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_GhiChu;
                    ws.Cells[rowIndex, colIndex++].Value = item.StatusName;
                }
                ws.Cells.AutoFitColumns();
                //Generate A File with name
                Byte[] bin = p.GetAsByteArray();
                return File(bin, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

        }
        #endregion 
        //Cảnh báo vay lãi
        public async Task<IActionResult> Loan(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.Vaylai,
                KeySearch = info,
                Status = status
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return View();
        }
        public async Task<IActionResult> PrintLoan()
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = 1,
                LoaiHopDong = ELoaiHopDong.Vaylai,
                KeySearch = null,
                Status = null
            };
            var data = await _hopDongApiClient.GetCanhBaoPagings(request);
            return PartialView("_PrintLoan", data.ResultObj); ;
        }
        #region Export Loan
        public async Task<IActionResult> Export_Loan(string info, int? status, int page = 1)
        {
            var request = new GetCanhBaoPagingRequest()
            {
                Page = page,
                LoaiHopDong = ELoaiHopDong.Vaylai,
                KeySearch = info,
                Status = status
            };

            var result = await _hopDongApiClient.GetCanhBaoPagings(request);
            string fileName = "Loan" + "-" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Title = "Loan";

                //Create a sheet
                p.Workbook.Worksheets.Add("Loan");
                ExcelWorksheet ws = p.Workbook.Worksheets[0];
                ws.Name = "Loan"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet


                // Create header column
                string[] arrColumnHeader = { "Mã HĐ", "Khách hàng", "Địa chỉ","Tài sản",  "Nợ cũ", "Tiền lãi", "Tiền gốc",
                                           "Tổng tiền","Lý do","Trạng thái" };
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
                    ws.Cells[rowIndex, colIndex++].Value = item.DiaChi;
                    ws.Cells[rowIndex, colIndex++].Value = item.TenTaiSan;
                    ws.Cells[rowIndex, colIndex++].Value = item.TienNo;
                    ws.Cells[rowIndex, colIndex++].Value = item.TongTienLai;
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_TongTienVayBanDau;
                    ws.Cells[rowIndex, colIndex++].Value = item.TongTienVayHienTai;
                    ws.Cells[rowIndex, colIndex++].Value = item.HD_GhiChu;
                    ws.Cells[rowIndex, colIndex++].Value = item.StatusName;
                }
                ws.Cells.AutoFitColumns();
                //Generate A File with name
                Byte[] bin = p.GetAsByteArray();
                return File(bin, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

        }
        #endregion 
        //Cảnh báo vay họ
        public IActionResult Installment()
        {
            return View();
        }
    }
}
