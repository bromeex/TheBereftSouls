using Microsoft.Xna.Framework;
using Terraria;

namespace TheBereftSouls.Utils;

public class BereftUtils
{
    /// <summary>
    /// <para>Creates a circle of dust around a given position.</para>
    /// <para><paramref name="noGrav"/> - if false, dust will be affected by gravity.</para>
    /// </summary>
    /// <param name="position"></param>
    /// <param name="amount"></param>
    /// <param name="speed"></param>
    /// <param name="dustID"></param>
    /// <param name="scale"></param>
    /// <param name="noGrav"></param>
    /// <param name="alpha"></param>
    /// <param name="newColor"></param>
    public static void DustCircle(
        Vector2 position,
        int amount,
        float speed,
        int dustID,
        float scale = 1,
        bool noGrav = true,
        int alpha = 0,
        Color newColor = default
    )
    {
        for (int i = 0; i < amount; i++)
        {
            var dust = Dust.NewDustDirect(position, 1, 1, dustID);
            dust.velocity = new Vector2(0, -speed).RotatedBy(
                MathHelper.ToRadians(i * (360 / amount))
            );
            if (noGrav)
            {
                dust.noGravity = true;
            }
        }
    }
}
