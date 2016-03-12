using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.DDD
{
    public abstract class Entity
    {
        protected Entity(){}

        public Entity(Guid id)
        {
            this.Id = id;
        }

        public virtual Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(compareTo, null))
                return false;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (GetType() != compareTo.GetType())
                return false;

            if (!IsTransient() && !compareTo.IsTransient() && Id == compareTo.Id)
                return true;

            return false;
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
            return (this.GetType().ToString() + Id).GetHashCode();
        }

        public virtual bool IsTransient()
        {
            return Id == default(Guid);
        }

    }
}
