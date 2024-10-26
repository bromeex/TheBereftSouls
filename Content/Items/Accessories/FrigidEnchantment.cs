using SOTS.Items.Permafrost;
using SOTS.Items.Tools;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheBereftSouls.Players;

namespace TheBereftSouls.Content.Items.Accessories
{
    [ExtendsFromMod("SOTS")]
    public class FrigidEnchantment : ModItem
    {
        public static int percentDamage = 10;
        public static int flatDamage = 10;
        public static int crit = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(percentDamage, flatDamage, crit);

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
            player.GetModPlayer<BereftSOTSPlayer>().FrigidEnch = true;
            player.iceSkate = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.Frostburn2] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Chilled] = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FrigidCrown>());
            recipe.AddIngredient(ModContent.ItemType<FrigidRobe>());
            recipe.AddIngredient(ModContent.ItemType<ShatterShardChestplate>());
            recipe.AddIngredient(ModContent.ItemType<FrigidGreaves>());
            recipe.AddIngredient(ModContent.ItemType<ShatterBlade>());
            recipe.AddIngredient(ModContent.ItemType<FrigidPickaxe>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }

    /*[JITWhenModsEnabled("SOTS")]
    public class FrigidItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return BereftSOTSPlayer.FrigidItems.Contains(entity.type);
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (player.GetModPlayer<BereftSOTSPlayer>().FrigidEnch)
            {
                damage += FrigidEnchantment.percentDamage / 100;
                damage.Flat += FrigidEnchantment.flatDamage;
            }
        }

        public override void ModifyWeaponCrit(Item item, Player player, ref float crit)
        {
            if (player.GetModPlayer<BereftSOTSPlayer>().FrigidEnch)
            {
                crit += FrigidEnchantment.crit;
            }
        }
    }*/
}
