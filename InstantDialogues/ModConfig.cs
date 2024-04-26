using StardewModdingAPI.Utilities;

namespace InstantDialogues
{
    internal class ModConfig
    {
        public bool EntireModEnabled { get; set; } = true;
        public bool UseToggleKey { get; set; } = true;
        public KeybindList ToggleKey { get; set; } = KeybindList.Parse("OemPeriod");
        public bool EnableOnLaunchWhenUseToggleKey { get; set; } = true;
        public int SkipPreventTimeWhileModOn { get; set; } = 750;
    }
}
