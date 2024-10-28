using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Utils;

namespace TheBereftSouls.Common.Global
{
    public class RecipeOverride : ModSystem
    {

        public override void PostAddRecipes()
        {
            Mod CalamityMod = TheBereftSouls.CalamityMod;
            foreach (Recipe recipe in Main.recipe)
            {
                if (TheBereftSouls.CalamityRangerExpansion != null)
                {
                    if (recipe.TryGetResult(ExternalModCallUtils.GetItemFromMod(TheBereftSouls.CalamityRangerExpansion, "AutoCalculationCoil"), out _))
                    {
                        recipe.AddIngredient(ExternalModCallUtils.GetItemFromMod(CalamityMod,"CosmiliteBar").Type,5);
                        RecipeUtils.OverrideTile(recipe,ExternalModCallUtils.GetTileFromMod(CalamityMod, "CosmicAnvil").Type);
                    }
                }
            }
        }
    }
}
