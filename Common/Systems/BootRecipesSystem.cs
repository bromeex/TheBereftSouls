using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using SOTS.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Systems;

[ExtendsFromMod("CalamityMod", "FargowiltasSouls", "SOTS")]
public class BootRecipesSystem : ModSystem
{
    private readonly record struct RecipeModification(int RemoveItem, int AddItem);

    private static readonly Dictionary<int, RecipeModification> RecipeModifications = new()
    {
        [ModContent.ItemType<FlashsparkBoots>()] = new(
            RemoveItem: ItemID.TerrasparkBoots,
            AddItem: ModContent.ItemType<AngelTreads>()
        ),

        [ModContent.ItemType<AeolusBoots>()] = new(
            RemoveItem: ModContent.ItemType<AngelTreads>(),
            AddItem: ModContent.ItemType<FlashsparkBoots>()
        ),

        [ModContent.ItemType<SubspaceBoosters>()] = new(
            RemoveItem: ModContent.ItemType<FlashsparkBoots>(),
            AddItem: ModContent.ItemType<AeolusBoots>()
        ),

        [ModContent.ItemType<TracersCelestial>()] = new(
            RemoveItem: ModContent.ItemType<AeolusBoots>(),
            AddItem: ModContent.ItemType<SubspaceBoosters>()
        ),
    };

    public override void PostAddRecipes()
    {
        for (int i = 0; i < Recipe.numRecipes; i++)
        {
            Recipe recipe = Main.recipe[i];
            ModifyRecipe(recipe);
        }
    }

    private static void ModifyRecipe(Recipe recipe)
    {
        int item = recipe.createItem.type;
        if (RecipeModifications.TryGetValue(item, out RecipeModification modification))
        {
            recipe.RemoveIngredient(modification.RemoveItem);
            recipe.AddIngredient(modification.AddItem);
        }
    }
}
