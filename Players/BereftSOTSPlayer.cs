using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SOTS.Items.Flails;
using SOTS.Items.Permafrost;
using SOTS.Items.SpiritStaves;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Players;

[ExtendsFromMod("SOTS")]
public class BereftSOTSPlayer : ModPlayer
{
    // Used by Frigid Ench, needs to be updated with weapons from other mods; Maybe move somewhere else
    public static HashSet<int> FrigidItems { get; } =
        [
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
            ModContent.ItemType<Metalmalgamation>(),
            ModContent.ItemType<ShardstormSpell>(),
            ModContent.ItemType<NorthStar>(),
        ];

    public bool VibrantEnch { get; set; } = false;
    public bool FrigidEnch { get; set; } = false;
    public bool PatchedUp { get; set; } = false;

    // Used by Vespera ench
    public List<Vector2> VesperaStoneCoords { get; } = [];

    public override void ResetEffects()
    {
        VibrantEnch = false;
        FrigidEnch = false;

        PatchedUp = false;
    }
}
