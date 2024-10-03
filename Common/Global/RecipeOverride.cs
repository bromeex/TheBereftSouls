using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Common.Utility;

namespace TheBereftSouls.Common.Global
{
    public class RecipeOverride : ModSystem
    {

        public override void PostAddRecipes()
        {

            foreach (Recipe recipe in Main.recipe)
            {
                if (TheBereftSouls.CalamityRangerExpansion != null)
                {
                    if (recipe.TryGetResult(ExternalModCallUtils.GetItemFromMod(TheBereftSouls.CalamityRangerExpansion, "AutoCalculationCoil"), out _))
                    {
                        recipe.AddIngredient<CosmiliteBar>(5);
                        RecipeUtils.OverrideTile<CosmicAnvil>(recipe);
                        recipe.AddTile<CosmicAnvil>();
                    }
                }
            }
            base.PostAddRecipes();
        }
    }
}
