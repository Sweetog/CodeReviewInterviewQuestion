using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDto.Models;
using AutoMapper;
using BrokerService.Interfaces;
using DataAccessLayer.Implementations.Persist;
using DataAccessLayer.Interfaces;

namespace BrokerService.Implementations
{
    public class BrokerFifo : IBroker
    {
        private IPersistLots PersistLots { get; set; }

        private IBrokerUtility BrokerUtility { get; set; }

        public BrokerFifo(IPersistLots persistLots, IBrokerUtility brokerUtility)
        {
            PersistLots = persistLots;
            BrokerUtility = brokerUtility;
        }

        public void SellAsset(int quantity)
        {
            var lots = PersistLots.GetLots().OrderBy(x => x.TransactionDate);

            BrokerUtility.SellAsset(quantity, lots.ToList());
        }
    }
}
