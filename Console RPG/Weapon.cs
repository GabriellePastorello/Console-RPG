using System;
using System.Reflection.Metadata;

namespace Console_RPG
{
    class Weapon : Equipment
    {
        public static Weapon sword = new Weapon(10, 10.0f, "sword", "a normal sword", 2, 80);
        public static Weapon sword2 = new Weapon(10, 10.0f, "sword", "a normal sword", 2, 80);
        public static Weapon sword3 = new Weapon(10, 10.0f, "sword", "a normal sword", 2, 80);
        public static Weapon sword4 = new Weapon(10, 10.0f, "sword", "a normal sword", 2, 80);
        public static Weapon sword5 = new Weapon(10, 12.5f, "warrior's sword", "a slightly better sword", 3, 80);

        public static Weapon blackSword = new Weapon(1000, 0.0f, "Ebony's sword", "the sword of a dragon", 10, 1000000);
        public static Weapon dagger = new Weapon(5, 5, "Bandit's Dagger", "Standard weapon of choice for bandits", 1, 100);
        public static Weapon dagger2 = new Weapon(5, 5, "Bandit's Dagger", "Standard weapon of choice for bandits", 1, 100);
        public static Weapon dagger3 = new Weapon(5, 5, "Bandit's Dagger", "Standard weapon of choice for bandits", 1, 100);
        public static Weapon dagger4 = new Weapon(5, 5, "Bandit's Dagger", "Standard weapon of choice for bandits", 1, 100);
        public static Weapon dagger5 = new Weapon(5, 5, "Bandit's Dagger", "Standard weapon of choice for bandits", 1, 100);
        public static Weapon sword6 = new Weapon(10, 10.0f, "Bandit's Sword", "a normal sword", 2, 80);
        public static Weapon cultistSword = new Weapon(15, 15.25f, "Cultist Sword", "A sword used by cultists", 3, 50);
        public static Weapon cultistSword2 = new Weapon(15, 15.25f, "Cultist Sword", "A sword used by cultists", 3, 50);
        public static Weapon cultistSword3 = new Weapon(15, 15.25f, "Cultist Sword", "A sword used by cultists", 3, 50);
        public static Weapon cultistSword4 = new Weapon(15, 15.25f, "Cultist Sword", "A sword used by cultists", 3, 50);
        public static Weapon cultistSword5 = new Weapon(15, 15.25f, "Cultist Sword", "A sword used by cultists", 3, 50);
        public static Weapon cultistSword6 = new Weapon(15, 15.25f, "Cultist Sword", "A sword used by cultists", 3, 50);
        public static Weapon cultistSword7 = new Weapon(15, 15.25f, "Cultist Sword", "A sword used by cultists", 3, 50);
        public static Weapon ritualSword = new Weapon(50, 15.25f, "Ritual Sword", "A sword used on sacrifices", 4, 50);

        public static Weapon ritualSword2 = new Weapon(50, 50.25f, "Ritual Sword", "A sword used on sacrifices", 4, 50);
        public static Weapon sword7 = new Weapon(18, 15.0f, "Bandit's Sword", "a normal sword", 2, 80);
        public static Weapon sword8 = new Weapon(25, 15.25f, "Saber", "a lighter sword, but powerful", 4, 75);
        public static Weapon sword9 = new Weapon(37, 27.60f, "Greatsword", "a large sword, heavy but deals plenty of damage", 7, 100);
        public static Weapon spear = new Weapon(75, 25.25f, "Greatspear", "it pierces through dragon scales", 10, 80);
        public static Weapon sword10 = new Weapon(15, 12.5f, "Warrior's sword", "a slightly better sword", 3, 80);


        public int attackDamage;

        public Weapon(int price, float weight, string name, string description, int attackDamage,int durability) : base(price, weight, name, description, durability)
        {
            this.attackDamage = attackDamage;
        }

        public override void Use(Entity user, Entity target)
        {
            if (curDurability > 0)
            {
                curDurability -= user.stats.strength;
                if (curDurability <= 0)
                {
                    Console.WriteLine(name + " broke!");
                    user.stats.strength -= attackDamage;
                }
            }
        }

        public void equip(Entity user)
        {
            isEquiped = !isEquiped;

            if (isEquiped)
            {
                user.stats.strength += attackDamage;
                user.carryWeight -= weight;
            }
            else
            {
                user.stats.strength -= attackDamage;
                user.carryWeight -= weight;
            }
        }

        public void repair(Entity user)
        {
            if (curDurability == 0)
            {
                user.stats.strength += attackDamage;
            }
            curDurability = maxDurability;
            
        }
    }
}
