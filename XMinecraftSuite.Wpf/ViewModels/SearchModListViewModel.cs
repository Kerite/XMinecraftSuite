using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Wpf.Messages;

namespace XMinecraftSuite.Wpf.ViewModels
{
    public partial class SearchModListViewModel : ObservableRecipient, IRecipient<ModProviderSelectedMessage>
    {
        public ObservableCollection<AbstractModSearchResult> ModSearchResults { get; set; } = new();

        #region Constructors
        public SearchModListViewModel()
        {
            _ = Search();
        }
        #endregion

        #region 可观测属性 ObservableProperties
        [ObservableProperty]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string providerKey = "modrinth";

        [ObservableProperty]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string searchKeyWord = string.Empty;

        [ObservableProperty]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string selectedSlug = string.Empty;

        [ObservableProperty]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool reset = false;

        [ObservableProperty]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [NotifyCanExecuteChangedFor(nameof(SearchCommand))]
        private bool searching = false;
        #endregion

        public void Receive(ModProviderSelectedMessage message)
        {
            ProviderKey = message.Provider;
        }

        private bool CanSearch()
        {
            return !Searching;
        }

        partial void OnSelectedSlugChanged(string value)
        {
            WeakReferenceMessenger.Default.Send(new ModSelectedMessage(value));
        }

        #region 命令 RelayCommands
        [RelayCommand]
        public async Task LoadMore()
        {
            if (Searching)
                return;
            Searching = true;
            var modProvider = GlobalModProviderProxy.Instance[ProviderKey];
            if (modProvider != null)
            {
                List<AbstractModSearchResult> searchResult = string.IsNullOrEmpty(SearchKeyWord)
                        ? (await modProvider.SearchModAsync(offset: ModSearchResults.Count))
                        : (await modProvider.SearchModAsync(SearchKeyWord, offset: ModSearchResults.Count));
                foreach (var mod in searchResult)
                {
                    ModSearchResults.Add(mod);
                }
            }
            Searching = false;
        }

        [RelayCommand(CanExecute = nameof(CanSearch))]
        public async Task Search(string? keyWord = null)
        {
            if (Searching)
                return;
            ModSearchResults.Clear();
            Searching = true;
            SearchKeyWord = keyWord ?? string.Empty;
            var modProvider = GlobalModProviderProxy.Instance[ProviderKey];
            if (modProvider != null)
            {
                var result = string.IsNullOrEmpty(SearchKeyWord)
                        ? (await modProvider.SearchModAsync())
                        : (await modProvider.SearchModAsync(SearchKeyWord));
                foreach (var mod in result)
                {
                    ModSearchResults.Add(mod);
                }
                if (ModSearchResults.Count > 0)
                {
                    SelectedSlug = ModSearchResults[0].Slug;
                }
                else
                {
                    SelectedSlug = string.Empty;
                }
            }
            Reset = true;
            Reset = false;
            Searching = false;
        }

        [RelayCommand]
        public void SelectMod(string slug)
        {
            SelectedSlug = slug;
        }
        #endregion
    }
}
