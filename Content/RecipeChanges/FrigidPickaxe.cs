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
            // one version has tissue sample, the other has shadow scale
            RecipeMod.Branch(
                RecipeMod.AddItem(ItemID.TissueSample, 6),
                RecipeMod.AddItem(ItemID.ShadowScale, 6)
            )
        );
    }
}
