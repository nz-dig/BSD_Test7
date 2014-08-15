using BrightstarDB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSD_Test7.Repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        T Create();
        IEntitySet<T> GetAll();
        T GetById(string id);
        void DeleteObject(T entity);
    }
}
