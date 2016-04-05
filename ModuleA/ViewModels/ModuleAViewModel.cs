using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using Prism.Regions;
using Infrastructure;
using Common.Data;
using ModuleA.Data;

namespace ModuleA.ViewModels
{
    [Export]
    public class ModuleAViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private IUnitOfWork _unitOfWork;

        [ImportingConstructor]
        public ModuleAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            this.Name = "Module A View";

            NavigateCommand = new DelegateCommand<string>(Navigate);
            SubmitCommand = new DelegateCommand(Submit);
            

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
            _unitOfWork.Save();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var context = new SettingsContext();
            context.Database.EnsureCreated();
            _unitOfWork = new UnitOfWork(context);
            var s=_unitOfWork.Repository<Settings>().GetAll().FirstOrDefault();

            if (s != null)
            {
                this.Id = s.Id;
                this.SettingName = s.Name;
                this.SettingValue = s.Value;
            }
            
        }

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string _settingName;
        public string SettingName
        {
            get { return _settingName; }
            set { SetProperty(ref _settingName, value); }
        }

        private string _settingValue;
        public string SettingValue
        {
            get { return _settingValue; }
            set { SetProperty(ref _settingValue, value); }
        }


        public DelegateCommand SubmitCommand { get; set; }

        public void Submit()
        {
            var s = _unitOfWork.Repository<Settings>().GetById(this.Id);

            var id = s == null ? Guid.NewGuid() : this.Id;

            s = new Settings(id, this.SettingName, this.SettingValue);
            
            _unitOfWork.Repository<Settings>().Save(s);
        }

        public bool CanSubmit()
        {
            return true;
        }
        
    }
}
