using Terraria.ModLoader;

namespace TheBereftSouls;

public class TheBereftSouls : Mod
{
    internal static TheBereftSouls Instance = null!;

    public static Mod calamity = null!;
    public static Mod fargos = null!;
    public static Mod fargosSouls = null!;
    public static Mod sots = null!;
    public static Mod thorium = null!;

    public override void Load()
    {
        Instance = this;
        ModLoader.TryGetMod("CalamityMod", out calamity);
        ModLoader.TryGetMod("Fargowiltas", out fargos);
        ModLoader.TryGetMod("FargowiltasSouls", out fargosSouls);
        ModLoader.TryGetMod("SOTS", out sots);
        ModLoader.TryGetMod("ThoriumMod", out thorium);
    }

    public override void Unload()
    {
        Instance = null!;
        calamity = null!;
        fargos = null!;
        fargosSouls = null!;
        sots = null!;
        thorium = null!;
    }
}
