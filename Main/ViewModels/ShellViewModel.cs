using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Main.ViewModels
{
    [Export]
    public class ShellViewModel : BindableBase
    {
        public ShellViewModel()
        {

            this.Name = "Shell ViewModel";

        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
