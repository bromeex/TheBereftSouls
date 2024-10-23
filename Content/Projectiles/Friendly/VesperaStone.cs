using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Items.Earth;
using SOTS;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using SOTS.Items.Invidia;
using SOTS.Projectiles.Earth;
using TheBereftSouls.Content.Tiles.Special;
using TheBereftSouls.Content.Items.Accessories;

namespace TheBereftSouls.Content.Projectiles.Friendly
{
    public class VesperaStone : ModProjectile
    {
        ref float AITimer => ref Projectile.ai[0];

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 30;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                for (int i = -1; i < 1; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(i * 36)).SafeNormalize(Vector2.Zero) * 5, ModContent.ProjectileType<BigEvostonePebble>(), 15, 0.1f);
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

        void PlaceStone()
        {
            if (Main.myPlayer == Projectile.owner)
            {
                Point point = Projectile.position.ToTileCoordinates();
                WorldGen.PlaceTile(point.X, point.Y, ModContent.TileType<VesperaStoneBlock>());
                NetMessage.SendTileSquare(-1, point.X, point.Y);

                Main.player[Projectile.owner].GetModPlayer<VesperaEnchPlayer>().vesperaStoneXCOORDS.Add(point.X);
                Main.player[Projectile.owner].GetModPlayer<VesperaEnchPlayer>().vesperaStoneYCOORDS.Add(point.Y);

            }
        }
    }
}
