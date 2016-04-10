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
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RegionMemberLifetime(KeepAlive = false)]
    public class MainViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private UnitOfWorkFactory _unitOfWorkFactory;

        [ImportingConstructor]
        public MainViewModel(IRegionManager regionManager, UnitOfWorkFactory unitOfWorkFactory)
        {
            _regionManager = regionManager;
            _unitOfWorkFactory = unitOfWorkFactory;

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

        #region Navigation

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
            

            using (var uow=_unitOfWorkFactory.Create<SettingsContext>())
            {
                var s = uow.Repository<Settings>().GetAll().FirstOrDefault();
                if (s != null)
                {
                    this.Id = s.Id;
                    this.SettingName = s.Name;
                    this.SettingValue = s.Value;
                }
            }
            
            
        }

        #endregion

        #region Model Properties

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

        #endregion

        #region Commands

        public DelegateCommand SubmitCommand { get; set; }

        public void Submit()
        {
            using (var uow = _unitOfWorkFactory.Create<SettingsContext>())
            {
                var id = this.Id == default(Guid) ? Guid.NewGuid() : this.Id;
                var s = new Settings(id, this.SettingName, this.SettingValue);
                uow.Repository<Settings>().Save(s);
                uow.SaveChanges();
            }
            
        }

        public bool CanSubmit()
        {
            return true;
        }

        #endregion
    }
}
