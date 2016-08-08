using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingService.Interfaces
{
    public interface ICostAccountant
    {
        decimal CostBasis();

        decimal CostBasisSharesSold();
    }
}
