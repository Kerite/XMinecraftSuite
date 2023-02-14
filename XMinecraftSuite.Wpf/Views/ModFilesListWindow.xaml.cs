using System.Windows;
using XMinecraftSuite.Wpf.ViewModels;

namespace XMinecraftSuite.Wpf.Views
{
    /// <summary>
    /// ModFilesListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ModVersionsListWindow : Window
    {
        public ModVersionsWindowViewModel ViewModel { get; }

        #region Constructors
        public ModVersionsListWindow(string slug)
        {
            InitializeComponent();
            ViewModel = new(slug)
            {
                IsActive = true
            };
            DataContext = ViewModel;
        }
        #endregion
    }
}
