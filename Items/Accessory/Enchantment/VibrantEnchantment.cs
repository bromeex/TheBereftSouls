using SOTS.Items.Permafrost;
using SOTS;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Void;
using ThoriumMod.Items.BossFallenBeholder;
using SOTS.Items.Earth;

namespace TheBereftSouls.Items.Accessory.Enchantment
{
    public class VibrantEnchantment : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        public override void SetStaticDefaults()
        {
            this.SetResearchCost(1);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(player);
            player.GetDamage<VoidGeneric>() += 0.10f;
            voidPlayer.voidCost -= 0.10f;
            voidPlayer.voidMeterMax2 += 70;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient<VibrantHelmet>()
                .AddIngredient<VibrantLeggings>()
                .AddIngredient<VibrantChestplate>()
                .AddIngredient<VibrantPistol>()
                .AddIngredient<VibrantBar>(3)
                .AddTile(TileID.DemonAltar).Register();
        }
    }
}