using System;
using System.Diagnostics.CodeAnalysis;

namespace MinhaCasa.Domain.NaoContemplados.Entities
{
    public class Entity : IEquatable<Entity>
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals([AllowNull] Entity other)
        {
            return Id == other.Id;
        }
    }
}
