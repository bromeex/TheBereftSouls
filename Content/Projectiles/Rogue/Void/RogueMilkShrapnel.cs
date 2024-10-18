using SOTS.Projectiles.Tide;
using Terraria.ModLoader;
using TheBereftSouls.Content.DamageClasses;


namespace TheBereftSouls.Content.Projectiles.Rogue.Void
{
    public class RogueMilkShrapenel : CoconutShrapnel
    {
        public override string Texture => "SOTS/Projectiles/Tide/CoconutShrapnel";
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<CoconutShrapnel>());
            Projectile.DamageType = ModContent.GetInstance<VoidRogue>();
        }
    }
}