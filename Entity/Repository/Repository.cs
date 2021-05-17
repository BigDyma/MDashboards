using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Repository
{
    public class Repository<T> : SQLGenericRepository<T> where T : EntityBase
    {
        public Repository(ApplicationContext item) : base(item)
        {
        }
    }
}
