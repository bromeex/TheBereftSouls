using CalamityMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SOTS.Projectiles.Tide;
using TheBereftSouls.Void;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Projectiles.Rogue.Void
{
    public class voidCoconutProj : ModProjectile, ILocalizedModType
    {
        //public new string LocalizationCategory => "Projectiles.Rogue";
        public override string Texture => "TheBereftSouls/Items/Weapons/Rogue/Void/Coconut";

        private bool recall = false;
        private bool summonMilk = true;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1200;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
            Projectile.DamageType = ModContent.GetInstance<VoidRogue>();
        }

        public override void AI()
        {
            if (Projectile.Calamity().stealthStrike)
            {
                if (Projectile.timeLeft < 1170)//585)
                {
                    recall = true;
                    Projectile.tileCollide = false;
                }
            }
            else
            {
                if (Projectile.timeLeft < 1180)//590)
                {
                    recall = true;
                    Projectile.tileCollide = false;
                }
            }

            Projectile.rotation += 0.4f * Projectile.direction;

            if (recall)
            {
                Vector2 posDiff = Main.player[Projectile.owner].position - Projectile.position;
                if (posDiff.Length() > 30f)
                {
                    posDiff.Normalize();
                    Projectile.velocity = posDiff * 30f;
                }
                else
                {
                    Projectile.timeLeft = 0;
                    OnKill(Projectile.timeLeft);
                }
            }
            else
            {
                if (Projectile.timeLeft % 7 == 1 && Projectile.Calamity().stealthStrike)
                {
                    float MilkSpeed = 5f;
                    int MilkDamage = Projectile.damage / 2;
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(1f, 0f) * MilkSpeed, ModContent.ProjectileType<CoconutShrapnel>(), MilkDamage, 2, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(0f, 1f) * MilkSpeed, ModContent.ProjectileType<CoconutShrapnel>(), MilkDamage, 2, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(-1f, 0f) * MilkSpeed, ModContent.ProjectileType<CoconutShrapnel>(), MilkDamage, 2, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(0f, -1f) * MilkSpeed, ModContent.ProjectileType<CoconutShrapnel>(), MilkDamage, 2, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Normalize(new Vector2(1f, 1f)) * MilkSpeed, ModContent.ProjectileType<CoconutShrapnel>(), MilkDamage, 2, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Normalize(new Vector2(1f, -1f)) * MilkSpeed, ModContent.ProjectileType<CoconutShrapnel>(), MilkDamage, 2, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Normalize(new Vector2(-1f, -1f)) * MilkSpeed, ModContent.ProjectileType<CoconutShrapnel>(), MilkDamage, 2, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Normalize(new Vector2(-1f, 1f)) * MilkSpeed, ModContent.ProjectileType<CoconutShrapnel>(), MilkDamage, 2, Projectile.owner, 0, 0);
                }
            }

            if (Projectile.position == Main.player[Projectile.owner].position)
            {
                OnKill(Projectile.timeLeft);
            }
            return;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D tex = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            Main.EntitySpriteDraw(tex, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, tex.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);
            CalamityUtils.DrawAfterimagesCentered(Projectile, ProjectileID.Sets.TrailingMode[Projectile.type], lightColor, 1);
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (recall)
            {
                return false;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            recall = true;
            Projectile.tileCollide = false;
            return false;
        }
    }
}