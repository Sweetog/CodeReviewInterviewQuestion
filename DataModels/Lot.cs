using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Lot : BaseEntity
    {
        public DateTime TransactionDate { get; set; }
        public int CurrentQuantity { get; set; }
        public int PricePerShare { get; set; }

        public int OriginalQuantiy { get; set; }
        public override int Id { get; set; }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
