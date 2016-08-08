using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingService.Interfaces;
using DataAccessLayer.Implementations.Persist;
using DataAccessLayer.Interfaces;

namespace AccountingService.Implementations
{
    public class CostAccountantFifo: ICostAccountant
    {
        protected IPersistLots PersistanceLots { get; private set; }
        protected ICostAccountantUtility AccountantUtil { get; private set; }

        public CostAccountantFifo(IPersistLots persistLots, ICostAccountantUtility accountantUtil)
        {
            PersistanceLots = persistLots;
            AccountantUtil = accountantUtil;
        }

        public decimal CostBasis()
        {
            var lots = PersistanceLots.GetLots().OrderBy(x => x.TransactionDate);

            return AccountantUtil.CostBasis(lots);
        }

        public decimal CostBasisSharesSold()
        {
            return AccountantUtil.CostBasisSharesSold(PersistanceLots.GetLots());
        }
    }
}
