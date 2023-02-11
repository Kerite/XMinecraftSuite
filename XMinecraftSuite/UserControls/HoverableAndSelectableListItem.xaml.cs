using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XMinecraftSuite.Wpf.UserControls
{
    /// <summary>
    /// HoverableAndSelectableListItem.xaml 的交互逻辑
    /// </summary>
    [ContentProperty("InnerContent")]
    public partial class HoverableAndSelectableListItem : UserControl
    {
        public object InnerContent
        {
            get => GetValue(InnerContentProperty);
            set => SetValue(InnerContentProperty, value);
        }

        public static readonly DependencyProperty InnerContentProperty =
            DependencyProperty.Register(nameof(InnerContent), typeof(object), typeof(HoverableAndSelectableListItem),
                new PropertyMetadata(null));

        public HoverableAndSelectableListItem()
        {
            InitializeComponent();
        }
    }
}