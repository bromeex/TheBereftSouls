using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Content.DamageClasses;
using TheBereftSouls.Content.Items.Weapons.Bard.Void;

namespace TheBereftSouls.Common.Global
{
    public class VoidBardWeaponDamageTypeFix : GlobalItem
    {
        private static List<int> Weapons = new List<int>
        {
            ModContent.ItemType<VesperaWarhorn>()
        };
        public override void SetDefaults(Item item)
        {
            foreach (int WeaponId in Weapons)
            {
                if (item.type == WeaponId)
                {
                    item.DamageType = ModContent.GetInstance<VoidBard>();
                    base.SetDefaults(item);
                }
            }
        }
    }
}