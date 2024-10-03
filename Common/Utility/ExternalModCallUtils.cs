using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Utility
{
    public class ExternalModCallUtils
    {
        public static int GetItemFromMod(Mod mod, string item)
        {
            return mod.Find<ModItem>(item).Type;
        }
        public static ModProjectile GetProjectileFromMod(Mod mod, string projectile)
        {
            mod.TryFind(projectile, out ModProjectile Projectile);
            return Projectile;
        }
        public static int GetTileFromMod(Mod mod, string tile)
        {
            return mod.Find<ModTile>(tile).Type;
        }
        public static int GetNpcFromMod(Mod mod, string npc)
        {
            return mod.Find<ModNPC>(npc).Type;
        }
        public static DamageClass GetDamageClassFromMod(Mod mod, string damageClass)
        {
            return mod.Find<DamageClass>(damageClass);
        }
        public static int GetBuffFromMod(Mod mod, string buff)
        {
            return mod.Find<ModBuff>(buff).Type;
        }
        public static int GetDustFromMod(Mod mod, string dust)
        {
            return mod.Find<ModDust>(dust).Type;
        }
        public static int GetPrefixFromMod(Mod mod, string prefix)
        {
            return mod.Find<ModPrefix>(prefix).Type;
        }
        public static int GetRarityFromMod(Mod mod, string rarity)
        {
            return mod.Find<ModRarity>(rarity).Type;
        }
        public static int GetModPrefix(Mod mod, string name)
        {
            return mod.TryFind<ModPrefix>(name, out var ret) ? ret.Type : 0;
        }
        public static ModPlayer GetPlayerFromMod(Mod mod, string player)
        {
            return mod.Find<ModPlayer>(player);
        }
    }
}
