using CalamityMod;
using Microsoft.Xna.Framework.Graphics;
using SOTS.Projectiles.Ores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Void;

namespace TheBereftSouls.Projectiles.Rogue.Void
{
    public class GoldChakramProjectileOverride : GoldChakram
    {
        public override string Texture => "SOTS/Projectiles/Ores/GoldChakram";
        public override void SetDefaults()
        {
            Projectile.height = 32;
            Projectile.width = 32;
            Projectile.penetrate = -1;
            Projectile.DamageType = ModContent.GetInstance<VoidRogue>();
            Projectile.tileCollide = true;
            Projectile.timeLeft = 715;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.extraUpdates = 2;
        }
        
    }
}