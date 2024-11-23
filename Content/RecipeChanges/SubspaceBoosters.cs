using FargowiltasSouls.Content.Items.Accessories.Masomode;
using SOTS.Items;
using Terraria.ModLoader;
using TheBereftSouls.Utils.RecipeUpdater;
using static Terraria.ModLoader.ModContent;

namespace TheBereftSouls.Content.RecipeChanges.UpdateSubspaceBoosters;

[ExtendsFromMod("FargowiltasSouls", "SOTS")]
public class UpdateSubspaceBoosters : RecipeUpdater
{
    UpdateSubspaceBoosters()
    {
        this.itemId = ItemType<SubspaceBoosters>();
        this.toAdd = [ItemType<AeolusBoots>()];
        this.toRemove = [ItemType<FlashsparkBoots>()];
    }
}
