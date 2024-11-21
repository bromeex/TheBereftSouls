using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Utils
{
    public class ExternalModCallUtils
    {

        public static T Get<T>(Mod mod, string name)
        {
            CacheManager<T>.LRUCache cache = new (1);

            var value = cache.Get(name, out Mod modAux);

            if (value != null && modAux == mod)
            {
                return value;
            }

            mod.TryFind(name, out IModType outItem);
            cache.UpdateSize();
            cache.Put(name, mod, (T)outItem);

            return (T)outItem;
        }
    }
}
