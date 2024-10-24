using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Content.DamageClasses;
using TheBereftSouls.Content.Items.Weapons.Bard.Void;
using TheBereftSouls.Content.Items.Weapons.Healer.Void;
using TheBereftSouls.Content.Items.Weapons.Rogue.Void;

namespace TheBereftSouls.Common.Global
{
    public class WeaponDamageTypeFix : GlobalItem
    {
        private static List<int> VoidBardWeapons = new List<int>
        {
            ModContent.ItemType<VesperaWarhorn>()
        };
        private static List<int> VoidRogueWeapons = new List<int>
        {
            ModContent.ItemType<VoidCoconut>()
        };
        private static List<int> VoidHealerWeapons = new List<int>
        {
            ModContent.ItemType<VesperaLifeClaymore>()
        };
        public override void SetDefaults(Item item)
        {
            foreach (int WeaponId in VoidBardWeapons)
            {
                if (item.type == WeaponId)
                {
                    item.DamageType = ModContent.GetInstance<VoidBard>();
                    base.SetDefaults(item);
                }
            }
            foreach (int WeaponId in VoidRogueWeapons)
            {
                if (item.type == WeaponId)
                {
                    item.DamageType = ModContent.GetInstance<VoidRogue>();
                    base.SetDefaults(item);
                }
            }
            foreach (int WeaponId in VoidHealerWeapons)
            {
                if (item.type == WeaponId)
                {
                    item.DamageType = ModContent.GetInstance<VoidHealer>();
                    base.SetDefaults(item);
                }
            }
        }
    }
}