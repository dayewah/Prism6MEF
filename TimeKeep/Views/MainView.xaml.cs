using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace TimeKeep.Views
{
    /// <summary>
    /// Interaction logic for TimeKeepView
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)] //this is important if you want the view to be created each time it is navigated to.
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
