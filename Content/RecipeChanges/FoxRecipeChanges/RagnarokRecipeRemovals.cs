using RagnarokMod.Items.BardItems.Armor;
using RagnarokMod.Items.HealerItems.Armor;
using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("RagnarokMod")]
public class RagnarokRecipeRemovals : ModSystem
{
    public override void PostAddRecipes()
    {
        foreach (var recipe in Main.recipe)
        {   
            // Removed these items from being able to be crafted as CalamityBardHealer has the same items, no reason to have 2 of the same item, let alone 15 times
            if (recipe.createItem.type == ModContent.ItemType<AerospecHealer>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<AuricTeslaHealerHead>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<BloodflareHeadHealer>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<DaedalusHeadHealer>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<SilvaHeadHealer>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<StatigelHeadHealer>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<TarragonCowl>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<AerospecBard>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<AuricTeslaFrilledHelmet>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<BloodflareHeadBard>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<DaedalusHeadBard>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<GodSlayerHeadBard>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<StatigelHeadBard>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<TarragonShroud>())
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<VictideHeadBard>())
                recipe.DisableRecipe();
        }
    }
}
