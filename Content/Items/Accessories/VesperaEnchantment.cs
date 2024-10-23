using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Items.Earth;
using SOTS;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using SOTS.Items.Invidia;
using TheBereftSouls.Content.Projectiles.Friendly;
using TheBereftSouls.Common.Systems;
using TheBereftSouls.Content.Tiles.Special;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Terraria.Audio;
using System.Collections.Generic;
using Terraria.Localization;
using System.Linq;

namespace TheBereftSouls.Content.Items.Accessories
{
    public class VesperaEnchantment : ModItem
    {
        float Timer = 0;

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
            if (Main.myPlayer != player.whoAmI)
            {
                return;
            }

            if (Timer == 0)
            {
                SoundEngine.PlaySound(SoundID.Item4 with { Pitch = -1f });
                for (int i = 0; i < 16; i++)
                {
                    var dust = Dust.NewDustDirect(player.Center, 1, 1, DustID.Stone);
                    dust.noGravity = true;
                    dust.velocity = new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i * 22.5f));
                }
                var vPlayer = player.GetModPlayer<VesperaEnchPlayer>();
                for (int i = 0; i < vPlayer.vesperaStoneXCOORDS.Count; i++)
                {
                    if (Main.tile[vPlayer.vesperaStoneXCOORDS[i], vPlayer.vesperaStoneYCOORDS[i]].TileType == ModContent.TileType<VesperaStoneBlock>())
                    {
                        WorldGen.KillTile(vPlayer.vesperaStoneXCOORDS[i], vPlayer.vesperaStoneYCOORDS[i]);
                        NetMessage.SendTileSquare(-1, vPlayer.vesperaStoneXCOORDS[i], vPlayer.vesperaStoneYCOORDS[i]);
                    }
                }
                
            }

            if (KeybindSystem.VesperaEnchStone.JustPressed && Timer <= 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector2 positionToTarget = Main.MouseWorld + new Vector2(Main.rand.NextFloat(-30, 30), Main.rand.NextFloat(-30, 30));
                    float speed = player.Center.Distance(positionToTarget) / 30;
                    Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, player.Center.DirectionTo(positionToTarget) * speed, ModContent.ProjectileType<VesperaStone>(), 15, 0.1f);

                }
                Timer = 300;
            }
            if (Timer >= 0)
            {
                Timer--;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VesperaMask>());
            recipe.AddIngredient(ModContent.ItemType<VesperaBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<VesperaLeggings>());
            recipe.AddIngredient(ModContent.ItemType<VesperaNanDao>());
            recipe.AddIngredient(ModContent.ItemType<VesperaLongbow>());
            recipe.AddIngredient(ModContent.ItemType<VesperaFishingRod>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

        }
    }

    public class VesperaEnchPlayer : ModPlayer
    {
        public List<int> vesperaStoneXCOORDS = new List<int>();
        public List<int> vesperaStoneYCOORDS = new List<int>();
    }
}
