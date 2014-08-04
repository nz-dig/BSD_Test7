using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace BSD_Test7.Models
{
    [Entity("arts:Production")]
    public interface IProduction : IEntity
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:productions#")]
        string Id { get; }

        [PropertyType("dct:title")]
        string Title { get; set; }
            
        [InverseProperty("Production")]
        ICollection<IRole> Role { get; set; }

        [PropertyType("arts:performer")]
        ICollection<IPerson> Performers { get; set; }
   
    }

}
