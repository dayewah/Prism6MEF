﻿using Main.Views;
using Microsoft.Practices.ServiceLocation;
using Prism.Mef;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModuleA;
using ModuleB;
using TimeKeep;

namespace Main
{
    public class BootStrapper: MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<Shell>();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(
                 new AssemblyCatalog(typeof(BootStrapper).Assembly));

            this.AggregateCatalog.Catalogs.Add(
                 new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory));
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        
    }
}
