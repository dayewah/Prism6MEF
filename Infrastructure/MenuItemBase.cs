using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Regions;

namespace Infrastructure
{
    public abstract class MenuItemBase
    {
        private IRegionManager _regionManager;
        public MenuItemBase(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            this.NavigateCommand = new DelegateCommand(Navigate, CanNavigate);
        }

        public string Name { get; set; }

        protected string Uri { get; set; }

        public DelegateCommand NavigateCommand { get; set; }

        public void Navigate()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, this.Uri);
        }

        public bool CanNavigate()
        {
            return !string.IsNullOrEmpty(this.Uri);
        }

        
    }
}
