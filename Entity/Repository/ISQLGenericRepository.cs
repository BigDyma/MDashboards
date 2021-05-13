using System.Collections.Generic;

namespace Entity
{
    interface ISQLGenericRepository<T> where T : class
    {
        void Create(T item);
        void Delete(T item);
        void Detach(T item);
        void Dispose();
        void Dispose(bool disposing);
        T GetEntity(int id);
        IEnumerable<T> GetEntityList();
        void Save(T item);
        void Update(T item);
    }
}