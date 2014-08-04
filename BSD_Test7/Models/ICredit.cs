using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace BSD_Test7.Models
{
    [Entity("skos:Concept")]
    public interface ICredit : IEntity
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
         [Identifier("ex:credits#")]
        string Id { get; }

        [PropertyType("rdfs:label")]
        string Label { get; set; }

        [InverseProperty("Credit")]
        ICollection<IRole> Role { get; set; }
    }
}
