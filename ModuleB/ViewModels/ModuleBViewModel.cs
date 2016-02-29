using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;

namespace ModuleB.ViewModels
{
    [Export]
    public class ModuleBViewModel : BindableBase
    {
        public ModuleBViewModel()
        {
            this.Name = "Module B View";

        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }

}
