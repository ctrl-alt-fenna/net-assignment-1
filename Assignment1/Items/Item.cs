using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Items
{
    public abstract class Item
    {
        public string? ItemName { get; set; }
        public int ItemRequiredLevel { get; set; }
        public enum Slot 
        {
            WeaponSlot,
            ArmourSlots_Head,
            ArmourSlots_Body,
            ArmourSlots_Legs,
            EquipmentSlot
        }
        public abstract bool AllowEquip(Character c);
    }
}
