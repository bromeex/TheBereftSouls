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
                    if (recipe.TryGetResult(ExternalModCallUtils.Get<ModItem>(TheBereftSouls.CalamityRangerExpansion, "AutoCalculationCoil"), out _))
                    {
                        recipe.AddIngredient(ExternalModCallUtils.Get<ModItem>(CalamityMod,"CosmiliteBar").Type,5);
                        RecipeUtils.OverrideTile(recipe,ExternalModCallUtils.Get<ModItem>(CalamityMod, "CosmicAnvil").Type);
                    }
                }
            }
        }
    }
}
