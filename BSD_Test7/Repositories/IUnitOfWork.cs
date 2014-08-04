using BrightstarDB.EntityFramework;
using BSD_Test7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSD_Test7.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IBaseRepository<T> GetRepository<T>() where T : IEntity;
        IDbContext Context { get; } 
        //BrightstarEntityContext Context { get; private set; }
        void SaveChanges();
    }
}
