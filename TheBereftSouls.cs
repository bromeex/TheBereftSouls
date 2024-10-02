using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace TheBereftSouls
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class TheBereftSouls : Mod
	{
		public static Mod CalamityMod;
		public static Mod CalamityAmmo;
		public static Mod SpiritMod;
		public static Mod SOTS;

		public override void Load(){
			ModLoader.TryGetMod("CalamityMod", out CalamityMod);
			ModLoader.TryGetMod("CalamityAmmo", out CalamityAmmo);
			ModLoader.TryGetMod("SpiritMod", out SpiritMod);
			ModLoader.TryGetMod("SOTS", out SOTS);
		}
	}
}
