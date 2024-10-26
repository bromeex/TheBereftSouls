using Terraria.ModLoader;
using Terraria;
using TheBereftSouls.Content.DamageClasses;
using SOTS.Projectiles.Ores;

namespace TheBereftSouls.Content.Projectiles.Rogue.Void
{
    public class GoldChakramProjectileOverride : GoldChakram
    {
        public override string Texture => "SOTS/Projectiles/Ores/GoldChakram";
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<GoldChakram>());
            Projectile.DamageType = ModContent.GetInstance<VoidRogue>();
        }

    }
}
