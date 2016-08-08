using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingService.Interfaces;
using DataModels;

namespace AccountingService.Utility
{
    public class CostAccountantUtility: ICostAccountantUtility
    {
        public decimal CostBasis(IEnumerable<Lot> orderedLots)
        {
            var costBasis = 0.0m;
            var quantity = 0;

            foreach (var lot in orderedLots)
            {
                costBasis += (lot.PricePerShare * lot.CurrentQuantity);
                quantity += lot.CurrentQuantity;
            }

            return costBasis / quantity;
        }

        public decimal CostBasisSharesSold(IEnumerable<Lot> lots)
        {
            var costBasis = 0.0m;
            var quantity = 0.0m;

            foreach (var lot in lots)
            {
                costBasis += (lot.PricePerShare * (lot.OriginalQuantiy - lot.CurrentQuantity));
                quantity += (lot.OriginalQuantiy - lot.CurrentQuantity);
            }

            return costBasis / quantity;
        }
    }
}
