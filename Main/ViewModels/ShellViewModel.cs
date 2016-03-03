using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Regions;
using Prism.Events;
using Infrastructure.Events;

namespace Main.ViewModels
{
    [Export]
    public class ShellViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public ShellViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<MenuToggleEvent>().Subscribe(OnToolToggleEvent);

        }

        private bool _toolContentActive;
        public bool ToolContentActive
        {
            get { return _toolContentActive; }
            set { SetProperty(ref _toolContentActive, value); }
        }

        private void OnToolToggleEvent(MenuToggleEventArgs args)
        {
            this.ToolContentActive = args.IsChecked;
        }
    }
}
