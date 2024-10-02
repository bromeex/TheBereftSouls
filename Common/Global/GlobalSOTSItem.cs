using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Global
{
	public class GlobalSOTSItem : GlobalItem
	{
		//Untested - JIT used to prevent crashes if Calamity isn't enabled.
		[JITWhenModsEnabled("CalamityMod","SOTS")]//,JITWhenModsEnabled("SOTS")]
		//[JITWhenModsEnabled("SOTS")]
		public override void SetDefaults(Item item)
		{
			if(TheBereftSouls.CalamityMod != null & TheBereftSouls.SOTS != null)
			{
				if (ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod) & ModLoader.TryGetMod("SOTS", out Mod SOTS))
				{
					// Changes Gel Throwing Axe, Winged Knife, Berry Bombs and Explosive Knife to Rogue damage class.
					// No changes done to Gold Chakram as that involves Void, never interacted with Void so I'll leave that to people who know more. - Cyber64.
					if (item.type == SOTS.Find<ModItem>("GelAxe").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == SOTS.Find<ModItem>("WingedKnife").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == SOTS.Find<ModItem>("BerryBombs").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == SOTS.Find<ModItem>("ExplosiveKnife").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
				}
			}
		}
	}
}
