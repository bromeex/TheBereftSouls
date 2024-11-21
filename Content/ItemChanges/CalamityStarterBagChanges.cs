using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using CalamityMod.Items.TreasureBags.MiscGrabBags;
using FargowiltasSouls.Content.Items.Accessories.Souls;

namespace TheBereftSouls.Content.ItemChanges
{
    [ExtendsFromMod("CalamityMod", "FargowiltasSouls")]
    public class CalamityStarterBagChanges : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.ModItem is StarterBag)
            {
                // Normal Item & Modded Item Example
                // itemLoot.Add(ItemDropRule.Common(ItemID.Zenith, 1, 1, 1));
                // itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EternitySoul>(), 1, 1, 1));
            }
        }
    }
}