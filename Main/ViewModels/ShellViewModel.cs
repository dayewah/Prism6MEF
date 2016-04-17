using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Regions;
using Prism.Events;
using Infrastructure.Events;
using Common.Data;
using Common.Dialog;

namespace Main.ViewModels
{
    [Export]
    public class ShellViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private ISession _session;
        private IDialogService _dialogService;

        [ImportingConstructor]
        public ShellViewModel(
            IRegionManager regionManager, 
            IEventAggregator eventAggregator,
            ISession session,
            IDialogService dialogService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _session = session;
            _dialogService = dialogService;

            this.OpenCommand = new DelegateCommand(Open, CanOpen);

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

        public DelegateCommand OpenCommand { get; private set; }

        public void Open()
        {
            var path=_dialogService.GetOpenFileDialog("Open", "");
            _session.CurrentPath = path;
        }

        public bool CanOpen()
        {
            return true;
        }
        
    }
}
