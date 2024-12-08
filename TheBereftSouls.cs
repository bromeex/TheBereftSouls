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
        if (ModLoader.TryGetMod("CalamityMod", out Mod cal))
            calamity = cal;
        if (ModLoader.TryGetMod("Fargowiltas", out Mod fargo))
            fargos = fargo;
        if (ModLoader.TryGetMod("FargowiltasSouls", out Mod souls))
            fargosSouls = souls;
        if (ModLoader.TryGetMod("SOTS", out Mod sot))
            sots = sot;
        if (ModLoader.TryGetMod("ThoriumMod", out Mod thor))
            thorium = thor;
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
