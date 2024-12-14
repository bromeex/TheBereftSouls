using Terraria;
using Terraria.ModLoader;
using SOTS.Items.Permafrost;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("SOTS", "MagicStorage")]

public class HallowedStorageUpgrade : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<MagicStorage.Items.UpgradeHallowed>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>());
			break;
		}
	}
}