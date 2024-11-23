using CalamityMod.Items.Accessories;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using SOTS.Items;
using Terraria.ModLoader;
using TheBereftSouls.Utils.RecipeUpdater;
using static Terraria.ModLoader.ModContent;

namespace TheBereftSouls.Content.RecipeChanges.UpdateAeolusBoots;

[ExtendsFromMod("CalamityMod", "FargowiltasSouls", "SOTS")]
public class UpdateAeolusBoots : RecipeUpdater
{
    UpdateAeolusBoots()
    {
        this.itemId = ItemType<AeolusBoots>();
        this.toAdd = [ItemType<FlashsparkBoots>()];
        this.toRemove = [ItemType<AngelTreads>()];
    }
}
