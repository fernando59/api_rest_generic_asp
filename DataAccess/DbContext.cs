using ApiRestGenerica.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : IEntity
    {
        IList<T> _data;
        public DbContext()
        {
            _data = new List<T>();
        }

        public void Delete(int id)
        {
            var e = _data.Where(item => item.Id.Equals(id)).FirstOrDefault();
            if (e != null) _data.Remove(e);


        }

        public IList<T> GetAll()
        {
            return _data;
        }

        public T GetById(int id)
        {
            return _data.Where(item => item.Equals(id)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            if (entity.Id.Equals(0))
            {
                _data.Add(entity);
            }
            return entity;
        }
    }
}
