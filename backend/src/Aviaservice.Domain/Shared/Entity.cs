using System;
using System.Collections.Generic;
using System.Text;

namespace Aviaservice.Domain.Shared
{
    public abstract class Entity<TId> where TId : notnull 
    { 
        protected Entity(TId id) { id = id; }
        public TId id { get; private set; }
    }
}
