using Microsoft.Xna.Framework;
using SOTS;
using TheBereftSouls.Content.DamageClasses;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using TheBereftSouls.Content.Projectiles.Rogue.Void;

namespace TheBereftSouls.Content.Items.Weapons.Rogue.Void
{
    public class VoidCoconut : VoidDamageItem
    {
        public override string Texture => "SOTS/Projectiles/Tide/Coconut";
        public override void SetStaticDefaults()
        {
            this.SetResearchCost(1);
        }
        public override void SafeSetDefaults()
        {
            Item.width = 40;
            Item.height = 36;
            Item.damage = 20;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.knockBack = 1f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.value = 1000;
            Item.rare = ItemRarityID.Orange;
            Item.value = 10;
            Item.shoot = ModContent.ProjectileType<VoidCoconutProj>();
            Item.shootSpeed = 15f;
            Item.DamageType = ModContent.GetInstance<RogueDamageClass>();

        }
        public override int GetVoid(Player player)
        {
            return 5;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.Calamity().StealthStrikeAvailable())
            {
                int p = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI, 0f, 1f);
                if (p.WithinBounds(Main.maxProjectiles))
                    Main.projectile[p].Calamity().stealthStrike = true;
                return false;
            }
            return true;
        }
    }
}