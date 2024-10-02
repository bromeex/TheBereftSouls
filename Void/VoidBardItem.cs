using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using ThoriumMod;
using ThoriumMod.Items;
using ThoriumMod.Utilities;

namespace TheBereftSouls.Void
{
    public class VoidBardItem : ThoriumItem
    {
        public SoundStyle? PlayedSound { get; private set; }
        public virtual void SetBardDefaults()
        {
        }
        public virtual void GetInstrumentCrit(ThoriumPlayer bard, ref float crit)
        {
        }

        public virtual void ModifyInstrumentDamage(ThoriumPlayer bard, ref StatModifier damage)
        {
        }
        public sealed override void SetDefaults()
        {
            SetBardDefaults();
            PlayedSound = Item.UseSound;
            Item.UseSound = null;
            Item.DamageType = (DamageClass)(object)ThoriumDamageBase<BardDamage>.Instance;
        }

        public sealed override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            base.ModifyWeaponDamage(player, ref damage);
            ThoriumPlayer bard = player.GetThoriumPlayer();
            if (bard.accPitchHelper)
            {
                damage *= 0f;
            }
            ModifyInstrumentDamage(bard, ref damage);
        }
        public override void ModifyWeaponCrit(Player player, ref float crit)
        {
        }


    }
}
