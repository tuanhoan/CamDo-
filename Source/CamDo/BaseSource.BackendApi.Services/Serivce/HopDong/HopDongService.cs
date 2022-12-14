using AutoMapper;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.HopDong;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        private readonly IMapper _mapper;
        private readonly ILogger<HopDongService> _logger;
        public HopDongService(IServiceScopeFactory serviceScopeFactory, IMapper mapper, ILogger<HopDongService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _mapper = mapper;
            _logger = logger;
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
                            moneyInterest = (hd.TongTienVayHienTai * hd.HD_LaiSuat * 1000 * hd.HD_KyLai) / 1000000;
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
        public Task<DateTime> TinhNgayDaoHan(EHinhThucLai? type, DateTime hd_NgayVay, int hd_TongThoiGianVay, int kyLai)
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
                    result = hd_NgayVay.AddYears(10);
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
        public Task<int> TinhTongSoNgayVay(EHinhThucLai? type, int kyLai, int hd_TongThoiGianVay)
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
                    totalDay = Convert.ToInt32((DateTime.Now.AddYears(10) - DateTime.Now).TotalDays);
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
        public Task<double> TinhLaiHD(EHinhThucLai? hinhThucLai, int tongThoiGianVay, double laiSuat, double tongTienVayHienTai)
        {
            double laiSuatResult = 0;
            switch (hinhThucLai)
            {
                case EHinhThucLai.LaiNgayKTrieu:
                    laiSuatResult = (tongTienVayHienTai * laiSuat * 1000 * tongThoiGianVay) / 1000000;
                    break;
                case EHinhThucLai.LaiNgayKNgay:
                    laiSuatResult = laiSuat * 1000 * tongThoiGianVay;
                    break;
                case EHinhThucLai.LaiThangPhanTram:
                case EHinhThucLai.LaiThangDinhKi:
                case EHinhThucLai.LaiTuanPhanTram:
                    laiSuatResult = ((tongTienVayHienTai * laiSuat) / 100) * tongThoiGianVay;
                    break;
                case EHinhThucLai.LaiTuanVND:
                    laiSuatResult = laiSuat * 1000;
                    break;
                default:
                    break;
            }
            return Task.FromResult(laiSuatResult);
        }

        public async Task<KeyValuePair<bool, string>> CreateHopDongAsync(CreateHopDongVm model, int cuahangId, string userId)
        {

            using var _db = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BaseSourceDbContext>();
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var kh = new KhachHang()
                    {
                        Id = model.KhachHangId,
                        Ten = model.TenKhachHang,
                        CMND = model.CMND,
                        SDT = model.SDT,
                        DiaChi = model.DiaChi,
                        CuaHangId = cuahangId
                    };

                    int khachHangId = await AddOrUpDateCustomer(kh);

                    var hd = _mapper.Map<Data.Entities.HopDong>(model);
                    hd.TongTienVayHienTai = hd.HD_TongTienVayBanDau;
                    hd.KhachHangId = khachHangId;
                    hd.CuaHangId = cuahangId;
                    hd.UserIdCreated = userId;
                    hd.UserIdAssigned = userId;
                    hd.TongTienVayHienTai = hd.HD_TongTienVayBanDau;

                    //set  type HD
                    //hd.HD_Loai = model.LoaiHopDong;

                    switch (hd.HD_Loai)
                    {
                        case ELoaiHopDong.Camdo:
                            hd.HD_Status = (byte)EHopDong_CamDoStatusFilter.DangCam;
                            break;
                        case ELoaiHopDong.Vaylai:
                            break;
                        case ELoaiHopDong.GopVon:
                            hd.HD_HinhThucLai = model.HD_HinhThucLai;
                            hd.HD_Status = (byte)EHopDong_GopVonStatusFilter.DungHen;
                            break;
                        default:
                            break;
                    }
                    hd.HD_NgayDaoHan = await TinhNgayDaoHan(hd.HD_HinhThucLai, hd.HD_NgayVay, hd.HD_TongThoiGianVay, hd.HD_KyLai);
                    hd.TongTienLai = await TinhLaiHD(hd.HD_HinhThucLai, hd.HD_TongThoiGianVay, hd.HD_LaiSuat, hd.TongTienVayHienTai);
                    _db.HopDongs.Add(hd);
                    await _db.SaveChangesAsync();

                    if (model.HD_HinhThucLai != 0)
                    {
                        await TaoKyDongLai(hd.Id);
                    }
                    //commit transaction
                    await transaction.CommitAsync();
                    return new KeyValuePair<bool, string>(true, hd.Id.ToString());
                }

                catch (Exception ex)
                {
                    return new KeyValuePair<bool, string>(false, $"Tạo hợp đồng không thành công :[{ex.Message}]");
                }
            }
        }

        public async Task<int> AddOrUpDateCustomer(KhachHang model)
        {
            using var _db = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BaseSourceDbContext>();
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

        public async Task TinhLaiToiNgayHienTai()
        {
            _logger.LogInformation("TinhLaiToiNgayHienTai starts.");
            using var _db = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BaseSourceDbContext>();
            var lstHopDong = _db.HopDongs.AsQueryable();
            lstHopDong = lstHopDong.Where(x => x.HD_Status != (byte)EHopDong_CamDoStatusFilter.DaThanhLy && x.HD_Status != (byte)EHopDong_CamDoStatusFilter.DaXoa && x.HD_Status != (byte)EHopDong_CamDoStatusFilter.KetThuc);
            lstHopDong = lstHopDong.Where(x => x.HD_Status != (byte)EHopDong_VayLaiStatusFilter.DaXoa && x.HD_Status != (byte)EHopDong_CamDoStatusFilter.KetThuc);
            lstHopDong = lstHopDong.Where(x => x.HD_Status != (byte)EHopDong_GopVonStatusFilter.KetThuc);
            var currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var data = await lstHopDong.ToListAsync();
            foreach (var item in data)
            {

                var payment = await _db.HopDong_PaymentLogs.Where(x => x.PaidDate == null && x.HopDongId == item.Id).OrderBy(x => x.CreatedDate).ToListAsync();
                if (payment.Count > 0)
                {
                    var laiNgay = payment.FirstOrDefault().MoneyInterest / payment.FirstOrDefault().CountDay;
                    //lấy danh sách payment nhỏ hơn ngày hiện tại
                    double totalInterest = 0;
                    int totalDayPayment = 0;
                    var lstPaymetOutOfDate = payment.Where(x => x.ToDate <= currentDate).ToList();
                    if (lstPaymetOutOfDate.Count > 0)
                    {
                        foreach (var p in payment)
                        {
                            totalInterest += p.MoneyInterest;
                            totalDayPayment += p.CountDay;
                        }

                    }
                    //kỳ đóng lãi hiện tại
                    var itemInPayment = payment.FirstOrDefault(x => x.FromDate <= currentDate && x.ToDate >= currentDate);
                    if (itemInPayment != null)
                    {
                        totalDayPayment += (DateTime.Now - itemInPayment.FromDate).Days + 1;
                        totalInterest += (laiNgay * totalDayPayment);
                    }

                    item.TienLaiToiNgayHienTai = totalInterest;
                    item.SoNgayLaiToiHienTai = totalDayPayment;

                    switch (item.HD_Loai)
                    {
                        case ELoaiHopDong.Camdo:
                            if (itemInPayment != null)
                            {
                                if (itemInPayment.ToDate == currentDate)
                                {
                                    item.HD_Status = (byte)EHopDong_CamDoStatusFilter.HomNayDongTien;
                                }
                            }
                            else if (payment.Count == 1 && itemInPayment.ToDate == currentDate)
                            {
                                item.HD_Status = (byte)EHopDong_CamDoStatusFilter.DenNgayChuocDo;
                            }
                            else
                            {
                                item.HD_Status = (byte)EHopDong_CamDoStatusFilter.QuaHan;

                            }
                            break;
                        case ELoaiHopDong.Vaylai:
                            break;
                        case ELoaiHopDong.GopVon:
                            break;
                        default:
                            break;
                    }
                    try
                    {
                        await _db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }


            }
        }




        Task<bool> IHopDongService.CheckHopDongKetThuc(byte hdStatus, ELoaiHopDong type)
        {
            bool result = false;
            switch (type)
            {
                case ELoaiHopDong.Camdo:
                    if (hdStatus == (byte)EHopDong_CamDoStatusFilter.KetThuc)
                    {
                        result = true;
                    }
                    break;
                case ELoaiHopDong.Vaylai:
                    break;
                case ELoaiHopDong.GopVon:
                    break;
                default:
                    break;
            }
            return Task.FromResult(result);
        }

       
    }
}

