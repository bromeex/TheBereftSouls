using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Systems;

public class RecipeUpdaterSystem : ModSystem
{
    private static readonly Dictionary<int, List<RecipeMod>> _recipeMods = [];

    public static void AddRecipeMod(int itemId, RecipeMod mod)
    {
        if (_recipeMods.TryGetValue(itemId, out List<RecipeMod>? mods))
            mods.Add(mod);
        else
            _recipeMods[itemId] = [mod];
    }

    public override void PostAddRecipes()
    {
        int numRecipes = Recipe.numRecipes; // prevent infinite loop
        for (int i = 0; i < numRecipes; i++)
        {
            Recipe recipe = Main.recipe[i];
            if (_recipeMods.TryGetValue(recipe.createItem.type, out List<RecipeMod>? mods))
            {
                foreach (RecipeMod mod in mods)
                    mod.Modify(recipe);
            }
        }
    }

    public override void Unload()
    {
        _recipeMods.Clear();
    }
}
