using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Gui.ViewModels;

public partial class ModDetailsViewModel : ObservableRecipient,
    IRecipient<GuiMessages.ModSelectedMessage>,
    IRecipient<GuiMessages.ModProviderSelectedMessage>
{
    private string? ModProvider = "modrinth";

    [ObservableProperty]
    private AbstractModDetails? modDetail;

    [ObservableProperty]
    private bool reset;

    public void Receive(GuiMessages.ModProviderSelectedMessage message)
    {
        ModProvider = message.Provider;
    }

    public async void Receive(GuiMessages.ModSelectedMessage message)
    {
        var provider = GlobalModProviderProxy.Instance[ModProvider];
        if (provider != null) { ModDetail = await provider.GetModDetailAsync(message.ModSlug); }
    }
}
