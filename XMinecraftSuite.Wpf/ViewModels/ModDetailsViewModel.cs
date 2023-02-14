using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Wpf.Messages;

namespace XMinecraftSuite.Wpf.ViewModels
{
    public partial class ModDetailsViewModel : ObservableRecipient, IRecipient<ModSelectedMessage>, IRecipient<ModProviderSelectedMessage>
    {
        #region ObservableProperties
        [ObservableProperty]
        private AbstractModDetails? modDetail;

        [ObservableProperty]
        private bool reset;
        #endregion

        public async void Receive(ModSelectedMessage message)
        {
            var provider = GlobalModProviderProxy.Instance[ModProvider];
            if (provider != null)
            {
                ModDetail = await provider.GetModDetailAsync(message.ModSlug);
            }
        }

        public void Receive(ModProviderSelectedMessage message)
        {
            ModProvider = message.Provider;
        }

        private string? ModProvider = "modrinth";
    }
}
