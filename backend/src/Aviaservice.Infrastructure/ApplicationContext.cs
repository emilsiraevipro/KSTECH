using Aviaservice.Domain.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aviaservice.Infrastructure
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Module> Modules => Set<Module>();
    }
}
