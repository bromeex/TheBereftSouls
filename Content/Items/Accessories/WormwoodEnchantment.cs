using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Items.Nature;
using SOTS;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using SOTS.Projectiles.Nature;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using MonoMod.RuntimeDetour;
using Terraria.Localization;
using TheBereftSouls.Content.Buffs;

namespace TheBereftSouls.Content.Items.Accessories
{
    public class WormwoodEnchantment : ModItem
    {
        static int defenseBoost = 1;
        static int hooksToSummon = 4;
        public List<Projectile> hooks = new List<Projectile>(hooksToSummon);
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(defenseBoost);

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
            player.statDefense += player.numMinions * defenseBoost;
            if (Main.myPlayer == player.whoAmI)
            {
                if (!player.HasBuff(ModContent.BuffType<PatchedUpDebuff>()) && player.statLife > player.statLifeMax2 / 2)
                {
                    if (hooks.Count < hooksToSummon)
                    {
                        hooks.Add(Projectile.NewProjectileDirect(player.GetSource_FromThis(), player.MountedCenter, Vector2.Zero, ModContent.ProjectileType<BloomingHook>(), 11, 1));
                    }
                }
                foreach (var hook in hooks)
                {
                    hook.timeLeft = 6;
                }
                if (player.statLife < player.statLifeMax / 2)
                {
                    foreach (var hook in hooks)
                    {
                        hook.Kill();
                        player.Heal(player.statLifeMax2 / 16);
                        player.AddBuff(ModContent.BuffType<PatchedUpDebuff>(), 3600);
                    }
                    hooks.Clear();
                }
                if (hooks.Count > 0 && hooks[0] != null && !hooks[0].active)
                {
                    hooks.Clear();
                }
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NatureWreath>());
            recipe.AddIngredient(ModContent.ItemType<NatureShirt>());
            recipe.AddIngredient(ModContent.ItemType<NatureLeggings>());
            recipe.AddIngredient(ModContent.ItemType<BotanicalSymbiote>());
            recipe.AddIngredient(ModContent.ItemType<NatureSpell>());
            recipe.AddIngredient(ItemID.EmeraldStaff);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
