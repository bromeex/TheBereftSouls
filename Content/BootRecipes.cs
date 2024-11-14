﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Items;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using FargowiltasSouls.Content.Items.Accessories.Masomode;

namespace TheBereftSouls.Content
{
    [ExtendsFromMod("CalamityMod", "FargowiltasSouls", "SOTS")]
    public class BootRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                switch (recipe.createItem.type)
                {
                    case var id when id == ModContent.ItemType<FlashsparkBoots>():
                        recipe.RemoveIngredient(ItemID.TerrasparkBoots);
                        recipe.AddIngredient(ModContent.ItemType<AngelTreads>());
                        break;
                    case var id when id == ModContent.ItemType<AeolusBoots>():
                        recipe.RemoveIngredient(ModContent.ItemType<AngelTreads>());
                        recipe.AddIngredient(ModContent.ItemType<FlashsparkBoots>());
                        break;
                    case var id when id == ModContent.ItemType<SubspaceBoosters>():
                        recipe.RemoveIngredient(ModContent.ItemType<FlashsparkBoots>());
                        recipe.AddIngredient(ModContent.ItemType<AeolusBoots>());
                        break;
                    case var id when id == ModContent.ItemType<TracersCelestial>():
                        recipe.RemoveIngredient(ModContent.ItemType<AeolusBoots>());
                        recipe.AddIngredient(ModContent.ItemType<SubspaceBoosters>());
                        break;
                    default:
                        break;
                };
            }
        }
    }
}