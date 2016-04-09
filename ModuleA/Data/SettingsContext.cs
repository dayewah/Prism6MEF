using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data;
using Microsoft.Data.Entity;

namespace ModuleA.Data
{
    [Export(typeof(IDbContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SettingsContext : DbContext, IDbContext
    {
        public DbSet<Settings> Settings { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ModuleA.db");
        }

        
    }
}
