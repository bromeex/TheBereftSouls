using Terraria.ModLoader;

namespace TheBereftSouls.Common.Players;

// This is a work-in-progress!
// These variables will be actually used once we implement the accessories.

[ExtendsFromMod("ThoriumMod")]
public class BereftThoriumPlayer : ModPlayer
{
    // Life Shield expansion.

    // Calamity-based Life Shields.
    public bool AerialiteLifeShield { get; set; } = false;
    public bool ProfanedLifeShield { get; set; } = false;
    public bool PolterghastLifeShield { get; set; } = false;
    public bool ElementalLifeShield { get; set; } = false;
    public bool AuricLifeShield { get; set; } = false;
    public bool ExoLifeShield { get; set; } = false;
    public bool DemonshadeLifeShield { get; set; } = false;

    private void ResetVariables()
    {
        AerialiteLifeShield = false;
        ProfanedLifeShield = false;
        PolterghastLifeShield = false;
        ElementalLifeShield = false;
        AuricLifeShield = false;
        ExoLifeShield = false;
        DemonshadeLifeShield = false;
    }

    public override void Initialize()
    {
        ResetVariables();
    }

    public override void ResetEffects()
    {
        ResetVariables();
    }
}
