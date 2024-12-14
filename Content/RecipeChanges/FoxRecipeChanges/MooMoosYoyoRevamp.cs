using Terraria;
using Terraria.ModLoader;
using SOTS.Items.Permafrost;
using CombinationsMod.Items.Accessories.Drills;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("SOTS", "CombinationsMod")]

public class Hakapik : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<HakapikDrillCasing>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
			break;
		}
	}
}