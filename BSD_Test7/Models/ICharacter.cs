using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace BSD_Test7.Models
{
    [Entity("arts:Character")]
    public interface ICharacter : IEntity
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:character#")]
        string Id { get; }

        [PropertyType("foaf:name")]
        string Name { get; set; }

        [InverseProperty("Character")]
        ICollection<IRole> Role { get; set; }
    }
}
