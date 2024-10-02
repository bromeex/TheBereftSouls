using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Global
{
	public class GlobalCalamityAmmoItem : GlobalItem
	{
		//Untested - JIT used to prevent crashes if Calamity Ranger Expansion isn't enabled.
		[JITWhenModsEnabled("CalamityAmmo")]
		public override void SetDefaults(Item item)
		{
			if(TheBereftSouls.CalamityAmmo != null)
			{
				if (ModLoader.TryGetMod("CalamityAmmo", out Mod CalamityAmmo))
				{
					// Nerfed Wulfrum Bullets to deal less damage. Armour Penetration stat doesn't work?
					// I used Minishark and Flintlock with Wulfrum Bullets and Silver Bullets on a variety of defence stats and the nerfed Wulfrum did 1 damage less on average.
					// I assume Wulfrum Bullet Projectile doesn't apply Armour Penetration properly.
					// Without internal values / source code of the projectile, no way to actually implement Armour Penetration without creating a new projectile.
					// - Cyber64
					if(item.type == CalamityAmmo.Find<ModItem>("WulfrumBullet").Type)
					{
						item.damage = 5;
					}
					base.SetDefaults(item);
				}
			}
		}
	}
}
