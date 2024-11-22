using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.Consumable;
using System;
using System.Collections.Generic;
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

        public override void OnWorldLoad()
        {
            base.OnWorldLoad();

            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (shimmerRecipeConditions.TryGetValue(recipe.createItem.type, out var condition))
                {
                    bool canShimmer = !condition();
                    if (canShimmer)
                    { 
                        ItemID.Sets.ShimmerTransformToItem[recipe.createItem.type] = recipe.createItem.type;
                    }
                    else
                    {
                        ItemID.Sets.ShimmerTransformToItem[recipe.createItem.type] = 0;
                    }
                }
            }
        }
    }
}