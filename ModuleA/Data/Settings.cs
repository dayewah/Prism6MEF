using Common.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.Data
{
    public class Settings: AggregateRoot
    {
        public Settings()
            :base(Guid.NewGuid())
        {

        }

        public Settings(Guid id, string name,string value)
            :base(id)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }

        public void UpdateName(string name)
        {
            this.Name = name;
        }

        public void UpdateValue(string value)
        {
            this.Value = value;
        }

    }
}
