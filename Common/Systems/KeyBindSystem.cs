using Terraria.ModLoader;

namespace TheBereftSouls.Common.Systems;

public class KeybindSystem : ModSystem
{
    public static ModKeybind VesperaEnchStone { get; private set; }

    public override void Load()
    {
        // Use localization keys (refer to the localization file) for keybind names.
        VesperaEnchStone = KeybindLoader.RegisterKeybind(Mod, "VesperaEnchantmentStone", "U");
    }

    public override void Unload()
    {
        VesperaEnchStone = null;
    }
}