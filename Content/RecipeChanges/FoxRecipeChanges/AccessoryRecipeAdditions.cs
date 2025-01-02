using CalamityMod.Items.Placeables.Banners;
using Consolaria.Content.Items.Placeable.Banners;
using SOTS.Items.Fragments;
using SOTS.Items.OreItems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.Banners;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.HealerItems;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("ThoriumMod", "SOTS")]
public class AccessoryRecipeAdditions : ModSystem
{
    public override void AddRecipes()
    {   
        // Adding Treasure Bag recipes to missing Emblems
        Recipe BardEmblem = Recipe.Create(ModContent.ItemType<BardEmblem>());
        BardEmblem.AddIngredient(ItemID.WallOfFleshBossBag);
        BardEmblem.AddTile(TileID.Solidifier);
        BardEmblem.Register();
        Recipe ClericEmblem = Recipe.Create(ModContent.ItemType<ClericEmblem>());
        ClericEmblem.AddIngredient(ItemID.WallOfFleshBossBag);
        ClericEmblem.AddTile(TileID.Solidifier);
        ClericEmblem.Register();
        // Added an Ankh Shield component recipe similar to those added by SOTS for the Pocket Mirror
        Recipe PocketMirror = Recipe.Create(ItemID.PocketMirror);
        PocketMirror.AddIngredient(ModContent.ItemType<WardingCharm>());
        PocketMirror.AddIngredient(ModContent.ItemType<FragmentOfEarth>(), 10);
        PocketMirror.AddTile(TileID.MythrilAnvil);
        PocketMirror.Register();
        // Adding Banner recipes to Accessories that already had banner recipes
        Recipe Compass = Recipe.Create(ItemID.Compass);
        Compass.AddIngredient(ModContent.ItemType<SnowFlinxMatriarchBanner>());
        Compass.AddTile(TileID.Solidifier);
        Compass.Register();
        Recipe DepthMeter = Recipe.Create(ItemID.DepthMeter);
        DepthMeter.AddIngredient(ModContent.ItemType<EarthenBatBanner>());
        DepthMeter.AddTile(TileID.Solidifier);
        DepthMeter.Register();
        Recipe JellyFishNecklace = Recipe.Create(ItemID.JellyfishNecklace);
        JellyFishNecklace.AddIngredient(ItemID.BloodJellyBanner);
        JellyFishNecklace.AddTile(TileID.Solidifier);
        JellyFishNecklace.Register();
        JellyFishNecklace = Recipe.Create(ItemID.JellyfishNecklace);
        JellyFishNecklace.AddIngredient(ItemID.BloodJellyBanner);
        JellyFishNecklace.AddTile(TileID.Solidifier);
        JellyFishNecklace.Register();
        JellyFishNecklace = Recipe.Create(ItemID.JellyfishNecklace);
        JellyFishNecklace.AddIngredient(ModContent.ItemType<MirageJellyBanner>());
        JellyFishNecklace.AddTile(TileID.Solidifier);
        JellyFishNecklace.Register();
        JellyFishNecklace = Recipe.Create(ItemID.JellyfishNecklace);
        JellyFishNecklace.AddIngredient(ModContent.ItemType<ManofWarBanner>());
        JellyFishNecklace.AddTile(TileID.Solidifier);
        JellyFishNecklace.Register();
        Recipe Shackle = Recipe.Create(ItemID.Shackle);
        Shackle.AddIngredient(ModContent.ItemType<BiterBanner>());
        Shackle.AddTile(TileID.Solidifier);
        Shackle.Register();
        Recipe SharkToothNecklace = Recipe.Create(ItemID.SharkToothNecklace);
        SharkToothNecklace.AddIngredient(ModContent.ItemType<BloodMageBanner>());
        SharkToothNecklace.AddTile(TileID.Solidifier);
        SharkToothNecklace.Register();
        SharkToothNecklace = Recipe.Create(ItemID.SharkToothNecklace);
        SharkToothNecklace.AddIngredient(ModContent.ItemType<EngorgedEyeBanner>());
        SharkToothNecklace.AddTile(TileID.Solidifier);
        SharkToothNecklace.Register();
        Recipe TallyCounter = Recipe.Create(ItemID.TallyCounter);
        TallyCounter.AddIngredient(ModContent.ItemType<DarksteelKnightBanner>());
        TallyCounter.AddTile(TileID.Solidifier);
        TallyCounter.Register();
        TallyCounter = Recipe.Create(ItemID.TallyCounter);
        TallyCounter.AddIngredient(ModContent.ItemType<GelatinousCubeBanner>());
        TallyCounter.AddTile(TileID.Solidifier);
        TallyCounter.Register();
        TallyCounter = Recipe.Create(ItemID.TallyCounter);
        TallyCounter.AddIngredient(ModContent.ItemType<RagingMinotaurBanner>());
        TallyCounter.AddTile(TileID.Solidifier);
        TallyCounter.Register();
        TallyCounter = Recipe.Create(ItemID.TallyCounter);
        TallyCounter.AddIngredient(ModContent.ItemType<ShamblerBanner>());
        TallyCounter.AddTile(TileID.Solidifier);
        TallyCounter.Register();
        TallyCounter = Recipe.Create(ItemID.TallyCounter);
        TallyCounter.AddIngredient(ModContent.ItemType<DragonSkullBanner>());
        TallyCounter.AddTile(TileID.Solidifier);
        TallyCounter.Register();
    }
}
