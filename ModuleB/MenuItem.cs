using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Prism.Regions;

namespace ModuleB
{
    [Export]
    public class MenuItem: MenuItemBase
    {
        [ImportingConstructor]
        public MenuItem(IRegionManager regionManager)
            : base(regionManager)
        {
            this.Name = "MB";
            this.Uri = ViewNames.ModuleBView;
        }

        
    }
}
