using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.HopDong;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Serivce.HopDong
{
    public class HopDongService : IHopDongService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public HopDongService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task TaoKyDongLai(int hopdongId)
        {
            using var _db = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BaseSourceDbContext>();
            var hd = await _db.HopDongs.FindAsync(hopdongId);
            var hdPaymentLogOld = await _db.HopDong_PaymentLogs.Where(x => x.HopDongId == hd.Id).ToListAsync();
            var lstNoPayment = hdPaymentLogOld.Where(x => x.PaidDate == null).ToList();
            var totalTimePayment = hdPaymentLogOld.Where(x => x.PaidDate != null).Count();
            if (hd.NgayDongLaiGanNhat != null)
            {
                _db.HopDong_PaymentLogs.RemoveRange(lstNoPayment);
            }
            else
            {
                _db.HopDong_PaymentLogs.RemoveRange(hdPaymentLogOld);
                hd.NgayDongLaiGanNhat = null;
                hd.TongTienLaiDaThanhToan = 0;
            }
            await _db.SaveChangesAsync();

            var tongKyDong = await TinhTongKyDong(hd, totalTimePayment);
            double tongLaiTheoKy = 0;
            var lstKyDongLai = new List<HopDong_PaymentLog>();
            var nextDate = new DateTime();
            var firstTime = hd.NgayDongLaiGanNhat != null ? hd.NgayDongLaiGanNhat.Value.AddDays(1) : hd.HD_NgayVay;

            for (int i = 1; i <= tongKyDong; i++)
            {
                double moneyInterest = 0;
                var item = new HopDong_PaymentLog();
                item.HopDongId = hd.Id;
                item.FromDate = i == 1 ? firstTime : nextDate;
                switch (hd.HD_HinhThucLai)
                {
                    case EHinhThucLai.LaiNgayKTrieu:
                        if (i == tongKyDong)
                        {
                            item.ToDate = hd.HD_NgayDaoHan;
                            moneyInterest = hd.TongTienLai - (hd.TongTienLaiDaThanhToan + tongLaiTheoKy);
                            item.CountDay = (hd.HD_NgayDaoHan - item.FromDate).Days + 1;
                        }
                        else
                        {
                            item.ToDate = item.FromDate.AddDays(hd.HD_KyLai - 1);
                            moneyInterest = (hd.TongTienVayHienTai / 1000000) * hd.HD_LaiSuat * hd.HD_KyLai * 1000;
                            item.CountDay = hd.HD_KyLai;

                        }


                        break;
                    case EHinhThucLai.LaiNgayKNgay:
                        if (i == tongKyDong)
                        {
                            item.ToDate = hd.HD_NgayDaoHan;
                            moneyInterest = hd.TongTienLai - (hd.TongTienLaiDaThanhToan + tongLaiTheoKy);
                            item.CountDay = (hd.HD_NgayDaoHan - item.FromDate).Days + 1;
                        }
                        else
                        {
                            item.ToDate = item.FromDate.AddDays(hd.HD_KyLai - 1);
                            moneyInterest = hd.HD_LaiSuat * hd.HD_KyLai * 1000;
                            item.CountDay = hd.HD_KyLai;

                        }


                        break;
                    case EHinhThucLai.LaiThangPhanTram:
                        if (i == tongKyDong)
                        {
                            item.ToDate = hd.HD_NgayDaoHan;
                            moneyInterest = hd.TongTienLai - (hd.TongTienLaiDaThanhToan + tongLaiTheoKy);
                            item.CountDay = (hd.HD_NgayDaoHan - item.FromDate).Days + 1;

                        }
                        else
                        {
                            item.ToDate = item.FromDate.AddDays(hd.HD_KyLai * 30).AddDays(-1);
                            item.CountDay = (item.ToDate - item.FromDate).Days + 1;
                            var moneyInterestOneMonth = (hd.HD_LaiSuat * hd.HD_TongTienVayBanDau) / 100;
                            int months = (item.ToDate.Year - item.FromDate.Year) * 12 + item.ToDate.Month - item.FromDate.Month;
                            moneyInterest = months * moneyInterestOneMonth;
                        }

                        break;
                    case EHinhThucLai.LaiThangDinhKi:
                        if (i == tongKyDong)
                        {
                            item.ToDate = hd.HD_NgayDaoHan;
                            item.CountDay = (hd.HD_NgayDaoHan - item.FromDate).Days + 1;
                            moneyInterest = hd.TongTienLai - (hd.TongTienLaiDaThanhToan + tongLaiTheoKy);
                        }
                        else
                        {
                            item.ToDate = item.FromDate.AddMonths(hd.HD_KyLai);
                            item.CountDay = (item.ToDate - item.FromDate).Days + 1;
                            var moneyInterestOneMonthDinhKy = (hd.HD_LaiSuat * hd.HD_TongTienVayBanDau) / 100;
                            int totalMonth = (item.ToDate.Year - item.FromDate.Year) * 12 + item.ToDate.Month - item.FromDate.Month;
                            moneyInterest = totalMonth * moneyInterestOneMonthDinhKy;
                        }

                        break;
                    case EHinhThucLai.LaiTuanPhanTram:
                    case EHinhThucLai.LaiTuanVND:
                        if (i == tongKyDong)
                        {
                            item.ToDate = hd.HD_NgayDaoHan;
                            item.CountDay = (hd.HD_NgayDaoHan - item.FromDate).Days + 1;
                            moneyInterest = hd.TongTienLai - (hd.TongTienLaiDaThanhToan + tongLaiTheoKy);
                        }
                        else
                        {
                            item.ToDate = item.FromDate.AddDays(7 * hd.HD_KyLai).AddDays(-1);
                            item.CountDay = 7 * hd.HD_KyLai;
                            var moneyInterestOneWeek = (hd.HD_LaiSuat * hd.HD_TongTienVayBanDau) / 100;
                            double weeks = Math.Ceiling((item.ToDate - item.FromDate).TotalDays / 7);
                            moneyInterest = weeks * moneyInterestOneWeek;
                        }


                        break;
                    default:
                        break;
                }

                item.MoneyInterest = moneyInterest;
                item.MoneyOther = 0;
                item.MoneyPay = moneyInterest;
                item.MoneyPayNeed = moneyInterest;
                item.CreatedDate = DateTime.Now;

                lstKyDongLai.Add(item);
                nextDate = hd.HD_HinhThucLai == EHinhThucLai.LaiThangDinhKi ? item.ToDate : item.ToDate.AddDays(1);
                tongLaiTheoKy += moneyInterest;
            }
            _db.HopDong_PaymentLogs.AddRange(lstKyDongLai);
            await _db.SaveChangesAsync();
        }
        
        /// <summary>
        /// Tạo các kỳ đóng lãi của hợp đồng
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tongThoiGianVay"></param>
        /// <param name="kyLai"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public Task<double> TinhTongKyDong(Data.Entities.HopDong hd, int totalTimePayment)
        {
            var ngayTinhKyLai = hd.NgayDongLaiGanNhat != null ? hd.NgayDongLaiGanNhat.Value : hd.HD_NgayVay;

            double tongKyLai = 0;
            switch (hd.HD_HinhThucLai)
            {
                case EHinhThucLai.LaiNgayKTrieu:
                case EHinhThucLai.LaiNgayKNgay:
                    var totalDay = (hd.HD_NgayDaoHan - ngayTinhKyLai).TotalDays;
                    tongKyLai = Math.Ceiling(totalDay / hd.HD_KyLai * 1.0);
                    break;
                case EHinhThucLai.LaiThangPhanTram:
                case EHinhThucLai.LaiThangDinhKi:
                case EHinhThucLai.LaiTuanPhanTram:
                case EHinhThucLai.LaiTuanVND:
                    if (hd.NgayDongLaiGanNhat != null)
                    {
                        var tongKyLaiTemp = Math.Ceiling(hd.HD_TongThoiGianVay * 1.0 / hd.HD_KyLai * 1.0);
                        tongKyLai = tongKyLaiTemp - totalTimePayment;
                    }
                    else
                    {
                        tongKyLai = Math.Ceiling(hd.HD_TongThoiGianVay * 1.0 / hd.HD_KyLai * 1.0);
                    }
                    break;
                default:
                    break;
            }
            return Task.FromResult(tongKyLai);
        }
        /// <summary>
        /// Tính ngày đáo hạn của hợp đồng
        /// </summary>
        /// <param name="type"></param>
        /// <param name="hd_NgayVay"></param>
        /// <param name="hd_TongThoiGianVay"></param>
        /// <param name="kyLai"></param>
        /// <returns></returns>
        public Task<DateTime> TinhNgayDaoHan(EHinhThucLai type, DateTime hd_NgayVay, int hd_TongThoiGianVay, int kyLai)
        {
            var tongKyDong = Math.Ceiling(hd_TongThoiGianVay * 1.0 / kyLai * 1.0);
            var result = new DateTime();
            switch (type)
            {
                case EHinhThucLai.LaiNgayKTrieu:
                case EHinhThucLai.LaiNgayKNgay:
                    result = hd_NgayVay.AddDays(hd_TongThoiGianVay - 1);
                    break;
                case EHinhThucLai.LaiThangPhanTram:
                    result = hd_NgayVay.AddDays(hd_TongThoiGianVay * 30).AddDays(-1);
                    break;
                case EHinhThucLai.LaiThangDinhKi:
                    result = hd_NgayVay.AddMonths(hd_TongThoiGianVay);
                    break;
                case EHinhThucLai.LaiTuanPhanTram:
                case EHinhThucLai.LaiTuanVND:
                    result = hd_NgayVay.AddDays((hd_TongThoiGianVay * 7) - 1);
                    break;
                default:
                    break;
            }
            return Task.FromResult(result);
        }
        /// <summary>
        /// Tính tổng số ngày vay hợp đồng
        /// </summary>
        /// <param name="type"></param>
        /// <param name="kyLai"></param>
        /// <param name="hd_TongThoiGianVay"></param>
        /// <returns></returns>
        public Task<int> TinhTongSoNgayVay(EHinhThucLai type, int kyLai, int hd_TongThoiGianVay)
        {
            int totalDay = 0;
            switch (type)
            {
                case EHinhThucLai.LaiNgayKTrieu:
                case EHinhThucLai.LaiNgayKNgay:
                    totalDay = hd_TongThoiGianVay;
                    break;
                case EHinhThucLai.LaiThangPhanTram:
                case EHinhThucLai.LaiThangDinhKi:
                    totalDay = 30 * hd_TongThoiGianVay;
                    break;
                case EHinhThucLai.LaiTuanPhanTram:
                case EHinhThucLai.LaiTuanVND:
                    totalDay = 7 * hd_TongThoiGianVay;
                    break;
                default:
                    break;
            }
            return Task.FromResult(totalDay);
        }
        /// <summary>
        /// tính tổng tiền lãi của hợp đồng
        /// </summary>
        /// <param name="hinhThucLai"></param>
        /// <param name="kyLai"></param>
        /// <param name="laiSuat"></param>
        /// <param name="tongTienVayBanDau"></param>
        /// <returns></returns>
        public Task<double> TinhLaiHD(EHinhThucLai hinhThucLai, int tongThoiGianVay, double laiSuat, double tongTienVayHienTai, double tongTienDaThanhToan)
        {
            double laiSuatResult = 0;
            double tongTienConLai = tongTienVayHienTai - tongTienDaThanhToan;
            switch (hinhThucLai)
            {
                case EHinhThucLai.LaiNgayKTrieu:
                    laiSuatResult = (tongTienConLai / 1000000) * laiSuat * tongThoiGianVay * 1000;
                    break;
                case EHinhThucLai.LaiNgayKNgay:
                    laiSuatResult = laiSuat * 1000 * tongThoiGianVay;
                    break;
                case EHinhThucLai.LaiThangPhanTram:
                case EHinhThucLai.LaiThangDinhKi:
                case EHinhThucLai.LaiTuanPhanTram:
                    laiSuatResult = ((tongTienConLai * laiSuat) / 100) * tongThoiGianVay;
                    break;
                case EHinhThucLai.LaiTuanVND:
                    laiSuatResult = laiSuat * 1000;
                    break;
                default:
                    break;
            }
            return Task.FromResult(laiSuatResult);
        }
    }
}
