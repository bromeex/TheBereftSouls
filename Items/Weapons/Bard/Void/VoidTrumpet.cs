using Microsoft.Xna.Framework;
using SOTS;
using TheBereftSouls.Void;
using TheBereftSouls.Projectiles.Rogue.Void;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using ThoriumMod;
using ThoriumMod.Projectiles.Bard;
using ThoriumMod.Sounds;
using System;
using ThoriumMod.Empowerments;
using ThoriumMod.Items.Darksteel;
using ThoriumMod.Utilities;
using System.Collections.Generic;

namespace TheBereftSouls.Items.Weapons.Bard.Void
{
    public class VoidTrumpet : VoidBardItem
    {
        public override string Texture => "TheBereftSouls/Items/Weapons/Bard/Void/ObsidianBoneTrumpet";

        public override void SetStaticDefaults()
        {
            this.SetResearchCost(1);
            Empowerments.AddInfo<AttackSpeed>(2);
        }

        public override void SetBardDefaults()
        {
            Item.damage = 29;
            InspirationCost = 1;
            Item.width = 25;
            Item.height = 40;
            Item.scale = 1f;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = 5;
            Item.holdStyle = 3;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.knockBack = 4f;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = 2;
            Item.UseSound = ThoriumSounds.Trumpet_Sound;
            Item.shoot = ModContent.ProjectileType<BoneTrumpetPro>();
            Item.shootSpeed = 12f;
        }

        public override int GetVoid(Player player)
        {
            return 5;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, 0f);
        }

    }
}