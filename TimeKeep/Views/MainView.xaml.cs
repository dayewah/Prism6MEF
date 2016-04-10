using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace TimeKeep.Views
{
    /// <summary>
    /// Interaction logic for TimeKeepView
    /// </summary>
    [Export]
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
