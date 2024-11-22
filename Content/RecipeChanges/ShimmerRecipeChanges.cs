using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using ThoriumMod.Items.Consumable;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.Donate;

namespace TheBereftSouls.Content.RecipeChanges
{
    [ExtendsFromMod("ThoriumMod")]
    public class ShimmerRecipeModifications : ModSystem
    {
        private static readonly Dictionary<int, Func<bool>> shimmerRecipeConditions = new Dictionary<int, Func<bool>>
        {
            { ModContent.ItemType<KineticPotion>(), () => Main.hardMode },
            { ModContent.ItemType<HolyPotion>(), () => Main.hardMode },
            { ModContent.ItemType<InspirationReachPotion>(), () => Main.hardMode },
            { ModContent.ItemType<WarmongerPotion>(), () => NPC.downedBoss2 }
        };

        public override void PreUpdateWorld()
        {
            ApplyShimmerConditions();
        }

        private void ApplyShimmerConditions()
        {
            foreach (var entry in shimmerRecipeConditions)
            {
                int itemType = entry.Key;
                Func<bool> condition = entry.Value;

                if (!condition())
                {
                    ItemID.Sets.ShimmerTransformToItem[itemType] = itemType;
                }
                else
                {
                    ItemID.Sets.ShimmerTransformToItem[itemType] = 0;
                }
            }
        }
    }
}