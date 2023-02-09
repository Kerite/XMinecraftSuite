using System.Windows;
using XMinecraftSuite.Wpf.ViewModels;

namespace XMinecraftSuite.Wpf.Windows
{
    /// <summary>
    /// ModFilesListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ModFilesListWindow : Window
    {
        public readonly ModFilesViewModel ViewModel;

        public ModFilesListWindow(string slug)
        {
            InitializeComponent();
            ViewModel = new ModFilesViewModel(slug);
            this.DataContext = ViewModel;
        }
    }
}