using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace TheBereftSouls.Content.Buffs
{
    public class PatchedUpDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<InfectedPlayer>().patchedUp = true;
        }
    }

    public class InfectedPlayer : ModPlayer
    {
        public bool patchedUp = false;

        public override void ResetEffects()
        {
            patchedUp = false;
        }
    }
}
