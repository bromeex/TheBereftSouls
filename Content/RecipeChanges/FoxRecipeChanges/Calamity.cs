using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Materials;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.ThrownItems;
using SOTS.Items.Permafrost;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("CalamityMod", "SOTS", "ThoriumMod")]

public class AngelTreads : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Accessories.AngelTreads>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>());
			break;
		}
	}
}

public class HallowedRune : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Accessories.HallowedRune>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
			break;
		}
	}
}

public class MOAB : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Accessories.Wings.MOAB>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>());
			break;
		}
	}
}

public class BloodOrange : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.PermanentBoosters.BloodOrange>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
			break;
		}
	}
}

public class ValkyrieRay : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Weapons.Magic.ValkyrieRay>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>());
			break;
		}
	}
}

public class CatastropheClaymore : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Weapons.Melee.CatastropheClaymore>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 3);
			break;
		}
	}
}

public class Pwnagehammer : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Pwnagehammer>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 3);
			break;
		}
	}
}

public class BiomeBlade : ModSystem
{
	public override void PostAddRecipes()
	{
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<TrueBiomeBlade>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>());
			break;
		}
	}
}

public class Exorcism : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.Exorcism>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 6);
			break;
		}
	}
}

public class SpearOfDestiny : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<SpearofDestiny>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
		}
	}
}

public class VengefulSunStaff : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Weapons.Summon.VengefulSunStaff>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 3);
			break;
		}
	}
}

public class GalacticaSingularity : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<CalamityMod.Items.Materials.GalacticaSingularity>())
				continue;

			recipe.DisableRecipe();
		}
			Recipe newRecipe = Recipe.Create(result:ModContent.ItemType<CalamityMod.Items.Materials.GalacticaSingularity>(), 2);
			newRecipe.AddIngredient(ItemID.FragmentVortex);
			newRecipe.AddIngredient(ItemID.FragmentNebula);
			newRecipe.AddIngredient(ItemID.FragmentSolar);
			newRecipe.AddIngredient(ItemID.FragmentStardust);
			newRecipe.AddIngredient(ModContent.ItemType<ShootingStarFragment>());
			newRecipe.AddIngredient(ModContent.ItemType<CelestialFragment>());
			newRecipe.AddIngredient(ModContent.ItemType<WhiteDwarfFragment>());
			newRecipe.AddIngredient(ModContent.ItemType<MeldBlob>());
			newRecipe.AddTile(TileID.LunarCraftingStation);
			newRecipe.Register();
	}
}