using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Linq;
using XMinecraftSuite.Core;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Wpf.Properties;

namespace XMinecraftSuite.Wpf.ViewModels
{
    public partial class ModVersionsWindowViewModel : ObservableRecipient
    {
        public string Slug { get; }
        public List<MinecraftVersionModel> RenderedMinecraftVersions
        {
            get
            {
                var modGameVersions = AllModVersions.SelectMany(mod => mod.GameVersions);
                var versions = AllGameVersions?
                    .Where(x => (x.Type == EnumVersionType.Release) || IncludeSnapshot)
                    .Where(x => modGameVersions?.Contains(x.Id) ?? false);
                return versions?.ToList() ?? new List<MinecraftVersionModel>();
            }
        }
        public List<AbstractModVersion> RenderedModVersions
        {
            get
            {
                var newList = AllModVersions
                    .Where(x => x.GameVersions.Contains(SelectedGameVersion))
                    .ToList();
                SelectedModVersionId = newList.FirstOrDefault()?.VersionId;
                return newList;
            }
        }

        public ModVersionsWindowViewModel(string slug)
        {
            Slug = slug;
            if (allGameVersions == null)
            {
                _ = SyncMinecraftVersions();
            }
            _ = SyncModVersions();
        }

        #region 可观测属性 ObservableProperties
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RenderedMinecraftVersions))]
        private static List<MinecraftVersionModel>? allGameVersions;

        [ObservableProperty]
        private string providerKey = "modrinth";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RenderedMinecraftVersions))]
        [NotifyPropertyChangedFor(nameof(RenderedModVersions))]
        private List<AbstractModVersion> allModVersions = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RenderedMinecraftVersions))]
        private bool includeSnapshot = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SyncMinecraftVersionsCommand))]
        private bool loadingMinecraftVersion = false;

        [ObservableProperty]
        private bool loadingModVersion = false;

        [ObservableProperty]
        private bool showChangeLog = Settings.Default.ShowChangeLog;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RenderedModVersions))]
        private string? selectedGameVersion;

        [ObservableProperty]
        private string? selectedModVersionId;
        #endregion

        #region 方法 Methods
        private bool CanLoadMinecraftVersion()
        {
            return !LoadingMinecraftVersion;
        }

        partial void OnSelectedGameVersionChanged(string? value)
        {
            WeakReferenceMessenger.Default.Send(new GameVersionSelectedMessage(value));
        }

        partial void OnSelectedModVersionIdChanged(string? value)
        {
            WeakReferenceMessenger.Default.Send(new ModVersionSelectedMessage(value));
        }

        partial void OnShowChangeLogChanged(bool value)
        {
            Settings.Default["ShowChangeLog"] = value;
            Settings.Default.Save();
        }
        #endregion

        #region 命令 RelayCommands
        [RelayCommand]
        private void SelectModVersion(AbstractModVersion version)
        {
            SelectedModVersionId = version.VersionId;
        }

        [RelayCommand(CanExecute = nameof(CanLoadMinecraftVersion))]
        private async Task SyncMinecraftVersions()
        {
            LoadingMinecraftVersion = true;
            var resultModels = await MCRequestHelper.Instance.GetMinecraftVersionsModelAsync(true);
            AllGameVersions = resultModels ?? new();
            LoadingMinecraftVersion = false;
        }

        [RelayCommand]
        private async Task SyncModVersions()
        {
            LoadingModVersion = true;
            AllModVersions.Clear();
            var provider = GlobalModProviderProxy.Instance[ProviderKey];
            if (provider != null)
            {
                var list = await provider.GetModVersionsAsync(Slug);
                AllModVersions = list ?? new();
            }
            LoadingModVersion = false;
        }
        #endregion

        public record GameVersionSelectedMessage(string? GameVersion);
        public record ModVersionSelectedMessage(string? ModVersionId);
    }
}
