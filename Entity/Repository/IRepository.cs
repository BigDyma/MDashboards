using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public interface IRepository<T>: IDisposable
    {
        IEnumerable<T> GetEntityList();
        T GetEntity(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save(T item);
    }
}
