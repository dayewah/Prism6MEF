using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;

namespace TimeKeep.ViewModels
{
    [Export]
    public class TimeKeepViewModel : BindableBase
    {
        public TimeKeepViewModel()
        {
            this.Name = "TimeKeep View";

        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }

}
