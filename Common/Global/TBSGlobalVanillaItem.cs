using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Global
{
    public class TBSGlobalVanillaItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.ReaverShark)
            {
                item.pick = 55;
            }
            base.SetDefaults(item);
        }
        public override bool InstancePerEntity => true;
    }
}
