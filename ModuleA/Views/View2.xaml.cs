using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for View2
    /// </summary>
    [Export(ViewNames.View2)]
    public partial class View2 : UserControl
    {
        public View2()
        {
            InitializeComponent();
        }
    }
}
