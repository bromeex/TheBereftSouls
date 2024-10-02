using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Global
{
	public class GlobalVanillaItem : GlobalItem
	{
		//Untested - JIT used to prevent crashes if Calamity isn't enabled.
		[JITWhenModsEnabled("CalamityMod")]
		public override void SetDefaults(Item item)
		{
			if(TheBereftSouls.CalamityMod != null)
			{
				if (ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod))
				{
					// Changes Bone Javelins, Throwing Knives, Bone Throwing Knives and Shurikens to Rogue damage class. - Cyber64
					if (item.type == ItemID.BoneJavelin)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == ItemID.ThrowingKnife)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == ItemID.Shuriken)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
					if (item.type == ItemID.BoneDagger)
					{
						item.DamageType = CalamityMod.Find<DamageClass>("RogueDamageClass");
					}
					base.SetDefaults(item);
				}
			}
		}
	}
}
