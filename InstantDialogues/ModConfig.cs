using StardewModdingAPI.Utilities;

namespace InstantDialogues
{
    internal class ModConfig
    {
        public bool ModEnabled { get; set; } = true;
        public bool UseToggleKey { get; set; } = true;
        public KeybindList ToggleKey { get; set; } = KeybindList.Parse("OemPeriod");
        public int SkipPreventTimeWhileModOn { get; set; } = 750;
    }
}
