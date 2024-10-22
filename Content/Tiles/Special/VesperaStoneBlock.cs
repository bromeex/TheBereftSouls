using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Audio;
using Terraria.Localization;

namespace TheBereftSouls.Content.Tiles.Special
{
    public class VesperaStoneBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.DrawsWalls[Type] = true;
            TileID.Sets.DontDrawTileSliced[Type] = true;
            TileID.Sets.IgnoresNearbyHalfbricksWhenDrawn[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;
        }
    }
}
