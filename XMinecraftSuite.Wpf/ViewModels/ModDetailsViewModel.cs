using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Wpf.Messages;

namespace XMinecraftSuite.Wpf.ViewModels;

public partial class ModDetailsViewModel : ObservableRecipient,
    IRecipient<ModSelectedMessage>,
    IRecipient<ModProviderSelectedMessage>
{
    private string? ModProvider = "modrinth";

    public void Receive(ModProviderSelectedMessage message)
    {
        ModProvider = message.Provider;
    }

    public async void Receive(ModSelectedMessage message)
    {
        var provider = GlobalModProviderProxy.Instance[ModProvider];
        if (provider != null) ModDetail = await provider.GetModDetailAsync(message.ModSlug);
    }

    #region ObservableProperties
    [ObservableProperty] private AbstractModDetails? modDetail;

    [ObservableProperty] private bool reset;
    #endregion
}
