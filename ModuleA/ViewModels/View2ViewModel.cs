using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using Prism.Regions;
using Infrastructure;

namespace ModuleA.ViewModels
{
    [Export]
    public class View2ViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        [ImportingConstructor]
        public View2ViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            this.Name = "Module A - View 2";

            NavigateCommand = new DelegateCommand<string>(Navigate);

        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; set; }

        public void Navigate(string uri)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
        }
    }
}
