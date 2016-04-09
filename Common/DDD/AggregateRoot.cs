using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DDD
{
    public abstract class AggregateRoot : Entity
    {
        //private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        //public IReadOnlyList<IDomainEvent> DomainEvents { get { return _domainEvents; } }

        protected AggregateRoot()
            : base(Guid.NewGuid()) { }

        public AggregateRoot(Guid id)
            : base(id)
        {

        }
        //protected virtual void AddDomainEvent(IDomainEvent newEvent)
        //{
        //    _domainEvents.Add(newEvent);
        //}

        //public virtual void ClearEvents()
        //{
        //    _domainEvents.Clear();
        //}
    }
}
