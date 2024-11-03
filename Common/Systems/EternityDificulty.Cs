// I tried to make eternity appear as a selectable option in the calamity difficulty menu,
// but so far I haven't been able to do it. I'm leaving this code half-finished in case anyone wants to follow it, otherwise I'll follow it another day.

/*using System;
using CalamityMod.Systems;
using CalamityMod.World;
using FargowiltasSouls.Core.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargowiltasCrossmod.Core.Calamity;

[ExtendsFromMod(["CalamityMod"])]
public class EternityDifficulty : DifficultyMode
{
    private Asset<Texture2D> _texture;

    public override bool Enabled
    {
        get
        {
            return WorldSavingSystem.EternityMode;
        }
        set
        {
            if (value)
            {
                CalamityWorld.revenge = true;
                CalamityWorld.death = true;
            }
            bool emode = value;    
            WorldSavingSystem.EternityMode = emode;
            WorldSavingSystem.ShouldBeEternityMode = emode;
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                 PacketManager.SendPacket<EternityDeathPacket>(Array.Empty<object>());
            }
        }
    }

    public override Asset<Texture2D> Texture
    {
        get
        {
            if (_texture == null)
            {
                _texture = ModContent.Request<Texture2D>("FargowiltasCrossmod/Assets/EternityDeathIcon", (AssetRequestMode)2);
            }
            return _texture;
        }
    }

    public override LocalizedText ExpandedDescription => Language.GetText("Mods.FargowiltasCrossmod.EternityDeathDifficulty.ExpandedDescription");

    public EternityDifficulty()
    {
        //IL_0061: Unknown result type (might be due to invalid IL or missing references)
        //IL_0066: Unknown result type (might be due to invalid IL or missing references)
        DifficultyScale = 2f;
        Name = Language.GetText("Mods.FargowiltasCrossmod.EternityDeathDifficulty.Name");
        ShortDescription = Language.GetText("Mods.FargowiltasCrossmod.EternityDeathDifficulty.ShortDescription");
        ActivationTextKey = "Mods.FargowiltasCrossmod.EternityDeathDifficulty.Activation";
        DeactivationTextKey = "Mods.FargowiltasCrossmod.EternityDeathDifficulty.Deactivation";
        SoundStyle roar = SoundID.Roar;
        roar.Pitch = -0.5f;
        ActivationSound = roar;
        ChatTextColor = Color.DarkRed;
    }

    public override int FavoredDifficultyAtTier(int tier)
    {
        DifficultyMode[] tierList = DifficultyModeSystem.DifficultyTiers[tier];
        for (int i = 0; i < tierList.Length; i++)
        {
            if (tierList[i].Name.Value == "Death")
            {
                return i;
            }
        }
        return 0;
    }
}*/
