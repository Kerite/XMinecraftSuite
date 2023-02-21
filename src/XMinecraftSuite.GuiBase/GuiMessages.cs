// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Gui
{
    /// <summary>
    /// Gui相关消息.
    /// </summary>
    public static class GuiMessages
    {
        /// <summary>
        /// ModProvider被选择.
        /// </summary>
        /// <param name="Provider">被选择的ModProvider.</param>
        public record ModProviderSelectedMessage(string Provider);

        /// <summary>
        /// Mod被选择的消息.
        /// </summary>
        /// <param name="ModSlug">ModSlug.</param>
        public record ModSelectedMessage(string ModSlug);
    }
}
