using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace TheBereftSouls.Common.Global
{
	public class GlobalSpiritModItem : GlobalItem
	{
		//Untested - JIT used to prevent crashes if Calamity isn't enabled.
		

		// Changes following Spirit Weapons To Rogue
		private static List<string> Spirit_Weapons_To_Rogue = new List<string>
		{
			"BismiteGrenade",
			"DodgeBall",
			"DuskfeatherDagger",
			"ExplosiveRum",
			"Kunai_Throwing",
			"SoaringScapula"
		};
		[JITWhenModsEnabled("CalamityMod","SpiritMod")]
		public override void SetDefaults(Item item)
		{
			// Checks to see if Calamity and Spirit are installed before making changes.
			if (!ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod) | !ModLoader.TryGetMod("SpiritMod", out Mod SpiritMod))
			{
				return;
			}
			foreach (string Spirit_Weapon_Name in Spirit_Weapons_To_Rogue)
			{
				if (item.type == SpiritMod.Find<ModItem>(Spirit_Weapon_Name).Type)
				{
					item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					base.SetDefaults(item);
				}
			}
			// Uses list to change all listed weapons to Rogue
		}
	}
}
