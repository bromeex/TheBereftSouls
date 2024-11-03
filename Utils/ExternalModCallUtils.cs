using Terraria.ModLoader;
using static TheBereftSouls.Utils.CacheManager;

namespace TheBereftSouls.Utils
{
    public class ExternalModCallUtils
    {
        static LRUCache cache = new LRUCache(1);
        public static ModItem GetItemFromMod(Mod mod, string item)
        {
            Mod modAux = null;
            var value = cache.Get(item, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(item, out ModItem OutItem);
            cache.UpdateSize();
            cache.Put(item, mod, OutItem);

            return OutItem;
        }
        public static ModProjectile GetProjectileFromMod(Mod mod, string projectile)
        {
            Mod modAux = null;
            var value = cache.Get(projectile, ref modAux);

            if (value != null && modAux == mod)
                return value;


            mod.TryFind(projectile, out ModProjectile OutProjectile);
            cache.UpdateSize();
            cache.Put(projectile, mod, OutProjectile);

            return OutProjectile;
        }
        public static ModTile GetTileFromMod(Mod mod, string tile)
        {
            Mod modAux = null;
            var value = cache.Get(tile, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(tile, out ModTile OutTile);
            cache.UpdateSize();
            cache.Put(tile, mod, OutTile);

            return OutTile;
        }

        public static ModNPC GetNpcFromMod(Mod mod, string npc)
        {
            Mod modAux = null;
            var value = cache.Get(npc, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(npc, out ModNPC OutNpc);
            cache.UpdateSize();
            cache.Put(npc, mod, OutNpc);

            return OutNpc;
        }
        public static DamageClass GetDamageClassFromMod(Mod mod, string damageClass)
        {
            Mod modAux = null;
            var value = cache.Get(damageClass, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(damageClass, out DamageClass OutDamageClass);
            cache.UpdateSize();
            cache.Put(damageClass, mod, OutDamageClass);

            return OutDamageClass;
        }
        public static ModBuff GetBuffFromMod(Mod mod, string buff)
        {
            Mod modAux = null;
            var value = cache.Get(buff, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(buff, out ModBuff OutBuff);
            cache.UpdateSize();
            cache.Put(buff, mod, OutBuff);

            return OutBuff;
        }
        public static ModDust GetDustFromMod(Mod mod, string dust)
        {
            Mod modAux = null;
            var value = cache.Get(dust, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(dust, out ModDust OutDust);
            cache.UpdateSize();
            cache.Put(dust, mod, OutDust);

            return OutDust;
        }
        public static ModPrefix GetPrefixFromMod(Mod mod, string prefix)
        {
            Mod modAux = null;
            var value = cache.Get(prefix, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(prefix, out ModPrefix OutPrefix);
            cache.UpdateSize();
            cache.Put(prefix, mod, OutPrefix);

            return OutPrefix;
        }
        public static ModRarity GetRarityFromMod(Mod mod, string rarity)
        {
            Mod modAux = null;
            var value = cache.Get(rarity, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(rarity, out ModRarity OutRarity);
            cache.UpdateSize();
            cache.Put(rarity, mod, OutRarity);

            return OutRarity;
        }
        public static int GetModPrefix(Mod mod, string prefix)
        {
            Mod modAux = null;
            var value = cache.Get(prefix, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind<ModPrefix>(prefix, out var OutPrefix);
            cache.UpdateSize();
            cache.Put(prefix, mod, OutPrefix.Type);

            return OutPrefix.Type;
        }
        public static ModPlayer GetPlayerFromMod(Mod mod, string player)
        {
            Mod modAux = null;
            var value = cache.Get(player, ref modAux);

            if (value != null && modAux == mod)
                return value;

            mod.TryFind(player, out ModPlayer OutPlayer);
            cache.UpdateSize();
            cache.Put(player, mod, OutPlayer);

            return OutPlayer;
        }
    }
}
