using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheBereftSouls.Content.DamageClasses;
using ThoriumMod;
using ThoriumMod.Empowerments;
using ThoriumMod.Items;
using ThoriumMod.Projectiles.Bard;
using ThoriumMod.Utilities;

namespace TheBereftSouls.Content.Items.Weapons.Bard.Void
{
    public class VesperaWarhorn : VoidBardItem
    {
        public override BardInstrumentType InstrumentType => BardInstrumentType.Brass;

        public override void SetStaticDefaults()
        {
            Empowerments.AddInfo<FlatDamage>(1);
            Empowerments.AddInfo<AttackSpeed>(2);
        }

        public override void SafeSetDefaults()
        {
            Item.damage = 51;
            InspirationCost = 3;
            Item.scale = 0.9f;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 5;
            Item.holdStyle = 3;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item104;
            Item.knockBack = 6f;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.shoot = ModContent.ProjectileType<ShadowflameWarhornPro>();
            Item.shootSpeed = 6f;
        }
        public override int GetVoid(Player player)
        {
            return 5;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0f, 8f);
        }
    }
}

