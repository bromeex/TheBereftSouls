using Terraria;
using Terraria.ModLoader;
using SOTS.Items.Permafrost;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("SOTS", "Consolaria")]

public class SuspiciousLookingSkull : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<Consolaria.Content.Items.Summons.SuspiciousLookingSkull>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
			break;
		}
	}
}