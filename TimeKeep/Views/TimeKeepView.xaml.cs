using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace TimeKeep.Views
{
    /// <summary>
    /// Interaction logic for TimeKeepView
    /// </summary>
    [Export(ViewNames.TimeKeepView)]
    public partial class TimeKeepView : UserControl
    {
        public TimeKeepView()
        {
            InitializeComponent();
        }
    }
}
