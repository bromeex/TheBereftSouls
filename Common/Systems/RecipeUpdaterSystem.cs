using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Systems;

public class RecipeUpdaterSystem : ModSystem
{
    private static readonly Dictionary<int, List<RecipeMod>> _recipeMods = [];
    private static readonly List<Action> _postModCallbacks = [];

    // register a RecipeMod to apply to the given itemId
    public static void AddRecipeMod(int itemId, RecipeMod mod)
    {
        if (_recipeMods.TryGetValue(itemId, out List<RecipeMod>? mods))
            mods.Add(mod);
        else
            _recipeMods[itemId] = [mod];
    }

    // register a callback to get called after recipes have been modified.
    // this is useful for creating new recipes.
    public static void AddPostModCallback(Action action)
    {
        _postModCallbacks.Add(action);
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

        foreach (Action action in _postModCallbacks)
            action();
    }

    public override void Unload()
    {
        _recipeMods.Clear();
        _postModCallbacks.Clear();
    }
}
