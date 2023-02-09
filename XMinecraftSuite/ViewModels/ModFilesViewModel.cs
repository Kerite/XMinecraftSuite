using System.Collections.Generic;
using System.Threading.Tasks;
using XMinecraftSuite.Core;
using XMinecraftSuite.Core.Commons;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Wpf.Commons.Commands;

namespace XMinecraftSuite.Wpf.ViewModels
{
    public class ModFilesViewModel : ViewModelBase
    {
        private string? _selectedVersion;
        private List<string> _versions = new();
        private List<AbstractModFile> _modFiles = new();
        private bool _includeSnapshot;
        private bool _loading;

        public string Slug { get; }
        public DelegateCommand<bool> FetchVersionsCommand { get; }
        public NoParameterDelegateCommand SyncCommand { get; }

        public AbstractModFile[] ModFiles
        {
            get => _modFiles.ToArray();
            set
            {
                _modFiles = new List<AbstractModFile>(value);
                RaisePropertyChangedEvent(nameof(ModFiles));
            }
        }

        public string[] Versions
        {
            get => _versions.ToArray();
            set
            {
                _versions = new List<string>(value);
                RaisePropertyChangedEvent(nameof(Versions));
            }
        }

        public bool IncludeSnapshot
        {
            get => _includeSnapshot;
            set
            {
                _includeSnapshot = value;
                RaisePropertyChangedEvent(nameof(IncludeSnapshot));
            }
        }

        public string SelectedVersion
        {
            get => _selectedVersion;
            set
            {
                _selectedVersion = value;
                RaisePropertyChangedEvent(nameof(SelectedVersion));
            }
        }

        public bool Loading
        {
            get => _loading;
            set
            {
                _loading = value;
                RaisePropertyChangedEvent(nameof(Loading));
            }
        }

        public ModFilesViewModel(string slug)
        {
            Slug = slug;
            FetchVersionsCommand = new DelegateCommand<bool>((includeSnapshot) =>
            {
                new Task(() =>
                {
                    Loading = true;
                    var result = MCRequestHelper.Instance.GetMinecraftVersionsStringAsync(includeSnapshot).Result;
                    Versions = result;
                    SelectedVersion = Versions[0];
                    Loading = false;
                }).Start();
            });
            SyncCommand = new NoParameterDelegateCommand(() => { new Task(() => { }).Start(); });
        }
    }
}