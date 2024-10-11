using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Utility
{
    public class RecipeUtils : ModSystem
    {
        /// <summary>
        /// Override a required crafting station with the given tile type to this recipe. Ex: <c>RecipeUtils.OverrideCraftStation(recipe,TileID.WorkBenches)</c>
        /// </summary>
        public static void OverrideTile(Recipe recipe, int newTile)
        {   
            List<int> tilesList = recipe.requiredTile;
            if (tilesList.Count > 0)
                recipe.requiredTile.Clear();
            
            recipe.AddTile(newTile);
        }
        public static void OverrideTile<T>(Recipe recipe) where T : ModTile
        {
            List<int> tilesList = recipe.requiredTile;
            if (tilesList.Count > 0)
                recipe.requiredTile.Clear();
            recipe.AddTile<T>();
        }
        public static void OverrideTile(Recipe recipe,int tileObjetive, int newTile)
        {
            List<int> tilesList = recipe.requiredTile;
            foreach (int tile in tilesList)
            {
                if(tileObjetive == tile)
                    recipe.RemoveTile(tile);
            }
            recipe.AddTile(newTile);
        }
        public static void OverrideTile<T>(Recipe recipe,int tileObjetive) where T : ModTile
        {
            List<int> tilesList = recipe.requiredTile;
            if (tilesList.Count > 0)
            {
                foreach (int tile in tilesList)
                {
                    if (tileObjetive == tile)
                        recipe.RemoveTile(tile);
                }
            }
            recipe.AddTile<T>();
        }

        /// <summary>
        /// Override an ingredient to this recipe with the given item type and stack size. Ex: <c>RecipeUtils.OverrideIngredient(recipe,ItemID.IronBar,ItemID.GoldBar)</c>
        /// </summary>
        public static void OverrideIngredient(int newItem,Recipe recipe, int itemObjetive,int stack = 1)
        {
            recipe.RemoveIngredient(itemObjetive);
            recipe.AddIngredient(newItem, stack);
        }
        public static void OverrideIngredient<T>(Recipe recipe, int itemObjetive, int stack = 1) where T : ModItem
        {
            recipe.RemoveIngredient(itemObjetive);
            recipe.AddIngredient<T>(stack);
        }

    }
}
