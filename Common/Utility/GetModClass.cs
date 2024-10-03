using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace TheBereftSouls.Common.Utility
{
	public class GetModClass
	{
		// Untested - JIT used to prevent crashes if Calamity Ranger Expansion isn't enabled.
		[JITWhenModsEnabled("CalamityMod")]
		
		// Utility finds Calamity Rogue Damage Type. Hopefully means that ModContent.Find only runs once.
		// More will need to be done to make sure it doesn't crash if certain mods aren't enabled.

		public static DamageClass rogueDamageClass{
			get
			{
				// Return Calamity Rogue if Calamity is installed, otherwise set to Ranged.
				if(!ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod))
				{
					return DamageClass.Ranged;
				}
				return CalamityMod.Find<DamageClass>("RogueDamageClass");
			}
		}
	}
}
