using System.Runtime.CompilerServices;
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

        public override void PostUpdateWorld()
        {
            if (TheBereftSouls.CalamityMod != null && TheBereftSouls.FargosSoulMod != null)
            {
                CalamityDificultyCheck.CheckCalamity(ref Revengeance, ref Death);
                FargosDificultyCheck.CheckFargos(ref EternityMode, ref MasochistMode);
            }
            else if (TheBereftSouls.CalamityMod != null)
            {
                CalamityDificultyCheck.CheckCalamity(ref Revengeance, ref Death);
            }
            else if (TheBereftSouls.FargosSoulMod != null)
            {
                FargosDificultyCheck.CheckFargos(ref EternityMode, ref MasochistMode);
            }
            LegendaryMode = Main.masterMode && Main.getGoodWorld;

            base.PostUpdateWorld();
        }
    }

    [ExtendsFromMod("CalamityMod")]
    internal class CalamityDificultyCheck
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckCalamity(ref bool Revengeance, ref bool Death)
        {
            Revengeance = (bool)TheBereftSouls.CalamityMod.Call("GetDifficultyActive", "revengeance");
            Death = (bool)TheBereftSouls.CalamityMod.Call("GetDifficultyActive", "death");
        }
    }
    [ExtendsFromMod("FargowiltasSouls")]
    internal class FargosDificultyCheck
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckFargos(ref bool EternityMode, ref bool MasochistMode)
        {
            EternityMode = FargowiltasSouls.Core.Systems.WorldSavingSystem.EternityMode;
            MasochistMode = FargowiltasSouls.Core.Systems.WorldSavingSystem.MasochistModeReal;
        }
    }
}
