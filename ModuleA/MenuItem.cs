using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Prism.Regions;

namespace ModuleA
{
    [Export]
    public class MenuItem: MenuItemBase
    {
        [ImportingConstructor]
        public MenuItem(IRegionManager regionManager)
            : base(regionManager)
        {
            this.Name = "MA";
            this.Uri = ViewNames.ModuleAView;
        }

        
    }
}
