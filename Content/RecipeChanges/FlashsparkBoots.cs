using CalamityMod.Items.Accessories;
using SOTS.Items;
using Terraria.ID;
using Terraria.ModLoader;
using TheBereftSouls.Utils.RecipeUpdater;
using static Terraria.ModLoader.ModContent;

namespace TheBereftSouls.Content.RecipeChanges.UpdateFlashSparkBoots;

[ExtendsFromMod("CalamityMod", "SOTS")]
public class UpdateFlashsparkBoots : RecipeUpdater
{
    UpdateFlashsparkBoots()
    {
        this.itemId = ItemType<FlashsparkBoots>();
        this.toAdd = [ItemType<AngelTreads>()];
        this.toRemove = [ItemID.TerrasparkBoots];
    }
}
