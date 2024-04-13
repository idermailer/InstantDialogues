using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace InstantDialogues
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        private ModConfig? config;
        public bool modOn = true;
        public override void Entry(IModHelper helper)
        {
            config = Helper.ReadConfig<ModConfig>();

            if (config.ModEnabled)
            {
                helper.Events.Display.MenuChanged += Display_MenuChanged;
                if (config.UseToggleKey)
                    helper.Events.Input.ButtonsChanged += Input_ButtonsChanged;
            }
        }

        private void Display_MenuChanged(object? sender, MenuChangedEventArgs e)
        {
            if (e.NewMenu is DialogueBox NewMenu)
            {
                if (modOn) {
                    NewMenu.showTyping = false;
                    if (config != null)
                        NewMenu.safetyTimer = config.SkipPreventTimeWhileModOn;
                }
            }
        }

        private void Input_ButtonsChanged(object? sender, ButtonsChangedEventArgs e)
        {
            if (config != null && config.ToggleKey.JustPressed())
            {
                modOn = !modOn;
                string message;
                if (modOn)
                {
                    message = Helper.Translation.Get("modOn");
                }
                else
                {
                    message = Helper.Translation.Get("modOff");
                }

                HUDMessage notify = new(message)
                {
                    noIcon = true,
                    timeLeft = 3000f
                };
                Game1.addHUDMessage(notify);
            }
        }
    }
}