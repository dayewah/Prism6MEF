using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Infrastructure;

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
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(MenuItem));
        }
    }
}