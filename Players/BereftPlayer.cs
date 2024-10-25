using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace TheBereftSouls.Players
{
    public class BereftPlayer : ModPlayer
    {
        #region Accessories
        public bool VibrantEnch = false;

        public List<Vector2> vesperaStoneCoords = new List<Vector2>(); // Used by Vespera ench
        #endregion

        #region Buffs;
        public bool PatchedUp = false;
        #endregion
         


        public override void ResetEffects()
        {
            VibrantEnch = false;
            PatchedUp = false;
        }
    }
}
