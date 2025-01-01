using CalamityMod.Items.Accessories;
using CalamityMod.Items.Placeables.Banners;
using SOTS.Items.OreItems;
using SOTS.Items.Planetarium.Furniture;
using SOTS.Items.Wings;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("ThoriumMod", "SOTS")]
public class AccessoryRecipeModifications : ModSystem
{
    public override void PostAddRecipes()
    {
        foreach (var recipe in Main.recipe)
        {
            {
                if (recipe.createItem.type == ItemID.AdhesiveBandage)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.Aglet 
                && recipe.HasIngredient(ItemID.CopperBar))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.AnkletoftheWind
                && recipe.HasIngredient(ItemID.JungleSpores))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.ArmorPolish)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.BandofRegeneration
                && recipe.HasIngredient(ItemID.Shackle))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.BandofStarpower
                && recipe.HasIngredient(ItemID.PanicNecklace))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.Bezoar)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            {
                if (recipe.createItem.type == ItemID.Blindfold)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.BlizzardinaBottle
                && recipe.HasIngredient(ItemID.Bottle))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.BlizzardinaBottle
                && recipe.HasIngredient(ItemID.CloudinaBottle))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.CelestialEmblem
                && recipe.HasIngredient(ItemID.SoulofSight))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.CelestialMagnet
                && recipe.HasIngredient(ItemID.TreasureMagnet))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.CloudinaBottle
                && recipe.HasIngredient(ItemID.Bottle))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.CobaltShield
                && recipe.HasIngredient(ItemID.CobaltBar))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.DPSMeter 
                && recipe.HasIngredient(ItemID.IronBar))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.FastClock)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.FeralClaws 
                && recipe.HasIngredient(ItemID.Leather))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.FlameWakerBoots
                && recipe.HasIngredient(ItemID.Silk))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.CreativeWings
                && recipe.HasIngredient(ItemID.Cloud))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.FleshKnuckles
                && recipe.HasTile(TileID.TinkerersWorkbench))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.Flipper
                && recipe.HasIngredient(ModContent.ItemType<MorayEelBanner>()))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.FlyingCarpet
                && recipe.HasIngredient(ItemID.PharaohsMask))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.FlyingCarpet 
                && recipe.HasIngredient(ItemID.Silk))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.FlowerBoots
                && recipe.HasIngredient(ItemID.HermesBoots))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.FlowerBoots 
                && recipe.HasIngredient(ItemID.Silk))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.FrozenTurtleShell
                && recipe.HasIngredient(ItemID.TurtleShell))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<FungalSymbiote>()
                && recipe.HasTile(TileID.TinkerersWorkbench))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<GladiatorsLocket>()
                && recipe.HasIngredient(ItemID.Gladius))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.HandWarmer 
                && recipe.HasIngredient(ItemID.Silk))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.HermesBoots 
                && recipe.HasIngredient(ItemID.Silk))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.IceSkates 
                && recipe.HasIngredient(ItemID.Leather))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.LavaCharm 
                && recipe.HasIngredient(ItemID.Obsidian))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.LavaFishingHook
                && recipe.HasIngredient(ItemID.Seashell))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.LuckyHorseshoe
                && recipe.HasIngredient(ItemID.GoldBar))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<LuxorsGift>()
                && recipe.HasIngredient(ItemID.Geode))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<MachinaBooster>()
                && recipe.HasTile(ModContent.TileType<HardlightFabricatorTile>()))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.MagicQuiver)
                {
                    if (!recipe.HasIngredient(ItemID.EndlessQuiver))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.MechanicalGlove
                && recipe.HasIngredient(ItemID.SoulofSight))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.Megaphone)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.MetalDetector
                && recipe.HasIngredient(ItemID.NypmhBanner))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.Nazar)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.ObsidianRose
                && recipe.HasIngredient(ItemID.FireImpBanner))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.PaladinsHammer
                && recipe.HasIngredient(ItemID.PaladinBanner))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.PanicNecklace
                && recipe.HasIngredient(ItemID.BandofStarpower))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.PocketMirror)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.PutridScent
                && recipe.HasTile(TileID.TinkerersWorkbench))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.Radar 
                && recipe.HasIngredient(ItemID.IronBar))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.SandstorminaBottle
                && recipe.HasIngredient(ItemID.Bottle))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.SandstorminaBottle
                && recipe.HasIngredient(ItemID.CloudinaBottle))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.SandstorminaBottle
                && recipe.HasIngredient(ItemID.PharaohsMask))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.ShinyRedBalloon
                && recipe.HasIngredient(ItemID.Gel))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.ShoeSpikes 
                && recipe.HasIngredient(ItemID.IronBar))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ItemID.PortableStool 
                && recipe.HasIngredient(ItemID.Wood))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.TrifoldMap)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ModContent.ItemType<TrinketofChi>()
                && recipe.HasIngredient(ItemID.Wood))
                recipe.DisableRecipe();
            if (recipe.createItem.type == ModContent.ItemType<UnstableGraniteCore>()
                && recipe.HasIngredient(ModContent.ItemType<AmidiasSpark>()))
                recipe.DisableRecipe();
            {
                if (recipe.createItem.type == ItemID.Vitamins)
                {
                    if (!recipe.HasIngredient(ModContent.ItemType<WardingCharm>()))
                        recipe.DisableRecipe();
                }
            }
            if (recipe.createItem.type == ItemID.WaterWalkingBoots
                && recipe.HasIngredient(ItemID.WaterWalkingPotion))
                recipe.DisableRecipe();
        }
    }
}
