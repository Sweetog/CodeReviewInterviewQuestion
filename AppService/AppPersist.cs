using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDto.Models;
using AutoMapper;
using DataAccessLayer.Interfaces;
using Ninject;

namespace AppService
{
    public class AppPersist
    {
        private IPersistLots _persistLots { get; set; }

        public AppPersist(IPersistLots persistLots)
        {
            _persistLots = persistLots;
        }

        public void CreateLot(Lot lot)
        {
            _persistLots.CreateLot(Mapper.Map<DataModels.Lot>(lot));
        }
    }
}
