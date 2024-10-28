using Terraria.ModLoader;
using SOTS.Void;
using CalamityMod;
using ThoriumMod;

namespace TheBereftSouls.Content.DamageClasses
{
    [ExtendsFromMod(["SOTS","CalamityMod"])]
    public class VoidRogue : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic || damageClass == ModContent.GetInstance<VoidGeneric>() || damageClass == ModContent.GetInstance<RogueDamageClass>() || damageClass == Throwing)
                return StatInheritanceData.Full;
            return StatInheritanceData.None;
        }
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == ModContent.GetInstance<RogueDamageClass>() || damageClass == ModContent.GetInstance<VoidGeneric>() || damageClass == Throwing)
                return true;
            return false;
        }
    }
    [ExtendsFromMod(["SOTS", "ThoriumMod"])]
    public class VoidBard : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic || damageClass == ModContent.GetInstance<VoidGeneric>() || damageClass == ModContent.GetInstance<BardDamage>())
                return StatInheritanceData.Full;
            return StatInheritanceData.None;
        }
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == ModContent.GetInstance<BardDamage>() || damageClass == ModContent.GetInstance<VoidGeneric>())
                return true;
            return false;
        }
    }
    [ExtendsFromMod(["SOTS", "ThoriumMod"])]
    public class VoidHealer : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic || damageClass == ModContent.GetInstance<VoidGeneric>() || damageClass == ModContent.GetInstance<HealerDamage>())
                return StatInheritanceData.Full;
            return StatInheritanceData.None;
        }
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == ModContent.GetInstance<HealerDamage>() || damageClass == ModContent.GetInstance<VoidGeneric>())
                return true;
            return false;
        }
    }
}