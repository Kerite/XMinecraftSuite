using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace XMinecraftSuite.Gui.ViewModels;

public partial class PanelModProviderSelectorViewModel : ObservableRecipient
{
    [ObservableProperty]
    private string selectedProvider = "modrinth";

    partial void OnSelectedProviderChanged(string value)
    {
        WeakReferenceMessenger.Default.Send(value);
    }
}
