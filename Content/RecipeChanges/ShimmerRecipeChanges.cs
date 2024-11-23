using System;
using System.Collections.Generic;
using CalamityAmmo.Misc;
using SOTS.Items.Potions;
using Terraria;
using Terraria.ModLoader;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.Consumable;
using ThoriumMod.Items.Donate;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("ThoriumMod", "SOTS")]
public class ShimmerRecipeModifications : ModSystem
{
    private static readonly Dictionary<int, Func<bool>> shimmerRecipeConditions = new()
    {
        { ModContent.ItemType<KineticPotion>(), () => Main.hardMode }, // Gives Pixie Dust
        { ModContent.ItemType<HolyPotion>(), () => Main.hardMode }, // Gives Pixie Dust
        { ModContent.ItemType<InspirationReachPotion>(), () => Main.hardMode }, // Gives Pixie Dust
        { ModContent.ItemType<WarmongerPotion>(), () => NPC.downedBoss2 }, // Gives Hell Stone
        { ModContent.ItemType<HardTack>(), (() => CalamityMod.DownedBossSystem.downedYharon)}, // Gives Auric Tesla Bars
        { ModContent.ItemType<NightmarePotion>(), (() => Main.hardMode)}, // Gives Souls Of Night
    };

    public override void Load()
    {
        On_Item.CanShimmer += On_Item_CanShimmer;
    }

    private static bool On_Item_CanShimmer(On_Item.orig_CanShimmer orig, Item self)
    {
        return shimmerRecipeConditions.TryGetValue(self.type, out var condition)
            ? condition() && orig(self)
            : orig(self);
    }
}
