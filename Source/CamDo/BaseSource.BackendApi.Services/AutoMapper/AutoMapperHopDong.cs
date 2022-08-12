using AutoMapper;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.AutoMapper
{
    public class AutoMapperHopDong : Profile
    {
        public AutoMapperHopDong()
        {
            CreateMap<CreateHopDongVm, HopDong>();
            CreateMap<CreateHopDongGopVonVm, HopDong>();
            CreateMap<HopDong, HopDongVm>();
            CreateMap<EditHopDongVm, HopDong>()
             .ForMember(dest => dest.UpdatedDate, options => options.MapFrom(source => DateTime.Now))
             .ForMember(dest => dest.KhachHangId, options => options.MapFrom(source => source.KhachHangId));

            CreateMap<EditHopDongGopVonVm, HopDong>()
              .ForMember(dest => dest.TenTaiSan, options => options.UseDestinationValue())
              .ForMember(dest => dest.HD_Ma, options => options.UseDestinationValue())
             .ForMember(dest => dest.UpdatedDate, options => options.MapFrom(source => DateTime.Now));

            CreateMap<HopDongVm, KhachHang>().ForMember(des => des.Ten, act => act.MapFrom(src => src.TenKhachHang));
        }
    }
}
