using CalamityMod.Items.Accessories.Wings;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using SOTS.Items;
using Terraria.ModLoader;
using TheBereftSouls.Utils.RecipeUpdater;
using static Terraria.ModLoader.ModContent;

namespace TheBereftSouls.Content.RecipeChanges.UpdateCelestialTracers;

[ExtendsFromMod("CalamityMod", "FargowiltasSouls", "SOTS")]
public class UpdateCelestialTracers : RecipeUpdater
{
    UpdateCelestialTracers()
    {
        this.itemId = ItemType<TracersCelestial>();
        this.toAdd = [ItemType<SubspaceBoosters>()];
        this.toRemove = [ItemType<AeolusBoots>()];
    }
}
