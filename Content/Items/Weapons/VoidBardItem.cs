using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SOTS;
using SOTS.Buffs;
using SOTS.Items.Planetarium;
using SOTS.Void;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ThoriumMod;
using ThoriumMod.Items;

namespace TheBereftSouls.Content.Items.Weapons
{
    [ExtendsFromMod(["SOTS", "ThoriumMod"])]
    public abstract class VoidBardItem : BardItem
    {
        //based off https://github.com/VortexOfRainbows/SOTS/blob/1.4.4/Void/VoidItem.cs

        public virtual void SafeSetDefaults() {}
        public sealed override void SetBardDefaults()
        {
            
            Item.shoot = ProjectileID.PurificationPowder;
            //Item.DamageType = ModContent.GetInstance<VoidBard>(); this needs to be assigned in VoidBardWeaponDamageTypeFix.cs as thorium sets weapon damage to bard at the end of the sealed set defaults call.
            SafeSetDefaults();
        }
        
        
        public override bool? BardUseItem(Player player)
        {
            if (Item.createTile > -1)
            {
                return base.UseItem(player);
            }
            if (CanDrainMana(player))
                DrainMana(player);
            return true;
        }

        public int VoidCost(Player player)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(player);
            int baseCost = GetVoid(player);
            float voidCostMult = 1f;

            if (Item.prefix == ModContent.PrefixType<Famished>() || Item.prefix == ModContent.PrefixType<Precarious>() || Item.prefix == ModContent.PrefixType<Potent>() || Item.prefix == ModContent.PrefixType<Omnipotent>() || Item.prefix == ModContent.PrefixType<Chthonic>())
            {
                voidCostMult = Item.GetGlobalItem<PrefixItem>().voidCostMultiplier;
            }
            int finalCost = (int)(baseCost * voidPlayer.voidCost * voidCostMult);
            if (finalCost < 1)
            {
                finalCost = 1;
            }

            return finalCost;
        }
        public virtual int GetVoid(Player player)
        {
            int cost = 1;

            return cost;
        }
        public override void BardModifyTooltips(List<TooltipLine> tooltips)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(Main.LocalPlayer); //only the local player will see the tooltip, afterall
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.Text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = Language.GetTextValue("Mods.SOTS.Common.Damage");

                tt.Text = Language.GetTextValue("Mods.SOTS.Common.Void2", damageValue, damageWord);

                if (Item.CountsAsClass(ModContent.GetInstance<BardDamage>()))
                    tt.Text = Language.GetTextValue("VoidB", damageValue, damageWord);

            }
            
            int cost = VoidCost(Main.LocalPlayer);
            if (cost > 0)
            {
                int index = tooltips.FindIndex((TooltipLine tt) => (tt.Mod.Equals("Terraria") || tt.Mod.Equals("ThoriumMod")) && ((Item.damage > 0 && tt.Name.Equals("Knockback")) || tt.Name.Equals("Tooltip0")));
                if (index != -1)
                {
                    tooltips.Insert(index + ((Item.damage > 0) ? 1 : 0), new TooltipLine(((ModType)this).Mod, "VoidCost", "Uses " + cost + " void"));
                }
            }
        }

        public override bool CanPlayInstrument(Player player)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(player);
            bool canUse = BeforeUseItem(player);
            bool cursed = player.HasBuff(BuffID.Cursed);
            if (cursed)
                return false;
            int currentVoid = voidPlayer.voidMeterMax2 - voidPlayer.lootingSouls - voidPlayer.VoidMinionConsumption;
            int finalCost = VoidCost(player);
            bool canDrainMana = CanDrainMana(player);
            if ((voidPlayer.safetySwitch && canDrainMana) && voidPlayer.voidMeter < finalCost && !voidPlayer.frozenVoid)
            {
                return false;
            }
            if (!canUse || player.FindBuffIndex(ModContent.BuffType<VoidRecovery>()) > -1 || Item.useAnimation < 2)
            {
                return false;
            }
            return true;
        }

        public void OnUseEffects(Player player)
        {
            BeadPlayer modPlayer = player.GetModPlayer<BeadPlayer>();
            modPlayer.attackNum++;
        }

        public virtual bool CanDrainMana(Player player)
        {
            return true;
        }
        public virtual bool BeforeUseItem(Player player)
        {
            return true;
        }
        public void DrainMana(Player player)
        {
            DrainMana(player, VoidCost(player));
        }
        public static void DrainMana(Player player, float cost)
        {
            VoidPlayer vPlayer = VoidPlayer.ModPlayer(player);
            float finalCost = cost;
            if (finalCost > 0)
            {
                if (player.whoAmI == Main.myPlayer)
                    vPlayer.voidMeter -= finalCost;
            }
        }
        public override bool BardShoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (type != 10)
            {
                return true;
            }
            return false;
        }
    }
}