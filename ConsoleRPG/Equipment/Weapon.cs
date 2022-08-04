using Assignment1.CustomExceptions;

namespace Assignment1.Equipment
{
    public class Weapon : Item
    {
        // The weapontype taken from the enum WeaponTypes
        public WeaponTypes WeaponType { get; set; }
        // Damage in one hit
        public double BaseDamage { get; set; }
        public double AttacksPerSecond { get; set; }
        public enum WeaponTypes
        {
            Axe,
            Bow,
            Dagger,
            Hammer,
            Staff,
            Sword,
            Wand
        }
        // Randomize weaponstats on every creation
        public Weapon() : base()
        {
            Random rdm = new Random();
            BaseDamage = rdm.Next(1, 10);
            AttacksPerSecond = rdm.Next(1, 5);
        }
        /// <summary>
        /// Function to check if current charactertype matches allowed type for given weapontype
        /// </summary>
        /// <param name="c">A character object</param>
        /// <returns>True if character c is of correct class for given weapon, false if not</returns>
        /// <exception cref="InvalidWeaponException">Thrown if character c is not able/allowed to equip weapon in the current state</exception>
        public override bool AllowEquip(Character c)
        {
            if (c.Level >= ItemRequiredLevel)
            {
                if (WeaponType == WeaponTypes.Staff || this.WeaponType == WeaponTypes.Wand)
                {
                    return (c is Characters.Mage);
                }
                else if (WeaponType == WeaponTypes.Bow && ItemRequiredLevel <= c.Level)
                {
                    return (c is Characters.Ranger);
                }
                else if (WeaponType == WeaponTypes.Dagger && ItemRequiredLevel <= c.Level)
                {
                    return (c is Characters.Rogue);
                }
                else if (WeaponType == WeaponTypes.Axe || WeaponType == WeaponTypes.Hammer && ItemRequiredLevel <= c.Level)
                {
                    return (c is Characters.Warrior);
                }
                else if (WeaponType == WeaponTypes.Sword && ItemRequiredLevel <= c.Level)
                {
                    return (c is Characters.Rogue || c is Characters.Warrior);
                }
            }
            throw new InvalidWeaponException("Current level is too low to equip item: " + ItemRequiredLevel + " > " + c.Level);
        }
        /// <summary>
        /// Function to return Damage Per Second (DPS) of a weapon, by multiplying the weapon's
        /// BaseDamage with its AttacksPerSecond
        /// </summary>
        /// <returns>Damage per second as double</returns>
        public double DPS()
        { return BaseDamage * AttacksPerSecond; }
    }
}
