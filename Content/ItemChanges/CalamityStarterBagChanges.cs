using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using CalamityMod.Items.TreasureBags.MiscGrabBags;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.HealerItems;

namespace TheBereftSouls.Content.ItemChanges;

[ExtendsFromMod("CalamityMod", "FargowiltasSouls", "ThoriumMod")]
public class CalamityStarterBagChanges : GlobalItem
{
    private static readonly IItemDropRule[] ItemsToAdd =
    [
        ItemDropRule.Common(ModContent.ItemType<Pill>(), 1, 500, 500),
        ItemDropRule.Common(ModContent.ItemType<Ukulele>(), 1, 1, 1),
    ];

    private static readonly IItemDropRule[] ItemsToRemove = [];
    
    public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
    {
        if (item.ModItem is not StarterBag)
        {
            return;
        }

        foreach (var dropRule in ItemsToAdd)
        {
            itemLoot.Add(dropRule);
        }

        foreach (var dropRule in ItemsToRemove)
        {
            itemLoot.Remove(dropRule);
        }
    }
}