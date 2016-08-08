using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        void Create(T entity);
        IEnumerable<T> Get();

        void Update(T entity);
    }
}
