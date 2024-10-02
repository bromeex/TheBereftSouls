using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace TheBereftSouls.Common.Global
{
	public class GlobalSOTSItem : GlobalItem
	{
		//Untested - JIT used to prevent crashes if Calamity isn't enabled.
		

		// Changes following SOTS Weapons To Rogue
		private static List<string> SOTSWeaponsToRogue = new List<string>
		{
			"GelAxe",
			"WingedKnife",
			"BerryBombs",
			"ExplosiveKnife"
		};

		[JITWhenModsEnabled("CalamityMod","SOTS")]
		public override void SetDefaults(Item item)
		{
			// Checks to see if Calamity and SOTS are installed before making changes.
			if (!ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod) | !ModLoader.TryGetMod("SOTS", out Mod SOTS))
			{
				return;
			}
			// Uses list to change all listed weapons to Rogue
			foreach (string SOTSWeaponName in SOTSWeaponsToRogue)
			{
				if (item.type == SOTS.Find<ModItem>(SOTSWeaponName).Type)
				{
					item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					base.SetDefaults(item);
				}
			}
		}
	}
}
