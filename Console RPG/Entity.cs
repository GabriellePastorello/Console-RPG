using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    //Structs are useful for storing simple plain data
    struct Stats
    {
        public int speed;
        public int defence;
        public int strength;
        public int intelligence;

        public Stats(int speed, int defence, int strength, int intelligence)
        {
            this.speed = speed;
            this.defence = defence;
            this.strength = strength;
            this.intelligence = intelligence;
        }
    }

    //classes are useful for storing complex objects
    abstract class Entity
    {
       public static List<Entity> allies = new List<Entity> { Player.player, Mount.horse};


        public String name;
        public String race;
        public int currentHP, maxHP;
        public int currentMana, maxMana;
        public float carryWeight;
        //This is called composition
        public Stats stats;
        public List<Item> inventory;
        public Armour armour;
        public Weapon weapon;
        public Entity(string name, string race, int hp, int mana, float carryWeight, Stats stats)
        {
            this.name = name;
            this.race = race;
            currentHP = hp;
            maxHP = hp;
            currentMana = mana;
            maxMana = mana;
            this.carryWeight = carryWeight;
            this.stats = stats;
            inventory = new List<Item> { HealthPotionItem.healthPotion, ManaPotionItem.manaPotion };
            if (!(weapon is null))
            {
                weapon.equip(this);
            }
            if (!(armour is null))
            {
                armour.equip(this);
            }

        }

        public abstract Entity ChooseTarget(List<Entity> targets);

        public abstract void Attack(Entity target);

        public abstract void Spell(Entity target);

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }

        public void getParty()
        {
            Console.WriteLine("\nYour party consists of: ");
            foreach (Entity i in allies)
            {
                Console.WriteLine(i.name);
            }
        }

        public void showInventory()
        {
            Console.WriteLine("\n" + this.name + "'s remaining carry weight: " + this.carryWeight);
            Console.WriteLine(this.name + "'s inventory:");
            foreach(Item i in inventory)
            {
                Console.WriteLine(i.name + " - " + i.description);
            }
            if (! (armour is null))
            {
                Console.WriteLine("Equiped armour: " + armour.name + " - " + armour.description);
                Console.WriteLine("Durability: " + armour.curDurability + "/" + armour.maxDurability);
                Console.WriteLine("Defence: " + armour.defence);
            }
            else
            {
                Console.WriteLine("Equiped armour: none");
            }
            if (! (weapon is null))
            {
                Console.WriteLine("Equiped weapon " + weapon.name + " - " + weapon.description);
                Console.WriteLine("Durability: " + weapon.curDurability + "/" + weapon.maxDurability);
                Console.WriteLine("Damage: " + weapon.attackDamage);
            }
            else
            {
                Console.WriteLine("Equiped weapon: none");
            }
        }

        public void viewStats()
        {
            Console.WriteLine("\nName: " + name);
            Console.WriteLine("Speed: " + stats.speed);
            Console.WriteLine("Strength: " + stats.strength);
            Console.WriteLine("Defence: " + stats.defence);
            Console.WriteLine("Intelligence: " + stats.intelligence);
        }

        public abstract void DoTurn(List<Entity> allies, List<Enemy> enemies);

        public abstract void gainXP(int xp);
}
}
