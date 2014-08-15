using BrightstarDB.EntityFramework;
using BSD_Test7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSD_Test7.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T :  IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
       // internal IEntitySet<T> dbSet;

        
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            //this.dbSet = _unitOfWork.Context.Set<T>();
        }

        public void Add(T entity)
        {
            //dbSet.Add(entity);
            _unitOfWork.Context.EntitySet<T>().Add(entity);
        }

        public T Create()
        {
            //dbSet.Add(entity);
            return _unitOfWork.Context.EntitySet<T>().Create();
        }

        public IEntitySet<T> GetAll()
        {
            return _unitOfWork.Context.EntitySet<T>(); 
        }

        public T GetById(string id)
        {
            return _unitOfWork.Context.EntitySet<T>().FirstOrDefault(x => x.Id == id);
            //return _unitOfWork.Context.EntitySet<T>().FirstOrDefault(x => x.Id.Equals(id));
            //return _unitOfWork.Context.GetById<T>(id);
        }

        public  void DeleteObject(T entity)
        {
            _unitOfWork.Context.DeleteObject(entity);
        }
    }
}
