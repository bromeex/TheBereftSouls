using System;
using System.Collections.Generic;
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
using static Terraria.ModLoader.ModContent;

namespace TheBereftSouls.Common.Systems
{
    [ExtendsFromMod("CalamityMod", "FargowiltasSouls", "SOTS")]
    public class BossRushInjectionSystem : ModSystem
    {
        public override void PostSetupContent()
        {
            LoadBossRushEntries(ModLoader.GetMod("CalamityMod"));
        }


        internal static void LoadBossRushEntries(Mod cal)
        {
            List<(int, int, Action<int>, int, bool, float, int[], int[])> brEntries = (List<(int, int, Action<int>, int, bool, float, int[], int[])>)cal.Call("GetBossRushEntries");

            AddToBossRush(ref brEntries, NPCID.KingSlime, NPCType<TrojanSquirrel>(),[NPCType<TrojanSquirrelArms>(), NPCType<TrojanSquirrelHead>()]);
            AddToBossRush(ref brEntries, NPCID.WallofFlesh, NPCType<DeviBoss>());
            AddToBossRush(ref brEntries, NPCID.TheDestroyer, NPCType<BanishedBaron>());
            AddToBossRush(ref brEntries, NPCType<CalamitasClone>(), NPCType<LifeChallenger>());
            AddToBossRush(ref brEntries, NPCType<Providence>(), NPCType<CosmosChampion>());
            AddToBossRush(ref brEntries, NPCType<DevourerofGodsHead>(), NPCType<AbomBoss>(),[NPCType<AbomSaucer>()]);
            AddToBossRush(ref brEntries, NPCType<SupremeCalamitas>(), NPCType<MutantBoss>(),[NPCType<MutantIllusion>()]);
            cal.Call("SetBossRushEntries", brEntries);
        }

        /// <summary>
        /// Adds a boss to the Calamity Boss Rush event.
        /// </summary>
        /// <param name="brEntries">Just pass in the boss rush list, cmon you can do it!.</param>
        /// <param name="beforeBossType">The boss that is fought directly after the boss you want to insert.</param>
        /// <param name="NPCType">The boss you want to insert.</param>
        /// <param name="extraNPCs">Minions/parts of the boss.</param>
        /// <param name="needsDead">Components of the boss that need to be defeated to progress such as Golem parts.</param>
        /// <param name="needsNight">Sets time to night if true.</param>
        /// <param name="customAction">Extra code to perform when spawning the boss.</param>
        internal static void AddToBossRush(ref List<(int, int, Action<int>, int, bool, float, int[], int[])> brEntries, int beforeBossType, int NPCType, int[] extraNPCs = default, int[] needsDead = default, bool needsNight = false, Action<int> customAction = default)
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

            // NPCs that are allowed to exist. if the passed in array is default, just use the boss
            int[] allowedIDs =[NPCType];
            if (extraNPCs != default)
            {
                allowedIDs = extraNPCs;
            }

            // NPCs required to be defeated to finish the fight. if the passed in array is default, just use the boss
            int[] requiredIDs =[NPCType];
            if (needsDead != default)
            {
                requiredIDs = needsDead;
            }

            // what happens when the boss is spawned. by default it just spawns one on the closest player to the world center
            Action<int> pr2 = npc =>
            {
                NPC.SpawnOnPlayer(CalamityMod.Events.BossRushEvent.ClosestPlayerToWorldCenter, NPCType);
            };
            if (customAction != default)
            {
                pr2 = customAction;
            }

            // the countdown override, custom sound, and dimness factors are all hardcoded for now as no boss currently warrants them
            brEntries.Insert(bossidx, (NPCType, needsNight ? -1 : 1, pr2, 45, false, 0f, allowedIDs, requiredIDs));
        }
    }
}