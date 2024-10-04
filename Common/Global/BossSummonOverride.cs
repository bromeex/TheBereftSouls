﻿using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Common.Utility;
using static TheBereftSouls.Common.Global.GensokyoBossSummonOverride;

namespace TheBereftSouls.Common.Global
{
    public class BossSummonOverride : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public static HashSet<int> BossSummons { get; set; }
        public override void SetDefaults(Item item)
        {
            if (TheBereftSouls.GensokyoMod != null)
                GensokyoBossSummonOverride.LoadList();
            if(TheBereftSouls.SecretsOfTheShadows != null)
                SOTSBossSummonOverride.LoadList();

            if (BossSummons.Contains(item.type))
                item.consumable = false;

            base.SetDefaults(item);
        }
    }

    [ExtendsFromMod("Gensokyo")]
    internal class GensokyoBossSummonOverride
    {
        public static void LoadList()
        {
            GlobalUtils.AddSomeElements(BossSummonOverride.BossSummons,
            [
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"AliceMargatroidSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"CirnoSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"EternityLarvaSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"HinaKagiyamaSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"KaguyaHouraisanSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"KoishiKomeijiSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"LilyWhiteSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"MayumiJoutouguuSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"MedicineMelancholySpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"MinamitsuMurasaSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"NazrinSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"NitoriKawashiroSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"RumiaSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"SakuyaIzayoiSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"SeijaKijinSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"SeiranSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"SekibankiSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"TenshiHinanawiSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"ToyosatomimiNoMikoSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"TsukumoSistersSpawner"),
                ExternalModCallUtils.GetItemFromMod(TheBereftSouls.GensokyoMod,"UtsuhoReiujiSpawner")
            ]);
        }

        [ExtendsFromMod("SOTS")]
        internal class SOTSBossSummonOverride
        { 
            public static void LoadList()
            {
                GlobalUtils.AddSomeElements(BossSummonOverride.BossSummons,
                [
                    ExternalModCallUtils.GetItemFromMod(TheBereftSouls.SecretsOfTheShadows,"JarOfPeanuts"),
                    ExternalModCallUtils.GetItemFromMod(TheBereftSouls.SecretsOfTheShadows,"SuspiciousLookingCandle"),
                    ExternalModCallUtils.GetItemFromMod(TheBereftSouls.SecretsOfTheShadows,"FrostedKey"),
                    ExternalModCallUtils.GetItemFromMod(TheBereftSouls.SecretsOfTheShadows,"CatalystBomb")
                ]);
            }
        }
    }
}
