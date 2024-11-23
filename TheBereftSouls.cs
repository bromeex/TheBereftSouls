using Terraria.ModLoader;

namespace TheBereftSouls
{
    public class TheBereftSouls : Mod
    {
        internal static TheBereftSouls Instance;

        public override void Load()
        {
            Instance = this;
        }

        public override void Unload()
        {
            Instance = null;
        }
    }
}