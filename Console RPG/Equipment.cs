using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public float curDurability, maxDurability;
        public bool isEquiped;

        protected Equipment(int price, float weight, string name, string description, float durability) : base(price, weight, name, description)
        {
            this.curDurability = durability;
            this.maxDurability = durability;
            isEquiped = false;
        }
    }
}
