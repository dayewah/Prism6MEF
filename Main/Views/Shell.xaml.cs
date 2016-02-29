using System.Windows;
using System.ComponentModel.Composition;
using MahApps.Metro.Controls;

namespace Main.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export]
    public partial class Shell : MetroWindow
    {
        public Shell()
        {
            InitializeComponent();
        }
    }
}
