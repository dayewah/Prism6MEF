﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Regions;
using Prism.Events;

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

            this.Name = "Shell ViewModel";
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
            _regionManager.RequestNavigate("MainRegion", uri);
        }

        
    }
}