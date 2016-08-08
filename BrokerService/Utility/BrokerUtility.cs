using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerService.Interfaces;
using DataAccessLayer.Interfaces;
using DataModels;

namespace BrokerService.Utility
{
    public class BrokerUtility: IBrokerUtility
    {
        private IPersistLots _persistLots { get; set; }

        public BrokerUtility(IPersistLots persistLots)
        {
            _persistLots = persistLots;
        }

        public void SellAsset(int quantity, List<Lot> orderLot)
        {
            var firstLot = orderLot.FirstOrDefault();

            if (firstLot == null)
            {
                return;
            }

            //increase speed of loop by checking if first lot is only lot being iterated through
            if (firstLot.CurrentQuantity > quantity)
            {
                firstLot.CurrentQuantity -= quantity;

                _persistLots.UpdateLot(firstLot);
            }
            else
            {
                //iterate through the rest of the lots, skpping first
                foreach (var lot in orderLot)
                {
                    var temp = lot.CurrentQuantity;

                    lot.CurrentQuantity -= quantity;
                    quantity -= temp;

                    if (lot.CurrentQuantity < 0)
                    {
                        lot.CurrentQuantity = 0;
                    }

                    _persistLots.UpdateLot(lot);

                    //we have sold all shares, quantity to sell could be greater than 0 but that is alright no shares left to sell
                    if (quantity <= 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
