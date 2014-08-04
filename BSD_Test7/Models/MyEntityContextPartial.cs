using BrightstarDB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSD_Test7.Models
{
    public partial class MyEntityContext : IDbContext
    {
        public IEntitySet<T> Set<T>()
        {
            if (typeof(T).Equals(typeof(ICharacter)))
            {
                return (IEntitySet<T>)this.Characters;
            }
            if (typeof(T).Equals(typeof(ICredit)))
            {
                return (IEntitySet<T>)this.Credits;
            }
            if (typeof(T).Equals(typeof(IPerson)))
            {
                return (IEntitySet<T>)this.Persons;
            }
            if (typeof(T).Equals(typeof(IProduction)))
            {
                return (IEntitySet<T>)this.Productions;
            }
            if (typeof(T).Equals(typeof(IRole)))
            {
                return (IEntitySet<T>)this.Roles;
            }

            throw new NotImplementedException();
         
        }
        
    }

    public interface IDbContext: IDisposable
    {
        IEntitySet<T> Set<T>();
        void SaveChanges();

    }
}
