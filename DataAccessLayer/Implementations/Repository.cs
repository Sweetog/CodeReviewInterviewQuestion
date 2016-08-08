using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataAccessLayer.Interfaces;
using DataModels;

namespace DataAccessLayer.Implementations
{
    public class Repository<T>: IRepository<T> where T:BaseEntity
    {
        //repository currently knows and causes the datastore to be List but this can be changed to EntityFramework with SQL or MySQL database or MongoDB etc.
        private IEnumerable<T> _entities = new List<T>().AsEnumerable();

        public void Create(T entity)
        {
            var entityList = _entities.ToList();
            var lastId = 0;

            if (entityList.Any())
                lastId = entityList.Max(x => x.Id);

            entity.Id = ++lastId;

            entityList.Add(entity);

            _entities = entityList.AsEnumerable();
        }

        public IEnumerable<T> Get()
        {
            return _entities.ToList().Clone();
        }

        public void Update(T entity)
        {
            //var entityList = _entities;
            var e = _entities.FirstOrDefault(x => x.Id == entity.Id);

            if (e == null)
                return;

            var entityList = _entities.ToList();
            var indexOf = entityList.IndexOf(e);

            entityList.RemoveAt(indexOf);

            entityList.Insert(indexOf,entity);

            _entities = entityList.AsEnumerable();
        }
    }
}
