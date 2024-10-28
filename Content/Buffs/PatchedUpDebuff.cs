using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Players;

namespace TheBereftSouls.Content.Buffs
{
    [ExtendsFromMod("SOTS")]
    public class PatchedUpDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BereftSOTSPlayer>().PatchedUp = true;
        }
    }
}
