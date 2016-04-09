using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Main.Models
{
    /// <summary>
    /// Session Object persists the state of the current session
    /// </summary>
    [Export]
    public class Session : BindableBase
    {
        public Session()
        {

        }


        private string _workingDirectory;
        public string WorkingDirectory
        {
            get { return _workingDirectory; }
            set { SetProperty(ref _workingDirectory, value); }
        }
    }
}
