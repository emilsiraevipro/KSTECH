using System;
using System.Collections.Generic;
using System.Text;

namespace KSTECH.Domain.Shared
{
    public abstract class Entity<TId> 
    {
        public Entity(TId id) { this.id = id; }
        public TId id { get;  set; }
    }
}
