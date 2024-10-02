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
		

		// Changes following Vanilla Weapons To Rogue
		private const List<short> VanillaWeaponsToRogue = new List<short>
		{
        		ItemID.BoneJavelin,
        		ItemID.ThrowingKnife,
        		ItemID.Shuriken,
	        	ItemID.BoneDagger,
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
			foreach (int vanillaWeaponId in VanillaWeaponsToRogue)
			{
				if (item.type == vanillaWeaponId)
				{
					item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					base.SetDefaults(item);
				}
			}
		}
	}
}
