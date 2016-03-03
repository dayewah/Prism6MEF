using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace Infrastructure.Events
{
    public class MenuToggleEvent : PubSubEvent<MenuToggleEventArgs> { }

    public class MenuToggleEventArgs
    {
        public MenuToggleEventArgs(object sender, bool isChecked)
        {
            this.Sender = sender;
            this.IsChecked = isChecked;
        }
        public object Sender { get; private set; }
        public bool IsChecked { get; private set; }
    }
}
