using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace XMinecraftSuite.Wpf.Views.UserControls
{
    /// <summary>
    /// HoverableAndSelectableListItem.xaml 的交互逻辑
    /// </summary>
    [ContentProperty("InnerContent")]
    public partial class HoverableAndSelectableListItem : UserControl
    {
        public string Key
        {
            get => (string)GetValue(SelectedKeyProperty);
            set => SetValue(SelectedKeyProperty, value);
        }
        public string SelectedKey
        {
            get => (string)GetValue(KeyProperty);
            set => SetValue(KeyProperty, value);
        }
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandProperty, value);
        }
        public object InnerContent
        {
            get => GetValue(InnerContentProperty);
            set => SetValue(InnerContentProperty, value);
        }
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public HoverableAndSelectableListItem()
        {
            InitializeComponent();
        }

        #region 依赖属性 DependencyProperties
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            nameof(CommandParameter),
            typeof(object),
            typeof(HoverableAndSelectableListItem));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command),
            typeof(ICommand),
            typeof(HoverableAndSelectableListItem),
            new PropertyMetadata(null));

        public static readonly DependencyProperty InnerContentProperty = DependencyProperty.Register(
            nameof(InnerContent),
            typeof(object),
            typeof(HoverableAndSelectableListItem),
            new PropertyMetadata(null));

        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(
            nameof(Key),
            typeof(string),
            typeof(HoverableAndSelectableListItem),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SelectedKeyProperty = DependencyProperty.Register(
            nameof(SelectedKey),
            typeof(string),
            typeof(HoverableAndSelectableListItem),
            new PropertyMetadata(null));
        #endregion
    }
}
