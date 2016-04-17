using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Common.Data;

namespace Main.Models
{
    /// <summary>
    /// Session Object persists the state of the current session
    /// </summary>
    [Export(typeof(ISession))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Session : BindableBase, ISession
    {
        public Session()
        {
            this.CurrentPath = "Prism6MEF.db";
        }


        private string _workingDirectory;
        public string CurrentPath
        {
            get { return _workingDirectory; }
            set { SetProperty(ref _workingDirectory, value); }
        }
    }
}
