using System;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.NPCs.CalClone;
using CalamityMod.NPCs.DevourerofGods;
using CalamityMod.NPCs.Providence;
using CalamityMod.NPCs.SupremeCalamitas;
using FargowiltasSouls.Content.Bosses.AbomBoss;
using FargowiltasSouls.Content.Bosses.BanishedBaron;
using FargowiltasSouls.Content.Bosses.Champions.Cosmos;
using FargowiltasSouls.Content.Bosses.DeviBoss;
using FargowiltasSouls.Content.Bosses.Lifelight;
using FargowiltasSouls.Content.Bosses.MutantBoss;
using FargowiltasSouls.Content.Bosses.TrojanSquirrel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static CalamityMod.Events.BossRushEvent;
using static Terraria.ModLoader.ModContent;

namespace TheBereftSouls.Common.Systems;

// Type alias.
//
// Referenced permalink:
// - https://github.com/CalamityTeam/CalamityModPublic/blob/a5bdc9231f2859abddb85c9043413a57fcb042b9/ModSupport/ModCalls.cs#L1999
using BossRushEntry = (int, int, Action<int>, int, bool, float, int[], int[]);

[ExtendsFromMod("CalamityMod", "FargowiltasSouls")]
public class BossRushInjectionSystem : ModSystem
{
    public override void PostSetupContent()
    {
        LoadBossRushEntries(ModLoader.GetMod("CalamityMod"));
    }

    internal static void LoadBossRushEntries(Mod cal)
    {
        // GetBossRushEntries call.
        //
        // Referenced permalink:
        // - https://github.com/CalamityTeam/CalamityModPublic/blob/a5bdc9231f2859abddb85c9043413a57fcb042b9/ModSupport/ModCalls.cs#L1998-L2006
        List<BossRushEntry> brEntries =
            (List<BossRushEntry>)ModCalls.Call("GetBossRushEntries");

        AddToBossRush(
            brEntries,
            NPCID.KingSlime,
            NPCType<TrojanSquirrel>(),
            extraNPCs: [NPCType<TrojanSquirrelArms>(), NPCType<TrojanSquirrelHead>()]
        );
        AddToBossRush(brEntries, NPCID.WallofFlesh, NPCType<DeviBoss>());
        AddToBossRush(brEntries, NPCID.TheDestroyer, NPCType<BanishedBaron>());
        AddToBossRush(brEntries, NPCType<CalamitasClone>(), NPCType<LifeChallenger>());
        AddToBossRush(brEntries, NPCType<Providence>(), NPCType<CosmosChampion>());
        AddToBossRush(
            brEntries,
            NPCType<DevourerofGodsHead>(),
            NPCType<AbomBoss>(),
            extraNPCs: [NPCType<AbomSaucer>()]
        );
        AddToBossRush(
            brEntries,
            NPCType<SupremeCalamitas>(),
            NPCType<MutantBoss>(),
            extraNPCs: [NPCType<MutantIllusion>()]
        );

        // SetBossRushEntries call.
        //
        // Referenced permalink:
        // - https://github.com/CalamityTeam/CalamityModPublic/blob/a5bdc9231f2859abddb85c9043413a57fcb042b9/ModSupport/ModCalls.cs#L2008-L2023
        ModCalls.Call("SetBossRushEntries", brEntries);
    }

    /// <summary>
    ///     Adds a boss to the Calamity Boss Rush event.
    /// </summary>
    /// <param name="brEntries">
    ///     Just pass in the boss rush list, cmon you can do it!.
    /// </param>
    /// <param name="beforeBossType">
    ///     The boss that is fought directly after the boss you want to insert. If the boss type is
    ///     invalid it defaults to the end of the array of bosses.
    /// </param>
    /// <param name="NPCType">
    ///     The boss you want to insert.
    /// </param>
    /// <param name="dimnessFactor">
    ///     Float field in the `CalamityMod.Events.BossRushEvent.Boss` struct.
    ///     Referenced permalink:
    ///     -
    ///     https://github.com/CalamityTeam/CalamityModPublic/blob/a5bdc9231f2859abddb85c9043413a57fcb042b9/Events/BossRushEvent.cs#L67
    /// </param>
    /// <param name="specialSpawnCountdown">
    ///     Int field in the `CalamityMod.Events.BossRushEvent.Boss` struct.
    ///     Referenced permalink:
    ///     -
    ///     https://github.com/CalamityTeam/CalamityModPublic/blob/a5bdc9231f2859abddb85c9043413a57fcb042b9/Events/BossRushEvent.cs#L66
    /// </param>
    /// <param name="usesSpecialSound">
    ///     Boolean field in the `CalamityMod.Events.BossRushEvent.Boss` struct.
    ///     Referenced permalink:
    ///     -
    ///     https://github.com/CalamityTeam/CalamityModPublic/blob/a5bdc9231f2859abddb85c9043413a57fcb042b9/Events/BossRushEvent.cs#L68
    /// </param>
    /// <param name="extraNPCs">
    ///     Minions/parts of the boss.
    /// </param>
    /// <param name="needsDead">
    ///     Components of the boss that need to be defeated to progress such as Golem parts.
    /// </param>
    /// <param name="needsNight">
    ///     Sets time to night if true.
    ///     Default:
    ///     - No time override.
    /// </param>
    /// <param name="customAction">
    ///     Extra code to perform when spawning the boss.
    ///     Default:
    ///     - The player who's closest to the center of the world.
    /// </param>
    internal static void AddToBossRush(
        List<BossRushEntry> brEntries,
        int beforeBossType,
        int NPCType,
        TimeChangeContext needsNight = TimeChangeContext.None,
        Action<int> customAction = null,
        int specialSpawnCountdown = 45,
        bool usesSpecialSound = false,
        float dimnessFactor = 0.0f,
        int[] extraNPCs = null,
        int[] needsDead = null
    )
    {
        // find the index of the boss to inject before
        int bossidx = -1;
        for (int i = 0; i < brEntries.Count; i++)
        {
            if (brEntries[i].Item1 == beforeBossType)
            {
                bossidx = i;
                break;
            }
        }
        if (bossidx < 0)
        {
            bossidx = brEntries[^1].Item1;
        }

        // NPCs that are allowed to exist. if the passed in array is null, just use the boss
        extraNPCs ??= [NPCType];

        // NPCs required to be defeated to finish the fight. if the passed in array is default,
        // just use the boss
        needsDead ??= [NPCType];

        // What happens when the boss is spawned. by default it just spawns one on the closest
        // player to the world center
        customAction ??= npc =>
        {
            NPC.SpawnOnPlayer(ClosestPlayerToWorldCenter, NPCType);
        };

        // The countdown override, custom sound, and dimness factors are all hardcoded for now
        // as no boss currently warrants them
        //
        // Referenced permalink:
        // - https://github.com/CalamityTeam/CalamityModPublic/blob/a5bdc9231f2859abddb85c9043413a57fcb042b9/Events/BossRushEvent.cs#L56C21-L61
        //
        // UsesSpecialSound
        // DimnessFactor
        brEntries.Insert(
            bossidx,
            (
                NPCType,
                (int)needsNight,
                customAction,
                specialSpawnCountdown,
                usesSpecialSound,
                dimnessFactor,
                extraNPCs,
                needsDead
            )
        );
    }
}
