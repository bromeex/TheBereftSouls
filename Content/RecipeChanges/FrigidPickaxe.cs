using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("SOTS")]
public class FrigidPickaxe : ModSystem
{
    public override void PostAddRecipes()
    {
        for (int i = 0; i < Recipe.numRecipes; i++)
        {
            Recipe recipe = Main.recipe[i];

            if (recipe.createItem.type != ModContent.ItemType<SOTS.Items.Tools.FrigidPickaxe>())
                continue;

            Recipe alternativeRecipe = recipe.Clone();

            recipe.AddIngredient(ItemID.TissueSample, 6);

            alternativeRecipe.AddIngredient(ItemID.ShadowScale, 6);
            alternativeRecipe.Register();
            break;
        }
    }
}
