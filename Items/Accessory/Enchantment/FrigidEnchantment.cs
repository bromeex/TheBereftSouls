using SOTS.Items.Permafrost;
using SOTS;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Void;

namespace TheBereftSouls.Items.Accessory.Enchantment
{
    public class FrigidEnchantment : ModItem
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
            player.GetAttackSpeed<VoidGeneric>() += 0.1f;
            //player.iceSkate = true;
            //player.moveSpeed += 0.1f;
            //player.GetDamage<VoidGeneric>() -= 0.15f;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 30 * 60); //this needs to be changed so it only applies on void damage
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient<FrigidCrown>()
                .AddIngredient<FrigidRobe>()
                .AddIngredient<FrigidGreaves>()
                .AddIngredient<ShatterShardChestplate>()
                .AddIngredient<ShatterBlade>()
                .AddIngredient<FrigidBar>(3)
                .AddTile(TileID.DemonAltar).Register();
        }
    }
}