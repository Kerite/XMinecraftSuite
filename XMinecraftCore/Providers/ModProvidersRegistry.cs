using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XMinecraftSuite.Core.Commons;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers;

public class ModProvidersRegistry : ViewModelBase, INotifyCollectionChanged, IEnumerable<IModProvider>
{
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public Dictionary<string, IModProvider> Registry { get; } = new();

    #region Indexers

    public IModProvider this[string key]
    {
        get => Registry[key];
        set
        {
            Registry[key] = value;
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
            RaisePropertyChangedEvent(nameof(Registry));
        }
    }

    public IModProvider this[ModProviderMetaData metaData]
    {
        get => this[metaData.ProviderId];
        set => this[metaData.ProviderId] = value;
    }

    #endregion Indexers

    #region Operators

    public static ModProvidersRegistry operator +(ModProvidersRegistry registry, IModProvider provider)
    {
        registry[provider.MetaData] = provider;
        return registry;
    }

    #endregion Operators

    public IEnumerable<IModProvider> Providers => Registry.Values;

    public IEnumerable<string> ProviderKeys => Registry.Keys;

    public IEnumerable<ModProviderMetaData> MetaDatas => Registry.Values.Select(x => x.MetaData);

    IEnumerator<IModProvider> IEnumerable<IModProvider>.GetEnumerator()
    {
        return Registry.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Registry.Values.GetEnumerator();
    }
}