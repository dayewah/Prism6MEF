using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ModuleAView
    /// </summary>
    [Export(ViewNames.ModuleAView)]
    public partial class ModuleAView : UserControl
    {
        public ModuleAView()
        {
            InitializeComponent();
        }
    }
}
