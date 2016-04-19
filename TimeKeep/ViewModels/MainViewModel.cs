using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using Prism.Regions;
using Common.Data;
using TimeKeep.Data;
using TimeKeep.TimeSheets;

namespace TimeKeep.ViewModels
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

            this.Name = "TimeKeep View";
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public TimeSheet Model { get; private set; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            using (var uow = _unitOfWorkFactory.Create<TimeSheetContext>())
            {
                var repository = uow.Repository<TimeSheet>();
                var s = repository.GetAll().FirstOrDefault();
                if (s != null)
                {
                    this.Model = s;
                }
                else
                {
                    this.Model = new TimeSheet();
                    repository.Save(this.Model);
                }

                uow.SaveChanges();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }

}
