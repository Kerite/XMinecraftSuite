using XMinecraftSuite.Core.Commons;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Wpf.Commons;

namespace XMinecraftSuite.Wpf.ViewModels
{
    public class ModDetailsViewModel : ViewModelBase
    {
        private AbstractModDetailsResult? _modDetails;
        private bool _resetSelectedMod;

        public AbstractModDetailsResult? ModDetails
        {
            get => _modDetails;
            set
            {
                _modDetails = value;
                ResetSelectedMod = true;
                RaisePropertyChangedEvent(nameof(ModDetails));
            }
        }

        public bool ResetSelectedMod
        {
            get => _resetSelectedMod;
            set
            {
                _resetSelectedMod = value;
                RaisePropertyChangedEvent(nameof(ResetSelectedMod));
            }
        }
    }
}