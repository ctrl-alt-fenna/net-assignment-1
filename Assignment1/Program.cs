using System;
using Assignment1.Characters;
using Assignment1.WeaponExceptions;
using Assignment1.Attributes;
using Assignment1.Items;
namespace Assignment1
{
    class Program
    {

        public static void Main()
        {
            Weapon myW = new Weapon()
            {
                ItemName = "Good axe",
                ItemRequiredLevel = 1,
                WeaponType = Weapon.WeaponTypes.Axe
            };
            Console.Write(myW.ItemName);
        }
    }
}