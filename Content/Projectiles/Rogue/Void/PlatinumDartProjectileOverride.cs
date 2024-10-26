using SOTS.Projectiles.Ores;
using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Content.DamageClasses;

namespace TheBereftSouls.Content.Projectiles.Rogue.Void
{
    public class PlatinumDartProjectileOverride : PlatinumDart
    {
        public override string Texture => "SOTS/Projectiles/Ores/PlatinumDart";
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<PlatinumDart>());
            Projectile.DamageType = ModContent.GetInstance<VoidRogue>();
        }

    }
}