using System.Windows;
using System.Windows.Controls;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Wpf.ViewModels;

namespace XMinecraftSuite.Wpf.UserControls;

/// <summary>
/// ModDetailUserControl.xaml 的交互逻辑
/// </summary>
public partial class ModDetailUserControl : UserControl
{
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
        nameof(ViewModel),
        typeof(AbstractModDetails),
        typeof(ModDetailUserControl)
    );

    public AbstractModDetails ViewModel
    {
        get => (AbstractModDetails)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }

    public ModDetailUserControl()
    {
        InitializeComponent();
    }
}
