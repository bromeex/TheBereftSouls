using Terraria;
using Terraria.ModLoader;
using SOTS.Items.Permafrost;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("SOTS")]
public class FrostKey : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<FrostedKey>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>());
			break;
		}
	}
}
