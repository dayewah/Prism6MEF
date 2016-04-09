using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using Prism.Regions;

namespace TimeKeep.ViewModels
{
    [Export]
    public class MainViewModel : BindableBase
    {
        [ImportingConstructor]
        public MainViewModel(IRegionManager regionManager)
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
