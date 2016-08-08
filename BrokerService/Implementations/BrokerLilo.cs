using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerService.Interfaces;
using DataAccessLayer.Interfaces;

namespace BrokerService.Implementations
{
    public class BrokerLilo: IBroker
    {
        private IPersistLots PersistLots { get; set; }

        private IBrokerUtility BrokerUtility { get; set; }

        public BrokerLilo(IPersistLots persistLots, IBrokerUtility brokerUtility)
        {
            PersistLots = persistLots;
            BrokerUtility = brokerUtility;
        }

        public void SellAsset(int quantity)
        {
            var lots = PersistLots.GetLots().OrderByDescending(x => x.TransactionDate);

            BrokerUtility.SellAsset(quantity, lots.ToList());
        }
    }
}
