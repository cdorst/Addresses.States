// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using DevOps.Code.Entities.Interfaces.StaticEntity;
using Position = ProtoBuf.ProtoMemberAttribute;
using ProtoBufSerializable = ProtoBuf.ProtoContractAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Addresses.States
{
    /// <summary>Contains US State component of addresses</summary>
    [ProtoBufSerializable]
    [Table("States", Schema = "Addresses")]
    public class State : IStaticEntity<State, int>
    {
        public State()
        {
        }

        public State(string abbreviation, string name)
        {
            Abbreviation = abbreviation;
            Name = name;
        }

        /// <summary>Contains Abbreviation value</summary>
        [Position(2)]
        public string Abbreviation { get; set; }

        /// <summary>Contains Name value</summary>
        [Position(3)]
        public string Name { get; set; }

        /// <summary>State unique identifier (primary key)</summary>
        [Key]
        [Position(1)]
        public int StateId { get; set; }

        /// <summary>Returns a value that uniquely identifies this entity type. Each entity type in the model has a unique identifier</summary>
        public int GetEntityType() => 1;

        /// <summary>Returns the entity's unique identifier</summary>
        public int GetKey() => StateId;

        /// <summary>Returns an expression defining this entity's unique index (alternate key)</summary>
        public Expression<Func<State, object>> GetUniqueIndex() => entity => new { entity.Abbreviation, entity.Name };
    }
}
