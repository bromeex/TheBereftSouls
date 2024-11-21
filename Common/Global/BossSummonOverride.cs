using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Utils;

namespace TheBereftSouls.Common.Global
{
    public class BossSummonOverride : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public static HashSet<int> BossSummons = [];

        public override void SetDefaults(Item item)
        {
            BossSummons.Clear();
            if (TheBereftSouls.GensokyoMod != null)
            {
                GensokyoBossSummonOverride.LoadList(BossSummons);
            }

            if (TheBereftSouls.SecretsOfTheShadows != null)
            {
                SOTSBossSummonOverride.LoadList(BossSummons);
            }

            if (BossSummons.Contains(item.type))
            {
                item.consumable = false;
            }
        }
    }

    [ExtendsFromMod("Gensokyo")]
    internal class GensokyoBossSummonOverride
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LoadList(HashSet<int> bossSummons)
        {
            int[] gensokyolist =
            [
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"AliceMargatroidSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"CirnoSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"EternityLarvaSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"HinaKagiyamaSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"KaguyaHouraisanSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"KoishiKomeijiSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"LilyWhiteSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"MayumiJoutouguuSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"MedicineMelancholySpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"MinamitsuMurasaSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"NazrinSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"NitoriKawashiroSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"RumiaSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"SakuyaIzayoiSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"SeijaKijinSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"SeiranSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"SekibankiSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"TenshiHinanawiSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"ToyosatomimiNoMikoSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"TsukumoSistersSpawner").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.GensokyoMod,"UtsuhoReiujiSpawner").Type
            ];
            bossSummons.UnionWith(gensokyolist);
        }
    }

    [ExtendsFromMod("SOTS")]
    internal class SOTSBossSummonOverride
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LoadList(HashSet<int> bossSummons)
        {
            int[] sotsList =
            [
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.SecretsOfTheShadows,"JarOfPeanuts").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.SecretsOfTheShadows,"SuspiciousLookingCandle").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.SecretsOfTheShadows,"FrostedKey").Type,
                ExternalModCallUtils.Get<ModItem>(TheBereftSouls.SecretsOfTheShadows,"CatalystBomb").Type
            ];
            bossSummons.UnionWith(sotsList);
        }
    }
}
