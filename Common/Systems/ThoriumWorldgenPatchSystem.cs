using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using ThoriumMod.Tiles;
using ThoriumMod.WorldGeneration;

namespace TheBereftSouls.Common.Systems;

[ExtendsFromMod("ThoriumMod")]
public class ThoriumWorldgenPatchSystem : ModSystem
{

    // Edit Thorium's ore generation to avoid the sides of the world
    // This prevents them from generating on Abyss blocks
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
    {
        int thoriumOreIndex = tasks.FindIndex((GenPass g) => g.Name == "Thorium Mod: Shinies");
        int thoriumGemIndex = tasks.FindIndex((GenPass g) => g.Name == "Thorium Mod: Gem Ores");

        if (thoriumOreIndex != -1)
        {
            tasks.Remove(tasks[thoriumOreIndex]);
            tasks.Insert(tasks.FindIndex((GenPass g) => g.Name == "Shinies") + 1, new PassLegacy("TheBereftSouls: Thorium Ores", (progress, config) =>
            {
                ThoriumOres(progress, config);
            }));
        }

        if (thoriumGemIndex != -1)
        {
            tasks.Remove(tasks[thoriumGemIndex]);
            tasks.Insert(tasks.FindIndex((GenPass g) => g.Name == "Gems") + 1, new PassLegacy("TheBereftSouls: Thorium Gems", (progress, config) =>
            {
                GenerateGemOres(progress, config);
            }));
        }
    }

    private static void GenerateGemOres(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = Language.GetTextValue("LegacyWorldGen.23");
        bool calorRem = TheBereftSouls.calamity != null || WorldGenerationSystem.RemnantsEnabled;
        for (int i = 0; i < 2; i++)
        {
            int type = i == 0 ? ModContent.TileType<Opal>() : ModContent.TileType<Aquamarine>();
            int iterations = (int)((float)Main.maxTilesX * ((i == 0) ? 0.4f : 0.35f) * 0.2f);
            for (int j = 0; j < iterations; j++)
            {
                int minValue = (int)Main.worldSurface;
                int maxValue = Main.maxTilesY;
                if (WorldGen.remixWorldGen)
                {
                    maxValue = Main.maxTilesY - 360;
                }

                int xMin = 0;
                int xMax = Main.maxTilesX;
                if (calorRem && xMax - 2 * WorldGenerationSystem.RemnantsNoOreInMapEdgesZone > xMin)
                {
                    xMin += WorldGenerationSystem.RemnantsNoOreInMapEdgesZone;
                    xMax -= WorldGenerationSystem.RemnantsNoOreInMapEdgesZone;
                }

                int posX = WorldGen.genRand.Next(xMin, xMax);
                int posY = WorldGen.genRand.Next(minValue, maxValue);
                while (Main.tile[posX, posY].TileType != 1)
                {
                    posX = WorldGen.genRand.Next(xMin, xMax);
                    posY = WorldGen.genRand.Next(minValue, maxValue);
                }

                WorldGen.TileRunner(posX, posY, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type);
            }
        }
    }

    private static void ThoriumOres(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = "Thorium Mod : " + Language.GetTextValue("LegacyWorldGen.16");
        bool calorRem = TheBereftSouls.calamity != null || WorldGenerationSystem.RemnantsEnabled;
        int totalTiles = Main.maxTilesX * Main.maxTilesY;
        int type = ModContent.TileType<global::ThoriumMod.Tiles.ThoriumOre>();
        int yMin = (int)((float)Main.maxTilesY * 0.5f);
        int yMax = Main.maxTilesY;
        if (calorRem && yMax - WorldGenerationSystem.RemnantsNoOreInHellZone > yMin)
        {
            yMax -= WorldGenerationSystem.RemnantsNoOreInHellZone;
        }

        int xMin = 0;
        int xMax = Main.maxTilesX;
        if (calorRem && xMax - 2 * WorldGenerationSystem.RemnantsNoOreInMapEdgesZone > xMin)
        {
            xMin += WorldGenerationSystem.RemnantsNoOreInMapEdgesZone;
            xMax -= WorldGenerationSystem.RemnantsNoOreInMapEdgesZone;
        }

        if (WorldGen.remixWorldGen)
        {
            yMin = (int)Main.worldSurface;
            yMax = (int)((float)Main.maxTilesY * 0.5f) + 120;
        }

        for (int i = 0; (double)i < (double)totalTiles * 0.00015; i++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(xMin, xMax), WorldGen.genRand.Next(yMin, yMax), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), type);
        }

        type = ModContent.TileType<SmoothCoal>();
        yMin = (int)GenVars.rockLayerHigh;
        yMax = Main.maxTilesY;
        if (calorRem && yMax - WorldGenerationSystem.RemnantsNoOreInHellZone > yMin)
        {
            yMax -= WorldGenerationSystem.RemnantsNoOreInHellZone;
        }

        if (WorldGen.remixWorldGen)
        {
            yMin = (int)Main.worldSurface;
            yMax = (int)GenVars.rockLayerLow;
        }

        for (int j = 0; (double)j < (double)totalTiles * 0.00012; j++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(xMin, xMax), WorldGen.genRand.Next(yMin, yMax), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), type);
        }

        type = ModContent.TileType<global::ThoriumMod.Tiles.LifeQuartz>();
        yMin = (int)GenVars.rockLayerHigh;
        yMax = Main.maxTilesY;
        if (calorRem && yMax - WorldGenerationSystem.RemnantsNoOreInHellZone > yMin)
        {
            yMax -= WorldGenerationSystem.RemnantsNoOreInHellZone;
        }

        if (WorldGen.remixWorldGen)
        {
            yMin = (int)Main.worldSurface;
            yMax = (int)GenVars.rockLayerLow;
        }

        for (int k = 0; (double)k < (double)totalTiles * 0.0001; k++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(xMin, xMax), WorldGen.genRand.Next(yMin, yMax), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), type);
        }
    }
}