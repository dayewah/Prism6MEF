using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using Prism.Regions;
using Infrastructure;
using Common.Data;

namespace ModuleA.ViewModels
{
    [Export]
    public class ModuleAViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;

        [ImportingConstructor]
        public ModuleAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            

            this.Name = "Module A View";

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

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
