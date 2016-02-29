using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace ModuleB.Views
{
    /// <summary>
    /// Interaction logic for ModuleBView
    /// </summary>
    [Export(ViewNames.ModuleBView)]
    public partial class ModuleBView : UserControl
    {
        public ModuleBView()
        {
            InitializeComponent();
        }
    }
}
