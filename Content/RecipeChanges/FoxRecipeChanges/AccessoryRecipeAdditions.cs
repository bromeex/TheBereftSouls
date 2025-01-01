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
        Recipe BardEmblem = Recipe.Create(ModContent.ItemType<BardEmblem>());
        BardEmblem.AddIngredient(ItemID.WallOfFleshBossBag);
        BardEmblem.AddTile(TileID.Solidifier);
        BardEmblem.Register();
        Recipe ClericEmblem = Recipe.Create(ModContent.ItemType<ClericEmblem>());
        ClericEmblem.AddIngredient(ItemID.WallOfFleshBossBag);
        ClericEmblem.AddTile(TileID.Solidifier);
        ClericEmblem.Register();
        Recipe Compass = Recipe.Create(ItemID.Compass);
        Compass.AddIngredient(ModContent.ItemType<SnowFlinxMatriarchBanner>());
        Compass.AddTile(TileID.Solidifier);
        Compass.Register();
        Recipe DepthMeter = Recipe.Create(ItemID.DepthMeter);
        DepthMeter.AddIngredient(ModContent.ItemType<EarthenBatBanner>());
        DepthMeter.AddTile(TileID.Solidifier);
        DepthMeter.Register();
        Recipe JellyFishNecklace1 = Recipe.Create(ItemID.JellyfishNecklace);
        JellyFishNecklace1.AddIngredient(ItemID.BloodJellyBanner);
        JellyFishNecklace1.AddTile(TileID.Solidifier);
        JellyFishNecklace1.Register();
        Recipe JellyFishNecklace2 = Recipe.Create(ItemID.JellyfishNecklace);
        JellyFishNecklace2.AddIngredient(ItemID.BloodJellyBanner);
        JellyFishNecklace2.AddTile(TileID.Solidifier);
        JellyFishNecklace2.Register();
        Recipe JellyFishNecklace3 = Recipe.Create(ItemID.JellyfishNecklace);
        JellyFishNecklace3.AddIngredient(ModContent.ItemType<MirageJellyBanner>());
        JellyFishNecklace3.AddTile(TileID.Solidifier);
        JellyFishNecklace3.Register();
        Recipe JellyFishNecklace4 = Recipe.Create(ItemID.JellyfishNecklace);
        JellyFishNecklace4.AddIngredient(ModContent.ItemType<ManofWarBanner>());
        JellyFishNecklace4.AddTile(TileID.Solidifier);
        JellyFishNecklace4.Register();
        Recipe PocketMirror = Recipe.Create(ItemID.PocketMirror);
        PocketMirror.AddIngredient(ModContent.ItemType<WardingCharm>());
        PocketMirror.AddIngredient(ModContent.ItemType<FragmentOfEarth>(), 10);
        PocketMirror.AddTile(TileID.MythrilAnvil);
        PocketMirror.Register();
        Recipe Shackle = Recipe.Create(ItemID.Shackle);
        Shackle.AddIngredient(ModContent.ItemType<BiterBanner>());
        Shackle.AddTile(TileID.Solidifier);
        Shackle.Register();
        Recipe SharkToothNecklace = Recipe.Create(ItemID.SharkToothNecklace);
        SharkToothNecklace.AddIngredient(ModContent.ItemType<BloodMageBanner>());
        SharkToothNecklace.AddTile(TileID.Solidifier);
        SharkToothNecklace.Register();
        Recipe SharkToothNecklace2 = Recipe.Create(ItemID.SharkToothNecklace);
        SharkToothNecklace2.AddIngredient(ModContent.ItemType<EngorgedEyeBanner>());
        SharkToothNecklace2.AddTile(TileID.Solidifier);
        SharkToothNecklace2.Register();
        Recipe TallyCounter = Recipe.Create(ItemID.TallyCounter);
        TallyCounter.AddIngredient(ModContent.ItemType<DarksteelKnightBanner>());
        TallyCounter.AddTile(TileID.Solidifier);
        TallyCounter.Register();
        Recipe TallyCounter2 = Recipe.Create(ItemID.TallyCounter);
        TallyCounter2.AddIngredient(ModContent.ItemType<GelatinousCubeBanner>());
        TallyCounter2.AddTile(TileID.Solidifier);
        TallyCounter2.Register();
        Recipe TallyCounter3 = Recipe.Create(ItemID.TallyCounter);
        TallyCounter3.AddIngredient(ModContent.ItemType<RagingMinotaurBanner>());
        TallyCounter3.AddTile(TileID.Solidifier);
        TallyCounter3.Register();
        Recipe TallyCounter4 = Recipe.Create(ItemID.TallyCounter);
        TallyCounter4.AddIngredient(ModContent.ItemType<ShamblerBanner>());
        TallyCounter4.AddTile(TileID.Solidifier);
        TallyCounter4.Register();
        Recipe TallyCounter5 = Recipe.Create(ItemID.TallyCounter);
        TallyCounter5.AddIngredient(ModContent.ItemType<DragonSkullBanner>());
        TallyCounter5.AddTile(TileID.Solidifier);
        TallyCounter5.Register();
    }
}
