using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.ThrownItems;
using CalamityMod.Items.Materials;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("CalamityMod")]
public class GalacticaSingularity : ModSystem
{
    public override void PostAddRecipes()
    {
        for (int i = 0; i < Recipe.numRecipes; i++)
        {
            Recipe recipe = Main.recipe[i];

            if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Materials.GalacticaSingularity>())
                continue;
		recipe.AddIngredient(ModContent.ItemType<ShootingStarFragment>(),1);
		recipe.AddIngredient(ModContent.ItemType<CelestialFragment>(),1);
		recipe.AddIngredient(ModContent.ItemType<WhiteDwarfFragment>(),1);
		recipe.AddIngredient(ModContent.ItemType<MeldBlob>(),1);
            break;
        }
    }
}
