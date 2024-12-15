using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Materials;
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
            {
                recipe.DisableRecipe();
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
                break;
            }
        }
    }
}