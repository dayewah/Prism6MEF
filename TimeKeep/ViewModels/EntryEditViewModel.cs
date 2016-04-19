using Infrastructure;
using Models.DDD.TimeSheets.Entries;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeep.Services;

namespace TimeKeep.ViewModels
{
    [Export]
    public class EntryEditViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private EntryService _entryService;
        private Guid _timeSheetId;
        private Guid _entryId;

        [ImportingConstructor]
        public EntryEditViewModel(IRegionManager regionManager,EntryService entryService)
        {
            _regionManager = regionManager;
            _entryService = entryService;
            this.SubmitCommand = new DelegateCommand(Submit);
        }

        private int _projectNumber;
        public int ProjectNumber
        {
            get { return _projectNumber; }
            set { SetProperty(ref _projectNumber, value); }
        }

        private DateTime _start;
        public DateTime Start
        {
            get { return _start; }
            set { SetProperty(ref _start, value); }
        }

        private DateTime _end;
        public DateTime End
        {
            get { return _end; }
            set { SetProperty(ref _end, value); }
        }

        private double _hours;

        public double Hours
        {
            get { return _hours; }
            set { SetProperty(ref _hours, value); }
        }

        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
        }
        public DelegateCommand SubmitCommand { get; private set; } 

        public void Submit()
        {
            _entryService.EnterHours(this.ProjectNumber, this.Hours, 0, this.Comment);

            _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.TimeKeepView);
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
            //not needed
            _timeSheetId =(Guid)navigationContext.Parameters["TimeSheetId"];

        }
    }
}
