using Microsoft.Xna.Framework;
using SOTS.Buffs;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using SOTS.Void;
using CalamityMod;
using TheBereftSouls.Content.DamageClasses;


namespace TheBereftSouls.Content.Items.Weapons
{
    //extends https://github.com/VortexOfRainbows/SOTS/blob/1.4.4/Void/VoidItem.cs
    [ExtendsFromMod(["SOTS", "CalamityMod"])]
    public abstract class CalamityVoidWeapon : VoidItem
    {
        public virtual void SetItemDefaults() { }
        public sealed override void SafeSetDefaults()
        {
            SetItemDefaults();
            if (Item.DamageType == ModContent.GetInstance<RogueDamageClass>())
                Item.DamageType = ModContent.GetInstance<VoidRogue>();
            //else if (Item.DamageType == ModContent.GetInstance<HealerDamage>())
            //    Item.DamageType = ModContent.GetInstance<VoidHealer>();
        }
        public override bool WeaponPrefix() => true;
        public sealed override void ModifyTooltip(List<TooltipLine> tooltips)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(Main.LocalPlayer);
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.Text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = Language.GetTextValue("Mods.SOTS.Common.Damage");

                tt.Text = Language.GetTextValue("Mods.SOTS.Common.Void2", damageValue, damageWord);

                if (Item.CountsAsClass(ModContent.GetInstance<VoidRogue>()))
                    tt.Text = Language.GetTextValue("VoidRo", damageValue, damageWord);
                //else if (Item.CountsAsClass(ModContent.GetInstance<VoidHealer>()))
                //    tt.Text = Language.GetTextValue("VoidH", damageValue, damageWord);
            }
        }
    }
}