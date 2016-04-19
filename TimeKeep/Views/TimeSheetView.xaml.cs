using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace TimeKeep.Views
{
    /// <summary>
    /// Interaction logic for TimeSheetView
    /// </summary>
    [Export]
    public partial class TimeSheetView : UserControl
    {
        public TimeSheetView()
        {
            InitializeComponent();
        }
    }
}
