using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataModels;

namespace DataAccessLayer.Implementations.Persist
{
    public class PersistLots : IPersistLots
    {
        private IRepository<Lot> _db { get;  set;  }

        public PersistLots(IRepository<Lot> repository)
        {
            _db = repository;
        }

        public void CreateLot(Lot lot)
        {
            lot.OriginalQuantiy = lot.CurrentQuantity;
           _db.Create(lot);
        }

        public IEnumerable<Lot> GetLots()
        {
            return _db.Get();
        }

        public void UpdateLot(Lot lot)
        {
            _db.Update(lot);
        }
    }
}
