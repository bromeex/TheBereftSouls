using SOTS.Projectiles.Tide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using TheBereftSouls.Void;

namespace TheBereftSouls.Projectiles.Rogue.Void
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
