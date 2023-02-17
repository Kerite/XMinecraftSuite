using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMinecraftSuite.Gui
{
    public class GuiMessages
    {
        public record ModProviderSelectedMessage(string Provider);

        public record ModSelectedMessage(string ModSlug);
    }
}
