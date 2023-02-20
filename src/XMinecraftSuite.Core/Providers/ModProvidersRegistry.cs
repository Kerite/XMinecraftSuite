using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers;

public class ModProvidersRegistry : ObservableRecipient, INotifyCollectionChanged, IEnumerable<IModProvider>
{
    public IEnumerable<ModProviderMetaData> MetaDatas => Registry.Values.Select(x => x.MetaData);
    public IEnumerable<string> ProviderKeys => Registry.Keys;
    public IEnumerable<IModProvider> Providers => Registry.Values.Where(x => x != null);
    public Dictionary<string, IModProvider> Registry { get; } = new();

    [DebuggerHidden]
    public IModProvider? this[string? key]
    {
        get => key == null ? null : Registry[key];
        set
        {
            if (key == null)
                return;
            if (value == null)
            {
                Registry.Remove(key);
            }
            else
            {
                OnPropertyChanging(nameof(Registry));
                Registry[key] = value;
                CollectionChanged?.Invoke(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
                OnPropertyChanged(nameof(Registry));
            }
        }
    }

    [DebuggerHidden]
    public IModProvider? this[ModProviderMetaData metaData]
    {
        get => this[metaData.ProviderId];
        set => this[metaData.ProviderId] = value;
    }

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public static ModProvidersRegistry operator +(ModProvidersRegistry registry, IModProvider provider)
    {
        registry[provider.MetaData] = provider;
        return registry;
    }

    #region 方法 Methods
    IEnumerator IEnumerable.GetEnumerator()
    {
        return Registry.Values.GetEnumerator();
    }

    IEnumerator<IModProvider> IEnumerable<IModProvider>.GetEnumerator()
    {
        return Registry.Values.GetEnumerator();
    }
    #endregion
}