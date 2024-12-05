using Terraria.ID;
using Terraria.ModLoader;
using TheBereftSouls.Common.Systems;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("SOTS")]
public class FrigidPickaxe : ModSystem
{
    public override void Load()
    {
        int frigidPickaxe = ModContent.ItemType<SOTS.Items.Tools.FrigidPickaxe>();
        RecipeUpdaterSystem.AddRecipeMod(
            frigidPickaxe,
            RecipeMod.AddItem(ItemID.ShadowScale, 6).AsAltRecipe()
        );
        RecipeUpdaterSystem.AddRecipeMod(frigidPickaxe, RecipeMod.AddItem(ItemID.TissueSample, 6));
    }
}
