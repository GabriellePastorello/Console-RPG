using System;

namespace Console_RPG
{
    class Weapon : Item
    {
        public static Weapon sword = new Weapon(10, 10.0f, "sword", "a normal sword", 10, 80);

        public int attackDamage;
        public int curDurability, maxDurability;

        public Weapon(int price, float weight, string name, string description, int attackDamage,int durability) : base(price, weight, name, description)
        {
            this.attackDamage = attackDamage;
            this.curDurability = durability;
            this.maxDurability = durability;
        }

        public override void Use(Entity user, Entity target)
        {
            curDurability -= user.stats.strength;
            if (curDurability <= 0)
            {
                Console.WriteLine(name + " broke!");
                user.stats.strength -= attackDamage;
                user.stats.strength += 1;
                attackDamage = 1;
            }
        }
    }
}
