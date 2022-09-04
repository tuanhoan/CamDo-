using BaseSource.Data.EF;
using BaseSource.ViewModels.BaoCao;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class BaoCaosController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public BaoCaosController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [HttpGet("ReportBalance")]
        public async Task<IActionResult> ReportBalance()
        {
            var hopdongs = await _db.HopDongs.ToListAsync();
            var cuahangtranLogs = await _db.CuaHang_TransactionLogs.ToListAsync();
            var cuahangQuyTienLogs = await _db.CuaHang_QuyTienLogs.ToListAsync();
            var data = new ReportBalanceVM()
            {
                TienDauNgay = new Summary
                {
                    Thu = 0,
                    Chi = 0,
                },
                BatHo = new Summary
                {
                    Thu = 0,
                    Chi = 0,
                },
                CamDo = new Summary
                {
                    Thu = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.Camdo).Sum(x => x.TongTienDaThanhToan),
                    Chi = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.Camdo).Sum(x => x.HD_TongTienVayBanDau),
                },
                ChiHoatDong = new Summary
                {
                    Thu = cuahangtranLogs.Where(x => x.FeatureType == Shared.Enums.EFeatureType.Chi).Sum(x => x.MoneySub),
                    Chi = cuahangtranLogs.Where(x => x.FeatureType == Shared.Enums.EFeatureType.Chi).Sum(x => x.MoneyAdd),
                },
                NguonVon = new Summary
                {
                    Thu = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.GopVon).Sum(x => x.TienLaiToiNgayHienTai),
                    Chi = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.GopVon).Sum(x => x.HD_TongTienVayBanDau),
                },
                ThuHoatDong = new Summary
                {
                    Thu = cuahangtranLogs.Where(x => x.FeatureType == Shared.Enums.EFeatureType.Thu).Sum(x => x.MoneySub),
                    Chi = cuahangtranLogs.Where(x => x.FeatureType == Shared.Enums.EFeatureType.Thu).Sum(x => x.MoneyAdd),
                },
                TienMatConLai = new Summary
                {
                    Thu = 0,
                    Chi = 0,
                },
                VayLai = new Summary
                {
                    Thu = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.Vaylai).Sum(x => x.TienLaiToiNgayHienTai),
                    Chi = hopdongs.Where(x => x.HD_Loai == Shared.Enums.ELoaiHopDong.Vaylai).Sum(x => x.HD_TongTienVayBanDau),
                },
            };
            data.TienDauNgay.Total = cuahangQuyTienLogs.Where(x => x.LogType == Shared.Enums.EQuyTienCuaHang_LogType.TienDauNgay).Sum(x => x.Money);
            data.BatHo.Total = data.BatHo.Chi - data.BatHo.Thu;
            data.CamDo.Total = data.CamDo.Chi - data.CamDo.Thu;
            data.ChiHoatDong.Total = data.ChiHoatDong.Chi - data.ChiHoatDong.Thu;
            data.NguonVon.Total = data.NguonVon.Chi - data.NguonVon.Thu;
            data.ThuHoatDong.Total = data.ThuHoatDong.Chi - data.ThuHoatDong.Thu;
            data.TienMatConLai.Total = data.TienMatConLai.Chi - data.TienMatConLai.Thu;
            data.VayLai.Total = data.VayLai.Chi - data.VayLai.Thu;

            return base.Ok(new ApiSuccessResult<ReportBalanceVM>(data));
        }
    }
}
