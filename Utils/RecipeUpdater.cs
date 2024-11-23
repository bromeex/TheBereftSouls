using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Utils.RecipeUpdater;

public class RecipeUpdater : ModSystem
{
    public int itemId { get; set; } = -1;
    public List<int> toRemove { get; set; } = [];
    public List<int> toAdd { get; set; } = [];
    public Recipe? itemRecipe
    {
        get
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                if (Main.recipe[i].createItem.type == this.itemId)
                    return Main.recipe[i];
            }
            return null;
        }
    }

    public override void PostAddRecipes()
    {
        if (this.itemId == -1 || this.itemRecipe == null)
            return;
        if (this.toAdd.Count == 0 && this.toRemove.Count == 0)
            return;

        for (int j = 0; j < this.toAdd.Count; j++)
        {
            this.itemRecipe.AddIngredient(this.toAdd[j]);
        }
        for (int j = 0; j < this.toRemove.Count; j++)
        {
            this.itemRecipe.RemoveIngredient(this.toRemove[j]);
        }
    }
}
