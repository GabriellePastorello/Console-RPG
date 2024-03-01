using System;

namespace Console_RPG
{
    class Armour : Item
    {
        public static Armour leather = new Armour(12, 15.4f, "Leather Armour", "Simple leather armour.", 5, 27);
        public static Armour steel = new Armour(35, 40.5f, "Steel Armour", "This is heavy.", 25, 150);

        public int defence;
        public int curDurability, maxDurability;

        public Armour(int price, float weight, string name, string description, int defence, int durability) : base(price, weight, name, description)
        {
            this.defence = defence;
            this.curDurability = durability;
            this.maxDurability = durability;
        }

        public override void Use(Entity user, Entity target)
        {
            curDurability -= 1;
            if (curDurability <= 0)
            {
                Console.WriteLine(name + " broke!");
                user.stats.defence -= this.defence;
                defence = 0;
            }
        }
    }
}
