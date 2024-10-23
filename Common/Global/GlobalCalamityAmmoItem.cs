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
			if (!ModLoader.TryGetMod("CalamityAmmo", out Mod CalamityAmmo))
			{
				return;
			}
			// Nerf Wulfrum Scrap Bullets to deal less damage.
			// Note: Wulfrum Scrap Bullets do not actually have any armour penetration despite the tooltip saying it does. Without the internal name of projectile, a new projectile would be created if we want armour penetration.
			// - CyberGamer64
			if(item.type == CalamityAmmo.Find<ModItem>("WulfrumBullet").Type)
			{
				item.damage = 5;
			}
			base.SetDefaults(item);
		}
	}
}
