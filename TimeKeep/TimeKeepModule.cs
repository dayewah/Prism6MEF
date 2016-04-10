using Prism.Modularity;
using Prism.Regions;
using System;
using Prism.Mef.Modularity;
using Infrastructure;
using System.ComponentModel.Composition;
using TimeKeep.ViewModels;

namespace TimeKeep
{
    [ModuleExport(typeof(TimeKeepModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class TimeKeepModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public TimeKeepModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ToolRegion, typeof(MenuViewModel));
        }
    }
}