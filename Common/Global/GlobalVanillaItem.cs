using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Global
{
    public class GlobalVanillaItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.ReaverShark)
            {
                item.pick = 55;
            }
            base.SetDefaults(item);
        }
    }
}
