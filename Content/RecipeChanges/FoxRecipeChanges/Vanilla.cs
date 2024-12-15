using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod()]

public class MechanicalGlove : ModSystem
{
	public override void PostAddRecipes()
	{
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type == ItemID.MechanicalGlove)
				recipe.DisableRecipe();
		}
			Recipe newRecipe = Recipe.Create(result:ItemID.MechanicalGlove);
			newRecipe.AddIngredient(ItemID.PowerGlove);
			newRecipe.AddIngredient(ItemID.AvengerEmblem);
			newRecipe.AddTile(TileID.TinkerersWorkbench);
			newRecipe.Register();
	}
}

public class CelestialEmblem : ModSystem
{
	public override void PostAddRecipes()
	{
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type == ItemID.CelestialEmblem)
				recipe.DisableRecipe();
		}
			Recipe newRecipe = Recipe.Create(result:ItemID.CelestialEmblem);
			newRecipe.AddIngredient(ItemID.CelestialMagnet);
			newRecipe.AddIngredient(ItemID.AvengerEmblem);
			newRecipe.AddTile(TileID.TinkerersWorkbench);
			newRecipe.Register();
	}
}