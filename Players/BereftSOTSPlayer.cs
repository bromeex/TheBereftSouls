using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SOTS.Items.Flails;
using SOTS.Items.Permafrost;
using SOTS.Items.SpiritStaves;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Players
{
    [ExtendsFromMod("SOTS")]
    public class BereftSOTSPlayer : ModPlayer
    {
        public bool VibrantEnch = false;
        public bool FrigidEnch = false;

        public List<Vector2> VesperaStoneCoords = new List<Vector2>(); // Used by Vespera ench
        public static List<int> FrigidItems = new List<int>() // Used by Frigid Ench, needs to be updated with weapons from other mods; Maybe move somewhere else
        {
            ItemID.Snowball,
            ItemID.SnowballCannon,
            ItemID.SnowmanCannon,
            ItemID.IceBlade,
            ItemID.IceBow,
            ItemID.IceBoomerang,
            ItemID.IceSickle,
            ItemID.NorthPole,
            ItemID.StaffoftheFrostHydra,
            ItemID.FlinxStaff,
            ItemID.FrostStaff,
            ItemID.Frostbrand,
            ItemID.FrostDaggerfish,
            ItemID.FlowerofFrost,
            ItemID.WandofFrosting,
            ItemID.BlizzardStaff,

            ModContent.ItemType<ShatterBlade>(),
            ModContent.ItemType<ShardStaff>(),
            ModContent.ItemType<CryoCannon>(),
            ModContent.ItemType<PermafrostSpiritStaff>(),
            ModContent.ItemType<StormSpell>(),
            ModContent.ItemType<FrigidJavelin>(),
            ModContent.ItemType<HypericeClusterCannon>(),
            ModContent.ItemType<IcicleImpale>(),
            ModContent.ItemType<PBow>(),
            ModContent.ItemType<Metalmalgamation>(),
            ModContent.ItemType<ShardstormSpell>(),
            ModContent.ItemType<NorthStar>(),
        };

        public bool PatchedUp = false;

        public override void ResetEffects()
        {
            VibrantEnch = false;
            FrigidEnch = false;

            PatchedUp = false;
        }
    }
}
