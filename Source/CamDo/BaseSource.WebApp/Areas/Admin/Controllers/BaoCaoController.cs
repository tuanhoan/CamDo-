using BaseSource.ApiIntegration.WebApi;
using BaseSource.ApiIntegration.WebApi.BaoCao;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.BaoCao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class BaoCaoController : BaseAdminController
    {
        private readonly IBaoCaoApiClient _baoCaoApiClient;
        private readonly IUserApiClient _userApiClient; 
        public BaoCaoController(IBaoCaoApiClient baoCaoApiClient, IUserApiClient userApiClient)
        {
            _baoCaoApiClient = baoCaoApiClient;
            _userApiClient = userApiClient;
        }

        //Tổng kết giao dịch
        public async Task<IActionResult>  ReportBalance(DateTime? from, DateTime? to, int? loaihopdong, string user)
        {
            var request = new ReportBalanceRequest()
            {
                FormDate = from,
                ToDate = to,
                LoaiHopDong = loaihopdong,
                UserId = user
            };
            var result = await _baoCaoApiClient.ReportBalance(request);
            var requestUser = await _userApiClient.GetUserByCuaHang();
            ViewData["ListUser"] = new SelectList(requestUser.ResultObj, "Id", "FullName");
            return View(result.ResultObj);
        }
        #region Export
        public async Task<IActionResult> Export( DateTime? from, DateTime? to, int loaihopdong, string user)
        {
            var request = new ReportBalanceRequest()
            {
                FormDate = from,
                ToDate = to,
                LoaiHopDong = loaihopdong,
                UserId = user
            };

            var result = await _baoCaoApiClient.ReportBalance(request);
            string fileName = "reportBalance" + "-" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Title = "reportBalance";

                //Create a sheet
                p.Workbook.Worksheets.Add("reportBalance");
                ExcelWorksheet ws = p.Workbook.Worksheets[0];
                ws.Name = "reportBalance"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet


                // Create header column
                string[] arrColumnHeader = { "Loại hình", "Mã HĐ", "Người GD", "Khách hàng", "Ngày giao dịch", "Diễn Giải",
                                           "Đã thu","Đã chi","Ghi chú"};
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

                foreach (var item in result.ResultObj.GiaoDichs)
                {
                    colIndex = 1;
                    rowIndex++;
                    ws.Cells[rowIndex, colIndex++].Value = item.LoaiHopDong;
                    ws.Cells[rowIndex, colIndex++].Value = item.MaHopDong;
                    ws.Cells[rowIndex, colIndex++].Value = item.NgayGiaoDich;
                    ws.Cells[rowIndex, colIndex++].Value = item.KhachHang;
                    ws.Cells[rowIndex, colIndex++].Value = item.NgayGiaoDich.ToString("dd/MM/yyyy");
                    ws.Cells[rowIndex, colIndex++].Value = item.DienDai;
                    ws.Cells[rowIndex, colIndex++].Value = item.DaThu.ToString("N0");
                    ws.Cells[rowIndex, colIndex++].Value = item.DaChi.ToString("N0");
                    ws.Cells[rowIndex, colIndex++].Value = item.GhiChu;
                }
                ws.Cells.AutoFitColumns();
                //Generate A File with name
                Byte[] bin = p.GetAsByteArray();
                return File(bin, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

        }
        #endregion
        //Tổng kết lợi nhuận
        public async Task<IActionResult> Profit()
        {
            return View();
        }
        //Chi tiết tiền lãi
        public async Task<IActionResult> ReceiveInterest()
        {
            return View();
        }
        //Báo cáo đang cho vay
        public async Task<IActionResult> ReportPawnHolding()
        {
            return View();
        }
        //Thống kê thu tiền
        public async Task<IActionResult> PaymentHistory()
        {
            return View();
        }
        //Báo cáo hàng chờ thanh lý
        public async Task<IActionResult> WarehouseLiquidation()
        {
            return View();
        }
        //Báo cáo chuộc đồ, đống HD
        public async Task<IActionResult> ReportPawnNewRepurchase()
        {
            return View();
        }
        //Báo cáo thanh lý đồ
        public async Task<IActionResult> ReportPawnNewLiquidation()
        {
            return View();
        }
        //Báo cáo hợp đồng đã xóa
        public async Task<IActionResult> ReportContractCancel()
        {
            return View();
        }
        //Báo cáo tin nhắn
        public async Task<IActionResult> ReportSMS()
        {
            return View();
        }
        //Bàn giao ca
        public async Task<IActionResult> Inventory()
        {
            return View();
        }
        //Dòng tiền theo ngày
        public async Task<IActionResult> MoneyByDay()
        {
            return View();
        }
        //Khách hàng bị báo xấu
        public async Task<IActionResult> ReportCustomer()
        {
            return View();
        }
    }
}
