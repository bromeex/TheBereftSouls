using Microsoft.Xna.Framework;
using SOTS.Items.Invidia;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TheBereftSouls.Common.Players;
using TheBereftSouls.Common.Systems;
using TheBereftSouls.Content.Projectiles.Friendly;
using TheBereftSouls.Content.Tiles.Special;
using TheBereftSouls.Utils;

namespace TheBereftSouls.Content.Items.Accessories
{
    [ExtendsFromMod("SOTS")]
    public class VesperaEnchantment : ModItem
    {
        private float timer = 0;

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
            if (Main.myPlayer != player.whoAmI)
            {
                return;
            }

            if (timer == 0)
            {
                SoundEngine.PlaySound(SoundID.Item4 with { Pitch = -1f });
                BereftUtils.DustCircle(player.Center, 16, 10, DustID.Stone);
                var bPlayer = player.GetModPlayer<BereftSOTSPlayer>();
                for (int i = 0; i < bPlayer.VesperaStoneCoords.Count; i++)
                {
                    int xCoords = (int)bPlayer.VesperaStoneCoords[i].X;
                    int yCoords = (int)bPlayer.VesperaStoneCoords[i].Y;
                    if (Main.tile[xCoords, yCoords].TileType == ModContent.TileType<VesperaStoneBlock>())
                    {
                        WorldGen.KillTile(xCoords, yCoords);
                        NetMessage.SendTileSquare(-1, xCoords, yCoords);
                    }
                }
            }

            if (KeybindSystem.VesperaEnchStone.JustPressed && timer <= 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector2 positionToTarget = Main.MouseWorld + new Vector2(Main.rand.NextFloat(-30, 30), Main.rand.NextFloat(-30, 30));
                    float speed = player.Center.Distance(positionToTarget) / 30;
                    Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, player.Center.DirectionTo(positionToTarget) * speed, ModContent.ProjectileType<VesperaStone>(), 15, 0.1f);
                }

                timer = 300;
            }

            if (timer >= 0)
            {
                timer--;
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
}
