using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ThoriumMod.Items.BossTheGrandThunderBird;
using CalamityMod.Items.Materials;
using System.Linq;
using CalamityMod.Items.SummonItems;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Sandstone;
using ThoriumMod.Items.BossGraniteEnergyStorm;
using ThoriumMod.Items.BossViscount;

namespace TheBereftSouls
{
    internal class Recipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.MagicMirror)}", ItemID.IceMirror, ItemID.MagicMirror);
            RecipeGroup.RegisterGroup(nameof(ItemID.MagicMirror), group);
            
            group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.RottenChunk)}", ModContent.ItemType<BloodSample>());
            RecipeGroup.RegisterGroup(nameof(ItemID.RottenChunk), group);
        }
        public override void AddRecipes()
        {
            

            
        }

        public override void PostAddRecipes()
        {
            Main.recipe.Where(x => x.createItem.type == ModContent.ItemType<StormFlare>()).ToList().ForEach(s =>
            {
                //s.DisableRecipe(); //disables the recipe
                s.RemoveIngredient(ModContent.ItemType<Talon>()); //remove ingredient
                s.AddIngredient(ModContent.ItemType<StormlionMandible>()); //add ingredient
            });
            Main.recipe.Where(x => x.createItem.type == ModContent.ItemType<GrandFlareGun>()).ToList().ForEach(s =>
            {
                //s.RemoveIngredient(ModContent.ItemType<Talon>()); // kept talon in the recipe because I believe they should still be used for at least the flare gun(this can be changed)
                s.AddIngredient(ModContent.ItemType<StormlionMandible>());
            });

            Main.recipe.Where(x => x.createItem.type == ModContent.ItemType<DesertMedallion>()).ToList().ForEach(s =>
            {
                s.AddIngredient(ModContent.ItemType<SandstoneIngot>(), 5);//boss progression document said too add storm feathers to the recipe but I have no clue what those are (custom item?) added GTB sandstone ingot drop instead
            });

            Main.recipe.Where(x => x.createItem.type == ModContent.ItemType<DecapoditaSprout>()).ToList().ForEach(s =>
            {
                s.AddIngredient(ModContent.ItemType<SandstoneIngot>(), 5);
                s.AddIngredient(ModContent.ItemType<PearlShard>(), 2);
            });

            Main.recipe.Where(x => x.createItem.type == ModContent.ItemType<UnstableCore>()).ToList().ForEach(s =>
            {
                s.AddIngredient(ItemID.IronBar, 5);
                //s.AddIngredient(ModContent.ItemType<DraculaFang>(), 2); should probably add a custom item instead of this as its only a 14% drop chance
            });
        }
    }
}
