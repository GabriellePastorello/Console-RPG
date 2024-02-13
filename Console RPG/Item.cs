using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public int price;
        public float weight;
        public String name;
        public String description;

        public Item(int price, float weight, string name, string description)
        {
            this.price = price;
            this.weight = weight;
            this.name = name;
            this.description = description;
        }

        public abstract void Use(Entity user, Entity target);
    }
}
