using Microsoft.Xna.Framework;
using SOTS;
using TheBereftSouls.Void;
using TheBereftSouls.Projectiles.Rogue.Void;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using ThoriumMod;

namespace TheBereftSouls.Items.Weapons.Bard.Void
{
    public class VoidTrumpet : VoidDamageItem
    {
        public override string Texture => "TheBereftSouls/Items/Weapons/Bard/Void/ObsidianBoneTrumpet";

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
            Item.shoot = ModContent.ProjectileType<voidCoconutProj>();
            Item.shootSpeed = 15f;
            Item.DamageType = ModContent.GetInstance<BardDamage>();

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