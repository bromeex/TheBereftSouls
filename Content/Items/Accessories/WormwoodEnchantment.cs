using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SOTS.Items.Nature;
using SOTS.Projectiles.Nature;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheBereftSouls.Content.Buffs;
using TheBereftSouls.Utils;

namespace TheBereftSouls.Content.Items.Accessories
{
    [ExtendsFromMod("SOTS")]
    public class WormwoodEnchantment : ModItem
    {
        public List<Projectile> Hooks = new List<Projectile>(hooksToSummon);

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(defenseBoost);

        private static int defenseBoost = 1;
        private static int hooksToSummon = 4;

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
                    if (Hooks.Count < hooksToSummon)
                    {
                        Hooks.Add(Projectile.NewProjectileDirect(player.GetSource_FromThis(), player.MountedCenter, Vector2.Zero, ModContent.ProjectileType<BloomingHook>(), 11, 1));
                    }
                }

                foreach (var hook in Hooks)
                {
                    hook.timeLeft = 6;
                }

                if (player.statLife < player.statLifeMax / 2)
                {
                    foreach (var hook in Hooks)
                    {
                        hook.Kill();
                        player.Heal(player.statLifeMax2 / 16);
                        player.AddBuff(ModContent.BuffType<PatchedUpDebuff>(), 3600);
                        BereftUtils.DustCircle(player.Center, 16, 10, DustID.GemEmerald, Main.rand.NextFloat(1f, 2f));
                    }
                    Hooks.Clear();
                }

                if (Hooks.Count > 0 && Hooks[0] != null && !Hooks[0].active)
                {
                    Hooks.Clear();
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
