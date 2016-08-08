using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataAccessLayer.Interfaces
{
    public interface IPersistLots
    {
        void CreateLot(Lot lot);

        IEnumerable<Lot> GetLots();

        void UpdateLot(Lot lot);
    }
}
