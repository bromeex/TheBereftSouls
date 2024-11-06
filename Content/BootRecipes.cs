using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS;
using SOTS.Items;

namespace TheBereftSouls.Content
{
    public class BootRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && ModLoader.TryGetMod("FargowiltasSouls", out Mod fargowiltasSouls)) 
            {
                calamityMod.TryFind("AngelTreads", out ModItem angelTreads);
                fargowiltasSouls.TryFind("AeolusBoots", out ModItem aeolusBoots);
                calamityMod.TryFind("TracersCelestial", out ModItem tracersCelestial);

                for (int i = 0; i < Recipe.numRecipes; i++)
                {
                    Item result;
                    Recipe recipe = Main.recipe[i];

                    if (recipe.TryGetResult(ModContent.ItemType<SOTS.Items.FlashsparkBoots>(), out result))
                    {
                        recipe.RemoveIngredient(ItemID.TerrasparkBoots);
                        recipe.AddIngredient(angelTreads.Type);
                    }
                    else if (recipe.TryGetResult(aeolusBoots.Type, out result))
                    {
                        recipe.RemoveIngredient(angelTreads.Type);
                        recipe.AddIngredient(ModContent.ItemType<SOTS.Items.FlashsparkBoots>());
                    }
                    else if (recipe.TryGetResult(ModContent.ItemType<SOTS.Items.SubspaceBoosters>(), out result))
                    {
                        recipe.RemoveIngredient(ModContent.ItemType<SOTS.Items.FlashsparkBoots>());
                        recipe.AddIngredient(aeolusBoots.Type);
                    }
                    else if (recipe.TryGetResult(tracersCelestial.Type, out result))
                    {
                        recipe.RemoveIngredient(aeolusBoots.Type);
                        recipe.AddIngredient(ModContent.ItemType<SOTS.Items.SubspaceBoosters>());
                    }
                }
            }
        }
    }
}
