using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TheBereftSouls.Void;
using SOTS;
using TheBereftSouls.Projectiles.Rogue.Void;
using CalamityMod;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace TheBereftSouls.Items.Weapons.Rogue.Void
{
    public class GoldChakramOverride : VoidDamageItem
    {
        public override string Texture => "SOTS/Items/OreItems/GoldChakram";
        public override void SetStaticDefaults()
        {
            this.SetResearchCost(1);
        }
        public override void SafeSetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = ModContent.GetInstance<RogueDamageClass>();
            Item.width = 30;
            Item.height = 34;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item18;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType <GoldChakramProjectileOverride>();
            Item.shootSpeed = 13.5f;
            Item.noUseGraphic = true;
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
                int spread = 10;
                for (int i = 0; i < 3; i++)
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