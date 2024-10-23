<h1>Creating Simple Void Weapons</h1>
<h2>Vanilla</h2>
<p>To make a void item using a vanilla damage class there are several things you need to do.</p>
<p>Instead of extending ModItem a you need the items class to be an extension of void Item</p>

    public class PlaceholderWeapon : VoidItem
	{
        ...
    }

<p>Instead of setting the item defaults with SetDefaults() you must use SafeSetDefaults as the VoidItem class uses a sealed override of the standard SetDefaults class</p>

    public override void SafeSetDefaults()
	{
        ...
    }
<p>When setting the damage type in the SafeSetDefaults() method you should set the damage type to the regular damage type you want the weapon to have as the damage type gets updated to the void version in the VoidItem class.</p>
<p>Lastly to set the void cost of the weapon you should use the GetVoid() method</p>

    public override int GetVoid(Player player)
    {
        return 5; //sets the void cost to 5
    }
<h2>Healer and Rogue</h2>
<p>Making void weapons for healer and rogue weapons is relatively similar to making void weapons for vanilla damage types. They will however need to extend VoidDamageItem rather then VoidItem</p>

    public class PlaceholderWeapon : VoidDamageItem
	{
        ...
    }
<p>Just like with vanilla damage types we want to use SafeSetDefaults() to set the item defaults. We also want to use the base damage type of the weapon rather then the void variant when setting the defaults.</p>

    public override void SafeSetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<HealerDamage>();
    }

    public override void SafeSetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RogueDamageClass>();
    }
<p>The void cost of the item should be set using the GetVoid() method like with vanilla damage types.</p>
<h2>Bard</h2>
<p>When making a void bard weapon you need to extend the VoidBardItem class</p>

    public class PlaceholderWeapon : VoidBardItem
	{
        ...
    }

<p>You need to define the instrument type using a override of the BardInstrumentType</p>

    public override BardInstrumentType InstrumentType => BardInstrumentType.Brass;

<p>You should use the SetStaticDefaults() method to add empowerments to the weapon</p>

    public override void SetStaticDefaults()
    {
        Empowerments.AddInfo<FlatDamage>(1);
        Empowerments.AddInfo<AttackSpeed>(2);
    }

<p>Once again just like with vanilla damage types we want to use SafeSetDefaults() to set the item defaults. We do not want to set a damage type here as the extend class sets the damage type to symphonic by default (we need to change this later). Inspiration cost should be set in the SafeSetDefaults() method using InspirationCost =;</p>

    public override void SafeSetDefaults()
    {
        InspirationCost = 10;

    }
<p>The void cost should be set the same ways as with the other weapon types.</p>
<p>To make the item use the void + symphonic damage type we must now set the items damage type to the correct damage type (this is beacause the weapons damage gets set to just normal bard in a sealed override of SetDefaults() after SafeSetDefaults is run).</p>
<p>One way of doing this is with the GlobalItem system</p>

    public class PlaceholderGlobalItem : GlobalItem
    {
        private static List<int> Weapons = new List<int>
        {
            ModContent.ItemType<PlaceholderWeapon>()
        };
        public override void SetDefaults(Item item)
        {
            foreach (int WeaponId in Weapons)
            {
                if (item.type == WeaponId)
                {
                    item.DamageType = ModContent.GetInstance<VoidBard>();
                    base.SetDefaults(item);
                }
            }
        }
    }

<p>To find out more about making void items I would suggest you refer to the SOTS github https://github.com/VortexOfRainbows/SOTS</p>