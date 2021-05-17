using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IRepository<T>: IDisposable
    {
        IEnumerable<T> GetEntityList();
        Task<T> GetEntity(long id);
        Task Create(T item);
        void Update(T item);
        Task Delete(T item);
        Task Save();
    }
}
