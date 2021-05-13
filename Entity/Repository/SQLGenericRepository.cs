using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class SQLGenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _db;
        private bool disposed = false;
        public SQLGenericRepository(ApplicationContext item)
        {
            _db = item;
        }
        public void Create(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
        }

        public void Delete(T item)
        {
            _db.Set<T>().Remove(item);
            _db.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public T GetEntity(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetEntityList()
        {
            return _db.Set<T>().ToList();
        }

        public void Save(T item)
        {
            _db.SaveChanges();
        }

        public void Update(T item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }
        public void Detach(T item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _db.SaveChanges();
        }
    }
}
