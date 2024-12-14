using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Items.Permafrost;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("CalamityMod", "ThoriumMod", "SOTS", "FargowiltasSouls", "CombinationsMod", "Consolaria", "MagicStorage")]

public class TrueNightsEdge : ModSystem
{
	public override void PostAddRecipes()
	{
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type !=ItemID.TrueNightsEdge)
				continue;
		
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 3);
			break;
		}
	}
}

public class MechanicalGlove : ModSystem
{
	public override void PostAddRecipes()
	{
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ItemID.MechanicalGlove)
				continue;
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
			if (recipe.createItem.type != ItemID.CelestialEmblem)
				continue;
			recipe.DisableRecipe();
		}
			Recipe newRecipe = Recipe.Create(result:ItemID.CelestialEmblem);
			newRecipe.AddIngredient(ItemID.CelestialMagnet);
			newRecipe.AddIngredient(ItemID.AvengerEmblem);
			newRecipe.AddTile(TileID.TinkerersWorkbench);
			newRecipe.Register();
	}
}