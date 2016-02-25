using System.Windows;
using System.ComponentModel.Composition;

namespace Main.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export]
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
        }
    }
}
