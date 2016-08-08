using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace BrokerService.Interfaces
{
    public interface IBrokerUtility
    {
        void SellAsset(int quantity, List<Lot> orderLot);
    }
}
