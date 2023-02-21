// Copyright (c) Keriteal. All rights reserved.

using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers;

/// <summary>
/// <see cref="IModProvider"/> 的仓库.
/// </summary>
public class ModProvidersRegistry : ObservableRecipient, INotifyCollectionChanged, IEnumerable<IModProvider>
{
    /// <inheritdoc/>
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    /// <summary>
    /// Enumerator of <see cref="Registry">this.Providers</see> metadatas.
    /// </summary>
    public IEnumerable<ModProviderMetaData> MetaDatas => this.Registry.Values.Select(x => x.MetaData);

    /// <summary>
    /// Enumarator of <see cref="Registry">this.Providers</see> keys.
    /// </summary>
    public IEnumerable<string> ProviderKeys => this.Registry.Keys;

    /// <summary>
    /// Enumarator of <see cref="Registry">this.Providers</see> values.
    /// </summary>
    public IEnumerable<IModProvider> Providers => this.Registry.Values.Where(x => x != null);

    /// <summary>
    /// 存储的 <see cref="IModProvider"/>.
    /// </summary>
    public Dictionary<string, IModProvider> Registry { get; } = new();

    /// <summary>
    /// 获取 key 对应的 ModProvider.
    /// </summary>
    /// <param name="key">ModProvider 的 Key.</param>
    /// <returns>key 对应的 ModProvider.</returns>
    public IModProvider? this[string? key]
    {
        get => key == null ? null : this.Registry[key];
        set
        {
            if (key == null)
            {
                return;
            }

            if (value == null)
            {
                this.Registry.Remove(key);
            }
            else
            {
                OnPropertyChanging(nameof(this.Registry));
                this.Registry[key] = value;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
                OnPropertyChanged(nameof(this.Registry));
            }
        }
    }

    /// <summary>
    /// 获取 metaData 对应的 ModProvider.
    /// </summary>
    /// <param name="metaData">ModProvider 的 MetaData.</param>
    /// <returns>MetaData 对应的 ModProvider.</returns>
    [DebuggerHidden]
    public IModProvider? this[ModProviderMetaData metaData]
    {
        get => this[metaData.ProviderId];
        set => this[metaData.ProviderId] = value;
    }

    /// <summary>
    /// 向 <see cref="ModProvidersRegistry"/> 中添加 <see cref="IModProvider"/>.
    /// </summary>
    /// <param name="registry">被添加的 Registry.</param>
    /// <param name="provider">要添加的 Provider.</param>
    /// <returns>左值.</returns>
    public static ModProvidersRegistry operator +(ModProvidersRegistry registry, IModProvider provider)
    {
        registry[provider.MetaData] = provider;
        return registry;
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.Registry.Values.GetEnumerator();
    }

    /// <summary>
    /// 遍历容器中的所有ModProvider.
    /// </summary>
    /// <returns>容器中的所有ModProvider的迭代器.</returns>
    public IEnumerator<IModProvider> GetEnumerator()
    {
        return this.Registry.Values.GetEnumerator();
    }
}
