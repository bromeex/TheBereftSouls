using CalamityMod;
using SOTS.Buffs;
using SOTS.Items.Planetarium;
using SOTS.Void;
using SOTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ThoriumMod;
using ThoriumMod.Items;
using ThoriumMod.Utilities;
using Microsoft.Xna.Framework;
using TheBereftSouls.Void;


namespace TheBereftSouls.Void
{
    public abstract class VoidBardItem : BardItem
    {
        public virtual void SafeSetDefaults()
        {

        }
        public void SetDefaults()
        {
            Item.shoot = ProjectileID.PurificationPowder;
            SafeSetDefaults();
            if (Item.DamageType == ModContent.GetInstance<RogueDamageClass>())
                Item.DamageType = ModContent.GetInstance<VoidRogue>();
            else if (Item.DamageType == ModContent.GetInstance<BardDamage>())
                Item.DamageType = ModContent.GetInstance<VoidBard>();
            Item.mana = 1;
        }
        public int VoidCost(Player player)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(player);
            int baseCost = GetVoid(player);
            int finalCost;
            float voidCostMult = 1f;

            if (Item.prefix == ModContent.PrefixType<Famished>() || Item.prefix == ModContent.PrefixType<Precarious>() || Item.prefix == ModContent.PrefixType<Potent>() || Item.prefix == ModContent.PrefixType<Omnipotent>() || Item.prefix == ModContent.PrefixType<Chthonic>())
            {
                voidCostMult = Item.GetGlobalItem<PrefixItem>().voidCostMultiplier;
            }
            finalCost = (int)(baseCost * voidPlayer.voidCost * voidCostMult);
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
        public void ModifyTooltips(List<TooltipLine> tooltips)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(Main.LocalPlayer); //only the local player will see the tooltip, afterall
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.Text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = Language.GetTextValue("Mods.SOTS.Common.Damage");

                tt.Text = Language.GetTextValue("Mods.SOTS.Common.Void2", damageValue, damageWord);

                if (Item.CountsAsClass(ModContent.GetInstance<RogueDamageClass>()))
                    tt.Text = Language.GetTextValue("VoidRo", damageValue, damageWord);
                else if (Item.CountsAsClass(ModContent.GetInstance<BardDamage>()))
                    tt.Text = Language.GetTextValue("VoidBar", damageValue, damageWord);

            }
            string voidCostText = VoidCost(Main.LocalPlayer).ToString();
            TooltipLine tt2 = tooltips.FirstOrDefault(x => x.Name == "UseMana" && x.Mod == "Terraria");
            if (tt2 != null)
            {
                string[] splitText = tt2.Text.Split(' ');
                if (Item.accessory)
                    tooltips.Remove(tt2);
                else
                {
                    tt2.Text = Language.GetTextValue("Mods.SOTS.Common.CV", voidCostText);
                }
            }
            ModifyTooltip(tooltips);
        }
        public virtual void ModifyTooltip(List<TooltipLine> tooltips)
        {

        }
        public bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (type != 10)
            {
                return true;
            }
            return false;
        }
        public sealed override bool CanConsumeAmmo(Item ammo, Player player)
        {
            bool canUse = BeforeConsumeAmmo(player);
            return canUse;
        }
        public sealed override bool CanBeConsumedAsAmmo(Item weapon, Player player)
        {
            bool canUse = BeforeConsumeAmmo(player);
            return canUse;
        }
        public void OnUseEffects(Player player)
        {
            BeadPlayer modPlayer = player.GetModPlayer<BeadPlayer>();
            modPlayer.attackNum++;
        }
        public bool CanUseItem(Player player)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(player);
            bool canUse = BeforeUseItem(player);
            bool cursed = player.HasBuff(BuffID.Cursed);
            if (cursed)
                return false;
            int currentVoid = voidPlayer.voidMeterMax2 - voidPlayer.lootingSouls - voidPlayer.VoidMinionConsumption;
            int finalCost = VoidCost(player);
            bool canDrainMana = BeforeDrainVoid(player);
            if ((voidPlayer.safetySwitch && canDrainMana) && voidPlayer.voidMeter < finalCost && !voidPlayer.frozenVoid)
            {
                return false;
            }
            if (!canUse || player.FindBuffIndex(ModContent.BuffType<VoidRecovery>()) > -1 || Item.useAnimation < 2)
            {
                return false;
            }
            OnUseEffects(player);
            if (Item.useAmmo == 0 && canDrainMana)
                DrainMana(player);
            if (Item.mana > 0)
                player.statMana += Item.mana;
            return true;
        }
        public bool? UseItem(Player player)
        {
            if (Item.createTile > -1)
            {
                return base.UseItem(player);
            }
            if (Item.useAmmo != 0 && BeforeDrainVoid(player))
                DrainMana(player);
            return true;
        }

        public virtual bool BeforeDrainVoid(Player player)
        {
            return true;
        }
        public virtual bool BeforeUseItem(Player player)
        {
            return true;
        }

        public virtual bool BeforeConsumeAmmo(Player player)
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
    }
}
