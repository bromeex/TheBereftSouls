using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Utility
{
    public class DificultyUtils : ModSystem
    {
        public static bool Revengeance = false;
        public static bool Death = false;
        public static bool EternityMode = false;
        public static bool MasochistMode = false;
        public static bool LegendaryMode = false;
        public static bool RevengeEternity = false;
        public static bool DeathEternity = false;

        public override void PostUpdateWorld()
        {
            CheckDificulty();
            base.PostUpdateWorld();
        }
        public void CheckDificulty()
        {
            if(TheBereftSouls.CalamityMod != null && TheBereftSouls.FargosSoulMod != null)
            {
                CheckCalamity();
                CheckFargos();
            }
            else if (TheBereftSouls.CalamityMod != null)
            {
                CheckCalamity();
            }
            else if (TheBereftSouls.FargosSoulMod != null)
            {
                CheckFargos();
            }
            LegendaryMode = Main.masterMode && Main.getGoodWorld;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public void CheckCalamity()
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod))
            {
                Revengeance = (bool)calamityMod.Call("GetDifficultyActive", "revengeance");
                Death = (bool)calamityMod.Call("GetDifficultyActive", "death");
            }
        }

        [JITWhenModsEnabled("FargowiltasSouls")]
        public void CheckFargos()
        {
            EternityMode = FargowiltasSouls.Core.Systems.WorldSavingSystem.EternityMode;
            MasochistMode = FargowiltasSouls.Core.Systems.WorldSavingSystem.MasochistModeReal;
        }
    }
}
