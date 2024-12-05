using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Common.Systems;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.Consumable;
using ThoriumMod.Items.Donate;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("ThoriumMod")]
public class ShimmerRecipeModifications : ModSystem
{
    private static readonly Condition CanGetHellstone = new("CanGetHellstone", () => NPC.downedBoss2 || Main.hardMode);

    public override void Load()
    {
        int kineticPotion = ModContent.ItemType<KineticPotion>();
        int holyPotion = ModContent.ItemType<HolyPotion>();
        int inspirationReachPotion = ModContent.ItemType<InspirationReachPotion>();
        int warmongerPotion = ModContent.ItemType<WarmongerPotion>();
        // gives pixie dust
        RecipeUpdaterSystem.AddRecipeMod(
            kineticPotion,
            RecipeMod.AddDecraftCondition(Condition.Hardmode)
        );
        // gives pixie dust
        RecipeUpdaterSystem.AddRecipeMod(
            holyPotion,
            RecipeMod.AddDecraftCondition(Condition.Hardmode)
        );
        // gives pixie dust
        RecipeUpdaterSystem.AddRecipeMod(
            inspirationReachPotion,
            RecipeMod.AddDecraftCondition(Condition.Hardmode)
        );
        // gives hellstone
        RecipeUpdaterSystem.AddRecipeMod(
            warmongerPotion,
            RecipeMod.AddDecraftCondition(CanGetHellstone)
        );
    }
}
