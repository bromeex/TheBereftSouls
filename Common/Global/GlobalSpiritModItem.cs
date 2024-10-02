using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Global
{
	public class GlobalSpiritModItem : GlobalItem
	{
		//Untested - JIT used to prevent crashes if Calamity isn't enabled.
		[JITWhenModsEnabled("CalamityMod","SpiritMod")]//,JITWhenModsEnabled("SpiritMod")]
		//[JITWhenModsEnabled("SpiritMod")]
		public override void SetDefaults(Item item)
		{
			if(TheBereftSouls.CalamityMod != null & TheBereftSouls.SpiritMod != null)
			{
				if (ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod) & ModLoader.TryGetMod("SpiritMod", out Mod SpiritMod))
				{
					// Changes Soaring Scapula, Duskfeather Dagger, Lightning Throw (DodgeBall Internally), Explosive Rum, Kunai and Bismite Grenade to Rogue damage class. - Cyber64
					if (item.type == SpiritMod.Find<ModItem>("SoaringScapula").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == SpiritMod.Find<ModItem>("DuskfeatherDagger").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == SpiritMod.Find<ModItem>("DodgeBall").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == SpiritMod.Find<ModItem>("ExplosiveRum").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == SpiritMod.Find<ModItem>("Kunai_Throwing").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == SpiritMod.Find<ModItem>("BismiteGrenade").Type)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
				}
			}
		}
	}
}
