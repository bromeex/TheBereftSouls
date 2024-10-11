using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Common.Utility;
using static TheBereftSouls.Common.Global.GensokyoBossSummonOverride;

namespace TheBereftSouls.Common.Global
{
    public class BossSummonOverride : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public static Collection<int> BossSummons = [];
        
        public override void SetDefaults(Item item)
        {   
            BossSummons.Clear();
            if (TheBereftSouls.GensokyoMod != null)
                GensokyoBossSummonOverride.LoadList(BossSummons);
            if(TheBereftSouls.SecretsOfTheShadows != null)
                SOTSBossSummonOverride.LoadList(BossSummons);

            if (BossSummons.Contains(item.type))
                item.consumable = false;

        }
    }

    [ExtendsFromMod("Gensokyo")]
    internal class GensokyoBossSummonOverride
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LoadList(ICollection<int> BossSummons)
        {
            GlobalUtils.AddSomeElements(BossSummons,
            [
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"AliceMargatroidSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"CirnoSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"EternityLarvaSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"HinaKagiyamaSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"KaguyaHouraisanSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"KoishiKomeijiSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"LilyWhiteSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"MayumiJoutouguuSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"MedicineMelancholySpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"MinamitsuMurasaSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"NazrinSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"NitoriKawashiroSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"RumiaSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"SakuyaIzayoiSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"SeijaKijinSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"SeiranSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"SekibankiSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"TenshiHinanawiSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"ToyosatomimiNoMikoSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"TsukumoSistersSpawner").Type,
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"UtsuhoReiujiSpawner").Type
            ]);
        }

        [ExtendsFromMod("SOTS")]
        internal class SOTSBossSummonOverride
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            public static void LoadList(ICollection<int> BossSummons)
            {
                GlobalUtils.AddSomeElements(BossSummons,
                [
                    ExternalModCallUtils.GetItemFromMod(TheBereftSouls.SecretsOfTheShadows,"JarOfPeanuts").Type,
                    ExternalModCallUtils.GetItemFromMod(TheBereftSouls.SecretsOfTheShadows,"SuspiciousLookingCandle").Type,
                    ExternalModCallUtils.GetItemFromMod(TheBereftSouls.SecretsOfTheShadows,"FrostedKey").Type,
                    ExternalModCallUtils.GetItemFromMod(TheBereftSouls.SecretsOfTheShadows,"CatalystBomb").Type
                ]);
            }
        }
    }
}
