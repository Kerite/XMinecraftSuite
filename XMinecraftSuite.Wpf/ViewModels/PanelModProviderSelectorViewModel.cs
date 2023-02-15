using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace XMinecraftSuite.Wpf.ViewModels;

public partial class PanelModProviderSelectorViewModel : ObservableRecipient
{
    #region ObservableProperties
    [ObservableProperty] private string selectedProvider = "modrinth";
    #endregion

    partial void OnSelectedProviderChanged(string value)
    {
        WeakReferenceMessenger.Default.Send(value);
    }
}
