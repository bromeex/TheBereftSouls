using Microsoft.Xna.Framework;
using SOTS.Projectiles.Earth;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheBereftSouls.Content.Tiles.Special;
using TheBereftSouls.Players;
using TheBereftSouls.Utils;

namespace TheBereftSouls.Content.Projectiles.Friendly
{
    [ExtendsFromMod("SOTS")]
    public class VesperaStone : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 30;
            Projectile.alpha = 100;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PureSpray);
            Projectile.rotation += MathHelper.ToRadians(Projectile.timeLeft);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                for (int i = -1; i < 1; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(i * 36)).SafeNormalize(Vector2.Zero) * 5, ModContent.ProjectileType<BigEvostonePebble>(), 15, 0.1f);
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            PlaceStone();
            return true;
        }

        public override void OnKill(int timeLeft)
        {
            if (timeLeft <= 1)
            {
                PlaceStone();
            }
        }

        private void PlaceStone()
        {
            if (Main.myPlayer == Projectile.owner)
            {
                Point point = Projectile.position.ToTileCoordinates();
                WorldGen.PlaceTile(point.X, point.Y, ModContent.TileType<VesperaStoneBlock>());
                NetMessage.SendTileSquare(-1, point.X, point.Y);
                BereftUtils.DustCircle(Main.player[Projectile.owner].Center, 16, 10, DustID.PureSpray);
                Main.player[Projectile.owner].GetModPlayer<BereftSOTSPlayer>().VesperaStoneCoords.Add(new Vector2(point.X, point.Y));
            }
        }
    }
}
