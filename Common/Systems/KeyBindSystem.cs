using Terraria.ModLoader;

namespace TheBereftSouls.Common.Systems
{
    public class KeybindSystem : ModSystem
    {
        public static ModKeybind VesperaEnchStone;

        public override void Load()
        {
            VesperaEnchStone = KeybindLoader.RegisterKeybind(Mod, "Vespera Enchantment Stone", "U");
        }

        public override void Unload()
        {
            VesperaEnchStone = null;
        }
    }
}
