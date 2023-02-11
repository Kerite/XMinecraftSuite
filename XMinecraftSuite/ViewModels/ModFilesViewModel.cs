using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Data;
using XMinecraftSuite.Core;
using XMinecraftSuite.Core.Commons;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Wpf.Commons.Commands;

namespace XMinecraftSuite.Wpf.ViewModels
{
    public partial class ModFilesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? _selectedVersion;

        [ObservableProperty]
        private List<string> _versions = new();

        [ObservableProperty]
        private List<AbstractModFile> _modFiles = new();

        [ObservableProperty]
        private bool _includeSnapshot = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(FetchMinecraftVersionsCommand))]
        private bool _loadingMinecraftVersion = false;

        [ObservableProperty]
        private ListCollectionView? _versionsView;

        public string Slug { get; }

        public ModFilesViewModel(string slug)
        {
            Slug = slug;
        }

        private bool CanLoadMinecraftVersion => !LoadingMinecraftVersion;

        [RelayCommand(CanExecute = nameof(CanLoadMinecraftVersion))]
        private async Task FetchMinecraftVersions(bool includeSnapshot)
        {
            LoadingMinecraftVersion = true;

            var resultModels = await MCRequestHelper.Instance.GetMinecraftVersionsModelAsync(
                includeSnapshot
            );
            var newView = new ListCollectionView(resultModels);
            newView.GroupDescriptions?.Add(new PropertyGroupDescription("MType"));
            VersionsView = newView;

            SelectedVersion = ((MinecraftVersionModel)newView.GetItemAt(0)).Id;

            LoadingMinecraftVersion = false;
        }

        [RelayCommand]
        private async Task Sync() { }
    }
}
