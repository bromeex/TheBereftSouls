using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using TheBereftSouls.Common.Utility;

namespace TheBereftSouls.Common.Global
{
	public class GlobalSpiritModItem : GlobalItem
	{
		//Untested - JIT used to prevent crashes if Calamity isn't enabled.
		

		// Changes following Spirit Weapons To Rogue
		private static List<string> SpiritWeaponsToRogue = new List<string>
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
			// Uses list to change all listed weapons to Rogue
			foreach (string spiritWeaponName in SpiritWeaponsToRogue)
			{
				if (item.type == SpiritMod.Find<ModItem>(spiritWeaponName).Type)
				{
					item.DamageType = GetModClass.rogueDamageClass;
					base.SetDefaults(item);
				}
			}
		}
	}
}
