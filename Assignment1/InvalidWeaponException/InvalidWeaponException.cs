using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.WeaponExceptions
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException() : base("Weapon cannot be equipped in current state")
        { }

        public InvalidWeaponException(string? message) : base(message)
        { }
    }
}
