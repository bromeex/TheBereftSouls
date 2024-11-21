using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Utils
{
    public class DificultyUtils : ModSystem
    {
        public static bool Revengeance = false;
        public static bool Death = false;
        public static bool EternityMode = false;
        public static bool MasochistMode = false;
        public static bool LegendaryMode = false;

        public override void PostUpdateWorld()
        {
            if (TheBereftSouls.CalamityMod != null)
            {
                CalamityDificultyCheck.CheckCalamity(out Revengeance, out Death);
            }
            if (TheBereftSouls.FargosSoulMod != null)
            {
                FargosDificultyCheck.CheckFargos(out EternityMode, out MasochistMode);
            }
            LegendaryMode = Main.masterMode && Main.getGoodWorld;
        }
    }

    [ExtendsFromMod("CalamityMod")]
    internal class CalamityDificultyCheck
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckCalamity(out bool revengeance, out bool death)
        {
            Mod calamityMod = TheBereftSouls.CalamityMod;
            revengeance = (bool)calamityMod.Call("GetDifficultyActive", "revengeance");
            death = (bool)calamityMod.Call("GetDifficultyActive", "death");
        }
    }
    [ExtendsFromMod("FargowiltasSouls")]
    internal class FargosDificultyCheck
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckFargos(out bool eternityMode, out bool masochistMode)
        {
            eternityMode = FargowiltasSouls.Core.Systems.WorldSavingSystem.EternityMode;
            masochistMode = FargowiltasSouls.Core.Systems.WorldSavingSystem.MasochistModeReal;
        }
    }
}
