using CalamityMod.Items.TreasureBags.MiscGrabBags;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.HealerItems;

namespace TheBereftSouls.Content.ItemChanges;

[ExtendsFromMod("CalamityMod", "FargowiltasSouls", "ThoriumMod")]
public class CalamityStarterBagChanges : GlobalItem
{
    private static readonly IItemDropRule[] ItemsToAdd =
    [
        ItemDropRule.Common(ModContent.ItemType<Pill>(), 1, 500, 500),
        ItemDropRule.Common(ModContent.ItemType<Ukulele>()),
    ];

    private static readonly IItemDropRule[] ItemsToRemove = [];

    public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
    {
        if (item.ModItem is not StarterBag)
        {
            return;
        }

        foreach (IItemDropRule dropRule in ItemsToAdd)
        {
            itemLoot.Add(dropRule);
        }

        foreach (IItemDropRule dropRule in ItemsToRemove)
        {
            itemLoot.Remove(dropRule);
        }
    }
}
