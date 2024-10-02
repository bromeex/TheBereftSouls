using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace TheBereftSouls.Common.Global
{
	public class GlobalVanillaItem : GlobalItem
	{
		//Untested - JIT used to prevent crashes if Calamity isn't enabled.
		

		// Changes following Vanilla Weapons To Rogue, uses Integer due to how Vanilla ID work
		// In order its Bone Javelin, Throwing Knife, Shuriken and Bone Dagger
		private static List<int> Vanilla_Weapons_To_Rogue = new List<int>
		{
			3378,
			279,
			42,
			3379
		};

		[JITWhenModsEnabled("CalamityMod")]
		public override void SetDefaults(Item item)
		{
			// Checks to see if Calamity are installed before making changes.
			if (!ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod))
			{
				return;
			}
			// Uses list to change all listed weapons to Rogue
			foreach (int Vanilla_Weapon_ID in Vanilla_Weapons_To_Rogue)
			{
				if (item.type == Vanilla_Weapon_ID)
				{
					item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					base.SetDefaults(item);
				}
			}
		}
	}
}
