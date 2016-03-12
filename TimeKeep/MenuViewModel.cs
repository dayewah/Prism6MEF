using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Infrastructure;
using Prism.Events;
using Prism.Regions;

namespace TimeKeep
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MenuViewModel : MenuViewModelBase
    {
        [ImportingConstructor]
        public MenuViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base(regionManager, eventAggregator)
        {
            this.Name = "TK";
            this.Uri = ViewNames.TimeKeepView;
        }


    }
}
