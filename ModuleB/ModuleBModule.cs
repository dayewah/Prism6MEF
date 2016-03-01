using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Infrastructure;

namespace ModuleB
{
    [ModuleExport(typeof(ModuleBModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ModuleBModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public ModuleBModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ToolRegion, typeof(MenuItem));
        }
    }
}