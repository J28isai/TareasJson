using System.Windows;
using TareasJson.ViewModels;

namespace TareasJson.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
