using BaseSource.Shared.Enums;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Serivce.HopDong
{
    public interface IHopDongService
    {
        Task TaoKyDongLai(int hopdongId);

        Task<double> TinhLaiHD(EHinhThucLai? hinhThucLai, int tongThoiGianVay, double laiSuat, double tongTienVayHienTai);
        Task<int> TinhTongSoNgayVay(EHinhThucLai? hinhThucLai, int kyLai, int tongThoiGianVay);
        Task<DateTime> TinhNgayDaoHan(EHinhThucLai? hinhThucLai, DateTime hd_NgayVay, int hd_TongThoiGianVay, int kyLai);
        Task TinhLaiToiNgayHienTai();
        Task<KeyValuePair<bool, string>> CreateHopDongAsync(CreateHopDongVm model, int cuahangId, string userId);
        Task<bool> CheckHopDongKetThuc(byte hdStatus, ELoaiHopDong type);
    }
}
