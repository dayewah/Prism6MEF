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
    public class SettingsContext : DbContext, IDbContext
    {
        private string _path;

        public SettingsContext(string path)
        {
            _path = path;
        }

        public DbSet<Settings> Settings { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=" + _path);
        }

        
    }
}
