using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace BSD_Test7.Models
{
    [Entity("arts:Role")]
    public interface IRole: IEntity
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        string Id { get; }

        [PropertyType("arts:contribution")]
        IProduction Production { get; set; }

        [PropertyType("arts:portrayal")]
        ICharacter Character { get; set; }

        [PropertyType("arts:credit")]
        ICredit Credit { get; set; }

         [InverseProperty("Roles")]
        ICollection<IPerson> PerformedBy { get; set; }
    }
}
