using CalamityMod.Projectiles.Magic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TheBereftSouls.Utils;

namespace TheBereftSouls.Common.Global
{
    public class TBSGlobalProjectile : GlobalProjectile
    {

        public override bool InstancePerEntity => true;  
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (TheBereftSouls.CalamityMod != null)
                OnSpawnCalamity(projectile, source);
        }

        [JITWhenModsEnabled("CalamityMod")]
        public void OnSpawnCalamity(Projectile projectile, IEntitySource source)
        {
            if (TheBereftSouls.CalamityRangerExpansion != null)
            {
                if (projectile.type == ExternalModCallUtils.Get<ModProjectile>(TheBereftSouls.CalamityRangerExpansion, "WulfrumBoltRanged").Type)
                {
                    WulfrumBolt.HomingRange = 150;
                }
            }
        }
    }
}
