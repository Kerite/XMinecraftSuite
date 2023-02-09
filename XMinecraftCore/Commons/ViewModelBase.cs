using System.ComponentModel;

namespace XMinecraftSuite.Core.Commons
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChangedEventArgs e = new(propertyName);
            this.PropertyChanged?.Invoke(this, e);
        }
    }
}