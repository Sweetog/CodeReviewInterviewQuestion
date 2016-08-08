using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace AccountingService.Interfaces
{
    public interface ICostAccountantUtility
    {
        decimal CostBasis(IEnumerable<Lot> orderedLots);
        decimal CostBasisSharesSold(IEnumerable<Lot> lots);
    }
}
