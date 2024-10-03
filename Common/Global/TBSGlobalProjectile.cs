using CalamityMod.Projectiles.Magic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TheBereftSouls.Common.Utility;

namespace TheBereftSouls.Common.Global
{
    public class TBSGlobalProjectile : GlobalProjectile
    {

        public override bool InstancePerEntity => true;
        public override void AI(Projectile projectile)
        {

            base.AI(projectile);
        }
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (TheBereftSouls.CalamityRangerExpansion != null)
            {
                if (projectile.type == ExternalModCallUtils.GetProjectileFromMod(TheBereftSouls.CalamityRangerExpansion, "WulfrumBoltRanged").Type)
                {
                    WulfrumBolt.HomingRange = 150;
                }
            }



            base.OnSpawn(projectile, source);
        }
    }
}
