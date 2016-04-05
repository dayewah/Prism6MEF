using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data;
using Microsoft.Data.Entity;

namespace ModuleA.Data
{
    public class SettingsContext : DbContext, IDbContext
    {
        public DbSet<Settings> Settings { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ModuleA.db");
        }

        
    }
}
