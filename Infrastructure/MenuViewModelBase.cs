using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Infrastructure
{
    public abstract class MenuViewModelBase: BindableBase
    {
        protected IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        public MenuViewModelBase(IRegionManager regionManager, IEventAggregator eventaggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventaggregator;

            _eventAggregator
                .GetEvent<MenuToggleEvent>()
                .Subscribe(OnToolToggleEvent,ThreadOption.PublisherThread,false,x=>(int)x.Sender!=this.GetHashCode() && x.IsChecked==true);
        }

        private void OnToolToggleEvent(MenuToggleEventArgs isChecked)
        {
            //Toggle off for all MenuViewModels except the caller on that raised the MenuToggleEvent
            _toolToggleChecked = false;
            this.OnPropertyChanged(() => this.ToolToggleChecked);
        }

        public string Name { get; set; }

        protected string MainUri { get; set; }

        private bool _toolToggleChecked;
        public bool ToolToggleChecked
        {
            get { return _toolToggleChecked; }
            set 
            { 
                SetProperty(ref _toolToggleChecked, value);

                var arg = new MenuToggleEventArgs(this.GetHashCode(), _toolToggleChecked);
                _eventAggregator.GetEvent<MenuToggleEvent>().Publish(arg);

                if (this.ToolToggleChecked)
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, this.MainUri);
                
            }
        }

    }
}
