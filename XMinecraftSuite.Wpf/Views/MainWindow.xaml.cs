using System.Windows;
using XMinecraftSuite.Wpf.ViewModels;

namespace XMinecraftSuite.Wpf.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; } = new MainWindowViewModel();

        #region Constructors
        //Constructors
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
        #endregion
    }
}
