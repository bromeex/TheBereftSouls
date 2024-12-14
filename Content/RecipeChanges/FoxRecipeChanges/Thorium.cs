using Terraria;
using Terraria.ModLoader;
using ThoriumMod.Items.ThrownItems;
using SOTS.Items.Permafrost;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("ThoriumMod", "SOTS")]

public class SubspaceWings : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.Donate.SubspaceWings>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
			break;
		}
	}
}

public class ValkyrieBlade : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.Donate.ValkyrieBlade>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 6);
			break;
		}
	}
}

public class ArchangelHeart : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.HealerItems.ArchangelHeart>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
			break;
		}
	}
}

public class ArchDemonCurse : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.HealerItems.ArchDemonCurse>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
			break;
		}
	}
}

public class TrueBloodHarvest : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.HealerItems.TrueBloodHarvest>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 20);
			break;
		}
	}
}

public class TrueFallingTwilight : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.HealerItems.TrueFallingTwilight>())
				continue;
			
			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 20);
			break;
		}
	}
}

public class BlackholeCannon : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.MagicItems.BlackholeCannon>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 20);
			break;
		}
	}
}

public class TimeWarp : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.Misc.TimeWarp>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 4);
			break;
		}
	}
}

public class SoulForge : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.Placeable.SoulForge>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
		}
	}
}

public class ThrowingGuideVolume3 : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.ThrownItems.ThrowingGuideVolume3>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 5);
			break;
		}
	}
}

public class TrueEmbowlment : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<TrueEmbowelment>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 20);
			break;
		}
	}
}

public class TrueLightAnguish : ModSystem
{
	public override void PostAddRecipes()
	{	
		foreach (var recipe in Main.recipe)
		{
			if (recipe.createItem.type != ModContent.ItemType<ThoriumMod.Items.ThrownItems.TrueLightAnguish>())
				continue;

			recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), 20);
			break;
		}
	}
}