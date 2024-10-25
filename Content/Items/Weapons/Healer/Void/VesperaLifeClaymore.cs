using TheBereftSouls.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.Misc;
using ThoriumMod.Rarities;
using ThoriumMod.Utilities;
using ThoriumMod;
using static Terraria.NPC;
using SOTS;
using CalamityMod;

namespace TheBereftSouls.Content.Items.Weapons.Healer.Void
{
    public class VesperaLifeClaymore : VoidDamageItem
    {
        public override void SetStaticDefaults()
        {
            this.SetResearchCost(1);
        }
        public override void SetItemDefaults()
        {
            Item.DamageType = ModContent.GetInstance<HealerDamage>();
            //Item.DamageType = ModContent.GetInstance<VoidHealer>();
            Item.damage = 18;
            //isHealer = true;
            //healDisplay = true;
            //healType = HealType.LifeSteal;
            //healAmount = 1;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.knockBack = 6f;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
        }

        public override void OnHitNPC(Player player, NPC target, HitInfo hit, int damageDone)
        {
            ThoriumPlayer thoriumPlayer = player.GetThoriumPlayer();
            player.HealLife(1 + thoriumPlayer.healBonus);
            
        }
        public override int GetVoid(Player player)
        {
            return 5;
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            Item.DamageType = ModContent.GetInstance<VoidHealer>();
        }
        public override void AddRecipes(){}
    }
}

