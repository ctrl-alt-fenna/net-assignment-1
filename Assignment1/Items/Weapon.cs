using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Items
{
    public class Weapon : Item
    {
        public WeaponTypes WeaponType { get; set; }
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
        public Weapon() : base()
        {}

        public override bool AllowEquip(Character c)
        {
            throw new NotImplementedException();
        }
    }
}
