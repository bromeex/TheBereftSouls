using CalamityMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.ThrownItems;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("CalamityMod", "SOTS", "ThoriumMod")]
public class Calamity : ModSystem
{
    public override void PostAddRecipes()
    {
        foreach (var recipe in Main.recipe)
        {
            if (recipe.createItem.type == ModContent.ItemType<GalacticaSingularity>())
                recipe.DisableRecipe();
        }
        // Changed the Galactica Singularity recipe to include all fragments + meld blob, and increase the yield to 2 per craft
        Recipe newRecipe = Recipe.Create(ModContent.ItemType<GalacticaSingularity>(), 2);
        newRecipe.AddIngredient(ItemID.FragmentVortex);
        newRecipe.AddIngredient(ItemID.FragmentNebula);
        newRecipe.AddIngredient(ItemID.FragmentSolar);
        newRecipe.AddIngredient(ItemID.FragmentStardust);
        newRecipe.AddIngredient(ModContent.ItemType<ShootingStarFragment>());
        newRecipe.AddIngredient(ModContent.ItemType<CelestialFragment>());
        newRecipe.AddIngredient(ModContent.ItemType<WhiteDwarfFragment>());
        newRecipe.AddIngredient(ModContent.ItemType<MeldBlob>());
        newRecipe.AddTile(TileID.LunarCraftingStation);
        newRecipe.Register();
    }
}
