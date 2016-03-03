using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Infrastructure;
using ModuleA.Views;
using Microsoft.Practices.ServiceLocation;

namespace ModuleA
{
    [ModuleExport(typeof(ModuleAModule), InitializationMode=InitializationMode.WhenAvailable)]
    public class ModuleAModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //Initialize View to Module A
            var menu=ServiceLocator.Current.GetInstance<MenuViewModel>();
            menu.ToolToggleChecked = true;

            _regionManager.RegisterViewWithRegion(RegionNames.ToolRegion, typeof(MenuViewModel));
        }
    }
}