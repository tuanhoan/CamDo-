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
        }
    }
}
