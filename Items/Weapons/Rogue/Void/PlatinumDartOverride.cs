using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TheBereftSouls.Void;
using SOTS;
using TheBereftSouls.Projectiles.Rogue.Void;
using CalamityMod;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using SOTS.Items.OreItems;

namespace TheBereftSouls.Items.Weapons.Rogue.Void
{
    public class PlatinumDartOverride : VoidDamageItem
    {
        public override string Texture => "SOTS/Items/OreItems/PlatinumDart";
        public override void SetStaticDefaults()
        {
            this.SetResearchCost(1);
        }
        public override void SafeSetDefaults()
        {
            Item.SetNameOverride("Platinum Dart"); 
            Item.CloneDefaults(ModContent.ItemType<PlatinumDart>());
            Item.DamageType = ModContent.GetInstance<RogueDamageClass>();
            Item.shoot = ModContent.ProjectileType <PlatinumDartProjectileOverride>();
        }
        public override int GetVoid(Player player)
        {
            return 7;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.GoldBar, 15).AddTile(TileID.Anvils).Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            if (player.Calamity().StealthStrikeAvailable())
            {
                int spread = 20;
                for (int i = 0; i < 5; i++)
                {
                    Vector2 perturbedspeed = velocity.RotatedBy(MathHelper.ToRadians(spread));
                    int p = Projectile.NewProjectile(source, position.X, position.Y, perturbedspeed.X, perturbedspeed.Y, type, damage*2, knockback, player.whoAmI, 0f, 1f);
                    if (p.WithinBounds(Main.maxProjectiles))
                        Main.projectile[p].Calamity().stealthStrike = true;
                    spread -= 10;
                }
                return false;
            }
            return true;
        }
    }
}