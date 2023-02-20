// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Gui
{
    /// <summary>
    /// Gui相关消息.
    /// </summary>
    public class GuiMessages
    {
        public record ModProviderSelectedMessage(string Provider);

        public record ModSelectedMessage(string ModSlug);
    }
}
