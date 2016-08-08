using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public abstract class BaseEntity: ICloneable
    {
        public abstract int Id { get; set; }
        public abstract object Clone();
    }
}
