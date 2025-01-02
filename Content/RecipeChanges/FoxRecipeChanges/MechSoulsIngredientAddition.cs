using SOTS.Items.Permafrost;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Content.RecipeChanges;

[ExtendsFromMod("CalamityMod", "SOTS", "ThoriumMod")]
public class MechSoulsIngredientsAddition : ModSystem
{
    public override void PostAddRecipes()
    {
        foreach (var recipe in Main.recipe)
        {
            // Added Soul of Plight to all post Mechanical Bosses items to encourage beating Polaris, this is retroactive, but will not affect the FrostKey to summon Polaris
            // Otherwise that would cause a progression lock
            if (!recipe.HasIngredient(ModContent.ItemType<SoulOfPlight>())
                && recipe.createItem.type != ModContent.ItemType<FrostedKey>()
                && recipe.HasIngredient(ItemID.SoulofSight)
                && recipe.HasIngredient(ItemID.SoulofMight)
                && recipe.TryGetIngredient(ItemID.SoulofFright, out Item SoulofFright))
                recipe.AddIngredient(ModContent.ItemType<SoulOfPlight>(), SoulofFright.stack);
        }
    }
}
