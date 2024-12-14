using Terraria;
using Terraria.ModLoader;
using SOTS.Items.Permafrost;
using FargowiltasSouls.Content.Items.Weapons.Misc;
using FargowiltasSouls.Content.Items.Accessories.Masomode;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("SOTS", "FargowiltasSouls")]

public class DubiousCircutry : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<DubiousCircuitry>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>());
			break;
		}
	}
}

public class TopHatSquirrelWeapon : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<TophatSquirrelWeapon>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 3);
			break;
		}
	}
}