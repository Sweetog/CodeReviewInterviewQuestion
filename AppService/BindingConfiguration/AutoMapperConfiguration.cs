using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDto;
using AutoMapper;

namespace AppService.BindingConfiguration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigureLotMapping();
        }

        private static void ConfigureLotMapping()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DataModels.Lot, AppDto.Models.Lot>());
            Mapper.Initialize(cfg => cfg.CreateMap<AppDto.Models.Lot, DataModels.Lot>());
        }
    }
}
