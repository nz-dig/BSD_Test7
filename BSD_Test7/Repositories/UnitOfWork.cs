using BrightstarDB.EntityFramework;
using BSD_Test7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSD_Test7.Repositories
{  
    public class UnitOfWork: IUnitOfWork
    {
        private IDbContext _context;
        private Dictionary<Type, object> dictionary;
        public IDbContext Context { get { return _context; } private set {_context = value;} }
        
        public UnitOfWork(IDbContext context)
        {
            _context = context;
            dictionary = new Dictionary<Type, object>();
        }
         // private BrightstarEntityContext _context;


        //public UnitOfWork(BrightstarEntityContext context)
        //{
        //    _context = context;
        //}

        //public BrightstarEntityContext Context { get { return _context; } private set { _context = value; } }

        public IBaseRepository<T> GetRepository<T>() where T :  IEntity
        {
            //TODO - add locking
            if (dictionary.ContainsKey(typeof(T)))
            {
                return (BaseRepository<T>)dictionary[typeof(T)];
            }
            
            var rep = new BaseRepository<T>(this);
            dictionary[typeof(T)] = rep;
            return rep;
          
          
           
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
