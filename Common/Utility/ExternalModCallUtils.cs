using CalamityMod.Projectiles.Magic;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Utility
{
    public class ExternalModCallUtils
    {
        public struct CacheItem
        {
            public Mod mod;
            public string name;
            public ModItem instance;
        }
        public struct CacheProjectile
        {
            public Mod mod;
            public string name;
            public ModProjectile instance;
        }
        public struct CacheNpc
        {
            public Mod mod;
            public string name;
            public ModNPC instance;
        }
        public static HashSet<CacheItem> ItemsCache { get; set; } = [];
        public static ModItem GetItemFromMod(Mod mod, string item)
        {
            foreach (CacheItem cache in ItemsCache)
            {
                if (cache.mod == mod && cache.name == item)
                    return cache.instance;
            }      

            mod.TryFind(item, out ModItem OutItem);
            ItemsCache.Add(new CacheItem { mod = mod, name = item, instance = OutItem });
            return OutItem;
        }

        public static HashSet<CacheProjectile> ProjectileCache { get; set; } = [];
        public static ModProjectile GetProjectileFromMod(Mod mod, string projectile)
        {
            foreach (CacheProjectile cache in ProjectileCache)
            {
                if (cache.mod == mod && cache.name == projectile)
                    return cache.instance;
            }

            mod.TryFind(projectile, out ModProjectile OutProjectile);
            ProjectileCache.Add(new CacheProjectile { mod = mod, name = projectile, instance = OutProjectile });
            return OutProjectile;
        }
        public static ModTile GetTileFromMod(Mod mod, string tile)
        {
            mod.TryFind(tile, out ModTile OutTile);
            return OutTile;
        }

        public static HashSet<CacheNpc> NpcCache { get; set; } = [];
        public static ModNPC GetNpcFromMod(Mod mod, string npc)
        {
            foreach (CacheNpc cache in NpcCache)
            {
                if (cache.mod == mod && cache.name == npc)
                    return cache.instance;
            }

            mod.TryFind(npc, out ModNPC OutNpc);
            NpcCache.Add(new CacheNpc { mod = mod, name = npc, instance = OutNpc });
            return OutNpc;
        }
        public static DamageClass GetDamageClassFromMod(Mod mod, string damageClass)
        {
            mod.TryFind(damageClass, out DamageClass OutDamageClass);
            return OutDamageClass;
        }
        public static ModBuff GetBuffFromMod(Mod mod, string buff)
        {
            mod.TryFind(buff, out ModBuff OutBuff);
            return OutBuff;
        }
        public static ModDust GetDustFromMod(Mod mod, string dust)
        {
            mod.TryFind(dust, out ModDust OutDust);
            return OutDust;
        }
        public static ModPrefix GetPrefixFromMod(Mod mod, string prefix)
        {
            mod.TryFind(prefix, out ModPrefix OutPrefix);
            return OutPrefix;
        }
        public static ModRarity GetRarityFromMod(Mod mod, string rarity)
        {
            mod.TryFind(rarity, out ModRarity OutRarity);
            return OutRarity;
        }
        public static int GetModPrefix(Mod mod, string name)
        {
            return mod.TryFind<ModPrefix>(name, out var ret) ? ret.Type : 0;
        }
        public static ModPlayer GetPlayerFromMod(Mod mod, string player)
        {
            mod.TryFind(player, out ModPlayer OutPlayer);
            return OutPlayer;
        }
    }
}
