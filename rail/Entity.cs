using System;
using System.Collections.Generic;
using System.Text;

namespace rail
{
    public abstract class Entity : IEquatable<Entity>
    {
        public string Id { get; private set; }

        // The default Equals() provides reference equality.  We want entities to use
        // identifier equality.

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id is null || other.Id is null)
                return false;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;
            return Equals(other);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            // Objects that are considered equal should always generate the same hash code.
            return (GetType().ToString() + Id).GetHashCode();
        }

        protected Entity(string id)
        {
            Id = id;
        }
    }
}
