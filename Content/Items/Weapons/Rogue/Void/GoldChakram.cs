using SOTS;
using Microsoft.Xna.Framework;
using SOTS;
using TheBereftSouls.Content.DamageClasses;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using TheBereftSouls.Content.Projectiles.Rogue.Void;
using SOTS.Items.OreItems;

namespace TheBereftSouls.Content.Items.Weapons.Rogue.Void
{
    public class GoldChakramOverride : VoidDamageItem
    {
        public override string Texture => "SOTS/Items/OreItems/GoldChakram";
        public override void SetStaticDefaults()
        {
            this.SetResearchCost(1);
        }
        public override void SetItemDefaults()
        {
            //Item.SetNameOverride("Gold Chakram");
            Item.CloneDefaults(ModContent.ItemType<GoldChakram>());
            Item.SetNameOverride("Gold Chakram");
            Item.DamageType = ModContent.GetInstance<RogueDamageClass>();
            Item.shoot = ModContent.ProjectileType<GoldChakramProjectileOverride>();
        }
        public override int GetVoid(Player player)
        {
            return 7;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.GoldBar, 15).AddTile(TileID.Anvils).Register();
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            Item.DamageType = ModContent.GetInstance<VoidRogue>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.Calamity().StealthStrikeAvailable())
            {
                int spread = 10;
                for (int i = 0; i < 3; i++)
                {
                    Vector2 perturbedspeed = velocity.RotatedBy(MathHelper.ToRadians(spread));
                    int p = Projectile.NewProjectile(source, position.X, position.Y, perturbedspeed.X, perturbedspeed.Y, type, damage * 2, knockback, player.whoAmI, 0f, 1f);
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