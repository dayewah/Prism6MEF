using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGen.State;

namespace CodeGen.TestModel
{
    [GenerateState]
    public class Order
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public Address CustomerAddress { get; set; }
    }
}
