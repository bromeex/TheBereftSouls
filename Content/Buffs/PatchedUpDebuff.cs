using Terraria;
using Terraria.ModLoader;
using TheBereftSouls.Players;

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
            player.GetModPlayer<BereftPlayer>().PatchedUp = true;
        }
    }
}
