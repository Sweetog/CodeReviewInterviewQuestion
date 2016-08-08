using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingService.Interfaces;
using DataAccessLayer.Interfaces;

namespace AccountingService.Implementations
{
    public class CostAccountantLilo: ICostAccountant
    {
        protected IPersistLots PersistanceLots { get; private set; }
        protected ICostAccountantUtility AccountantUtil { get; private set; }

        public CostAccountantLilo(IPersistLots persistLots, ICostAccountantUtility accountantUtil)
        {
            PersistanceLots = persistLots;
            AccountantUtil = accountantUtil;
        }

        public decimal CostBasis()
        {
            var lots = PersistanceLots.GetLots().OrderByDescending(x => x.TransactionDate);

            return AccountantUtil.CostBasis(lots);
        }

        public decimal CostBasisSharesSold()
        {
            return AccountantUtil.CostBasisSharesSold(PersistanceLots.GetLots());
        }
    }
}
