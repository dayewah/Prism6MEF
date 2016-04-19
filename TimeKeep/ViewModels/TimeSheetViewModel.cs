using Common.Data;
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
using TimeKeep.TimeSheets;

namespace TimeKeep.ViewModels
{
    [Export]
    public class TimeSheetViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private TimeSheetService _timeSheetService;
        private EntryEditViewModel _entryViewModels;

        [ImportingConstructor]
        public TimeSheetViewModel(
            IRegionManager regionManager, 
            TimeSheetService timeSheetService)
        {
            _regionManager = regionManager;
            _timeSheetService = timeSheetService;

            this.AddEntryCommand = new DelegateCommand(AddEntry);
        }


        #region Timesheet Properties

        private void Update(TimeSheetDTO timesheetDTO)
        {
            _id = timesheetDTO.Id;
            _name = timesheetDTO.Name;
            _totalHours = timesheetDTO.TotalHours;
            _startTime = timesheetDTO.Period.Start;
            _endTime = timesheetDTO.Period.End;
            this.Entries = new ObservableCollection<Entry>(timesheetDTO.Entries.OrderBy(x => x.Period.Start));
            this.OnPropertyChanged(null);//updates all bindings
        }

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                var dto = _timeSheetService.UpdateName(value);
                this.Update(dto);
            }
        }

        private double _totalHours;
        public double TotalHours
        {
            get { return _totalHours; }
        }

        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                SetProperty(ref _startTime, value);
                var dto = _timeSheetService.UpdatePeriod(new TimePeriod(this.StartTime, this.EndTime - this.StartTime));
                this.Update(dto);
            }
        }

        private DateTime _endTime;
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                SetProperty(ref _endTime, value);
                var dto = _timeSheetService.UpdatePeriod(new TimePeriod(this.StartTime, this.EndTime - this.StartTime));
                this.Update(dto);
            }
        }

        public ObservableCollection<Entry> Entries { get; set; }

        #endregion

        #region Commands

        public DelegateCommand AddEntryCommand { get; private set; } 

        private void AddEntry()
        {
            var arg = new NavigationParameters();
            arg.Add("TimeSheetId", this.Id);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.EntryEditView, arg);
        }

        #endregion

        
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var dto=_timeSheetService.GetTimeSheet();
            this.Update(dto);
        }
    }
}
