using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Items.Earth;
using SOTS;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace TheBereftSouls.Content.Items.Accessories
{
    public class VibrantEnchantment : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 34;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 30);
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SOTSPlayer.ModPlayer(player).CritBonusMultiplier += 0.2f;
            SOTSPlayer.ModPlayer(player).HarvestersScythe = true;
            player.GetModPlayer<VibrantEnchPlayer>().vibrantEnch = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VibrantHelmet>());
            recipe.AddIngredient(ModContent.ItemType<VibrantChestplate>());
            recipe.AddIngredient(ModContent.ItemType<VibrantLeggings>());
            recipe.AddIngredient(ModContent.ItemType<HarvestersScythe>());
            recipe.AddIngredient(ModContent.ItemType<EchoDisk>());
            recipe.AddIngredient(ModContent.ItemType<VibrantStaff>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

        }
    }

    public class VibrantEnchPlayer : ModPlayer
    {
        public bool vibrantEnch = false;

        public override void ResetEffects()
        {
            vibrantEnch = false;
        }
    }

    public class VibrantItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        float chanceToFire = 0.8f;

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.GetModPlayer<VibrantEnchPlayer>().vibrantEnch && chanceToFire >= Main.rand.NextFloat())
            {
                if (Main.myPlayer == player.whoAmI)
                {
                    Projectile.NewProjectile(source, position, (velocity / 2).RotatedByRandom(MathHelper.PiOver4), type, damage, knockback);
                }
                if (chanceToFire >= 0)
                {
                    Main.NewText(chanceToFire);
                    chanceToFire -= 0.1f;
                }
            }
            return true;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            base.UpdateInventory(item, player);
            if (item.type != player.HeldItem.type)
            {
                chanceToFire = 0.8f;
            }
        }
    }
}
