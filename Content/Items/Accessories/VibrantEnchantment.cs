using Microsoft.Xna.Framework;
using SOTS;
using SOTS.Items.Earth;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheBereftSouls.Common.Players;

namespace TheBereftSouls.Content.Items.Accessories;

[ExtendsFromMod("SOTS")]
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
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.rare = ItemRarityID.Green;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        SOTSPlayer.ModPlayer(player).CritBonusMultiplier += 0.2f; // Only applies to melee weapons (just how SOTS coded it)
        SOTSPlayer.ModPlayer(player).HarvestersScythe = true;
        player.GetModPlayer<BereftSOTSPlayer>().VibrantEnch = true;
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

[JITWhenModsEnabled("SOTS")]
[ExtendsFromMod("SOTS")]
public class VibrantItem : GlobalItem
{
    private float chanceToFire = 0.8f; // 80% chance to shoot

    public override bool InstancePerEntity => true;

    public override bool Shoot(
        Item item,
        Player player,
        EntitySource_ItemUse_WithAmmo source,
        Vector2 position,
        Vector2 velocity,
        int type,
        int damage,
        float knockback
    )
    {
        if (item.damage <= 0)
        {
            return true; // Only work on weapons
        }

        if (
            player.GetModPlayer<BereftSOTSPlayer>().VibrantEnch
            && chanceToFire >= Main.rand.NextFloat()
        )
        {
            if (Main.myPlayer == player.whoAmI)
            {
                Projectile.NewProjectile(
                    source,
                    position,
                    (velocity / 2).RotatedByRandom(MathHelper.Pi / 6),
                    type,
                    damage / 2,
                    knockback
                ); // Additional projectiles deal half damage and move at half speed (should be tested)
            }

            if (chanceToFire >= 0)
            {
                chanceToFire -= 0.1f;
            }
        }

        return true;
    }

    public override void UpdateInventory(Item item, Player player)
    {
        if (item.type != player.HeldItem.type)
        {
            chanceToFire = 0.8f;
        }
    }
}
