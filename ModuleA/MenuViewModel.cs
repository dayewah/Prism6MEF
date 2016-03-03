using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Prism.Events;
using Prism.Regions;

namespace ModuleA
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MenuViewModel: MenuViewModelBase
    {
        [ImportingConstructor]
        public MenuViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base(regionManager, eventAggregator)
        {
            this.Name = "MA";
            this.Uri = ViewNames.ModuleAView;
        }

        
    }
}
