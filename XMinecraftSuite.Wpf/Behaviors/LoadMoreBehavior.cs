using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XMinecraftSuite.Wpf.Behaviors
{
    public class LoadMoreBehavior : Behavior<ScrollViewer>
    {
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public object? CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        #region 方法 Methods
        private void ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalChange <= 0)
                return;
            if (Math.Abs((e.VerticalOffset + e.ViewportHeight) - e.ExtentHeight) < 0.001)
            {
                Command?.Execute(CommandParameter);
            }
        }
        #endregion

        protected override void OnAttached()
        {
            AssociatedObject.ScrollChanged += ScrollChanged;
        }

        #region 依赖属性 DependencyProperties
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            "CommandParameter",
            typeof(object),
            typeof(LoadMoreBehavior));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(LoadMoreBehavior));
        #endregion
    }
}
