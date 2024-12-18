using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using SOTS.Items;
using Terraria.ID;
using Terraria.ModLoader;
using TheBereftSouls.Common.Systems;

namespace TheBereftSouls.Content;

[ExtendsFromMod("CalamityMod", "FargowiltasSouls", "SOTS")]
public class BootRecipes : ModSystem
{
    public override void Load()
    {
        int flashsparkBoots = ModContent.ItemType<FlashsparkBoots>();
        int terrasparkBoots = ItemID.TerrasparkBoots;
        int angelTreads = ModContent.ItemType<AngelTreads>();
        int aeolusBoots = ModContent.ItemType<AeolusBoots>();
        int subspaceBoosters = ModContent.ItemType<SubspaceBoosters>();
        int tracersCelestial = ModContent.ItemType<TracersCelestial>();
        RecipeUpdaterSystem.AddRecipeMod(
            flashsparkBoots,
            RecipeMod.ReplaceItem(terrasparkBoots, angelTreads)
        );
        RecipeUpdaterSystem.AddRecipeMod(
            aeolusBoots,
            RecipeMod.ReplaceItem(angelTreads, flashsparkBoots)
        );
        RecipeUpdaterSystem.AddRecipeMod(
            subspaceBoosters,
            RecipeMod.ReplaceItem(flashsparkBoots, aeolusBoots)
        );
        RecipeUpdaterSystem.AddRecipeMod(
            tracersCelestial,
            RecipeMod.ReplaceItem(aeolusBoots, subspaceBoosters)
        );
    }
}
