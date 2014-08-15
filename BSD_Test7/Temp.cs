using BSD_Test7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSD_Test7
{
     public class TempUnitOfWork
    {
        public MyEntityContext Context { get; private set; }

        public TempUnitOfWork(MyEntityContext context)
        {
            Context = context;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }

    public class TempRepository<T> where T : class, IEntity
    {
        private readonly TempUnitOfWork _unitOfWork;

        public TempRepository(TempUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T Create()
        {
            return _unitOfWork.Context.EntitySet<T>().Create();
        }

       
        public T GetById(string id)
        {
            return _unitOfWork.Context.EntitySet<T>().FirstOrDefault(x => x.Id == id);
        }
    }
 }

