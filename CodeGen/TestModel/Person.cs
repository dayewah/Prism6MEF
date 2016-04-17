using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGen.State;

namespace CodeGen.TestModel
{
    [GenerateState]
    public class Person
    {
        public Person()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Address HomeAddress { get; set; }
    }
}
