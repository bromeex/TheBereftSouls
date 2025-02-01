using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using SOTS.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Linq;
using System.IO;

namespace TheBereftSouls.Content.RecipeChanges
{
    [ExtendsFromMod("CalamityMod", "FargowiltasSouls", "SOTS")]
    public class BootRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            Mod.Logger.Info("Modifying existing recipes...");

            // Load JSON file
            string jsonFileName = "Content/Recipes.json";
            Mod.Logger.Info($"Looking for JSON file at: {jsonFileName}");

            if (!Mod.FileExists(jsonFileName))
            {
                Mod.Logger.Warn("Recipe modification JSON not found!");
                return;
            }

            byte[] jsonBytes = Mod.GetFileBytes(jsonFileName);
            string jsonContent = Encoding.UTF8.GetString(jsonBytes);
            JArray recipesToModify = JArray.Parse(jsonContent);

            // Iterate over all recipes
            foreach (Recipe recipe in Main.recipe.ToList()) // Clone to avoid modifying while iterating
            {
                Item resultItem = recipe.createItem;
                string resultName = resultItem.ModItem != null ? resultItem.ModItem.FullName : $"Terraria:{resultItem.Name}";

                Mod.Logger.Info($"Checking recipe for: {resultName}");

                // Check if this recipe exists in the JSON data
                JObject matchingRecipe = recipesToModify.FirstOrDefault(r => r["output"]["item"].ToString() == resultName) as JObject;
                if (matchingRecipe != null)
                {
                    Mod.Logger.Info($"Found matching recipe in JSON: {resultName}");

                    // Log the ingredients and station
                    Mod.Logger.Info($"Ingredients: {matchingRecipe["ingredients"]}");
                    Mod.Logger.Info($"Station: {matchingRecipe["station"]}");

                    // Modify this recipe from JSON
                    Mod.Logger.Info($"Modifying recipe for: {resultName}");

                    // Remove all current ingredients and tiles
                    for (int i = recipe.requiredItem.Count - 1; i >= 0; i--)
                    {
                        recipe.RemoveIngredient(recipe.requiredItem[i].type);
                    }
                    for (int i = recipe.requiredTile.Count - 1; i >= 0; i--)
                    {
                        recipe.RemoveTile(recipe.requiredTile[i]);
                    }

                    // Modify with new ingredients
                    JArray ingredients = matchingRecipe["ingredients"].ToObject<JArray>();
                    foreach (JObject ingredient in ingredients)
                    {
                        string ingredientName = ingredient["item"].ToString();
                        int ingredientQuantity = ingredient["quantity"].ToObject<int>();

                        int ingredientType = GetItemType(ingredientName);
                        if (ingredientType != 0)
                        {
                            recipe.AddIngredient(ingredientType, ingredientQuantity);
                            Mod.Logger.Info($"Added ingredient: {ingredientName} (Quantity: {ingredientQuantity})");
                        }
                        else
                        {
                            Mod.Logger.Warn($"Ingredient not found: {ingredientName}");
                        }
                    }

                    // Add Crafting Station
                    if (matchingRecipe.TryGetValue("station", out JToken stationToken))
                    {
                        int stationType = GetTileType(stationToken.ToString());
                        if (stationType != 0)
                        {
                            recipe.AddTile(stationType);
                            Mod.Logger.Info($"Added crafting station: {stationToken}");
                        }
                        else
                        {
                            Mod.Logger.Warn($"Crafting station not found: {stationToken}");
                        }
                    }

                    Mod.Logger.Info($"Recipe modified for: {resultName}");
                }
            }

            Mod.Logger.Info("Recipe modifications complete!");
        }
        private int GetItemType(string itemName)
        {
            // Split the item name into mod name and item name
            string[] parts = itemName.Split(':');
            string modName;
            string name;

            // Handle cases where the item name does not contain a colon
            if (parts.Length == 1)
            {
                // Assume it's a vanilla item
                modName = "Terraria";
                name = parts[0];
            }
            else if (parts.Length == 2)
            {
                // The item name contains a colon (e.g., "Terraria:Feather")
                modName = parts[0];
                name = parts[1];
            }
            else
            {
                // Invalid format
                Mod.Logger.Warn($"Invalid item name format: {itemName}");
                return 0;
            }

            // Resolve the item type
            if (modName == "Terraria")
            {
                if (ItemID.Search.TryGetId(name, out int itemId))
                {
                    return itemId;
                }
            }
            else if (ModLoader.TryGetMod(modName, out Mod mod))
            {
                if (mod.TryFind(name, out ModItem modItem))
                {
                    return modItem.Type;
                }
            }

            Mod.Logger.Warn($"Item not found: {itemName}");
            return 0; // Item not found
        }

        private int GetTileType(string tileName)
        {
            // Split the tile name into mod name and tile name
            string[] parts = tileName.Split(':');
            string modName;
            string name;

            // Handle cases where the tile name does not contain a colon
            if (parts.Length == 1)
            {
                // Assume it's a vanilla tile
                modName = "Terraria";
                name = parts[0];
            }
            else if (parts.Length == 2)
            {
                // The tile name contains a colon (e.g., "Terraria:MythrilAnvil")
                modName = parts[0];
                name = parts[1];
            }
            else
            {
                // Invalid format
                Mod.Logger.Warn($"Invalid tile name format: {tileName}");
                return 0;
            }

            // Resolve the tile type
            if (modName == "Terraria")
            {
                if (TileID.Search.TryGetId(name, out int tileId))
                {
                    return tileId;
                }
            }
            else if (ModLoader.TryGetMod(modName, out Mod mod))
            {
                if (mod.TryFind(name, out ModTile modTile))
                {
                    return modTile.Type;
                }
            }

            Mod.Logger.Warn($"Tile not found: {tileName}");
            return 0; // Tile not found
        }
    }
}
