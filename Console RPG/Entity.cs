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
        public String name;
        public String race;
        public int currentHP, maxHP;
        public int currentMana, maxMana;
        public float carryWeight;
        public int damageTaken;
        public bool isMounted;
        public Mount mount;
        //This is called composition
        public Stats stats;
        public List<Item> inventory;
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
            damageTaken = 0;
            isMounted = false;

        }

        public abstract Entity ChooseTarget(List<Entity> targets);

        public abstract void Attack(Entity target);

        public void addToInventory(Item item)
        {
            if (item.weight <= this.carryWeight)
            {
                if (inventory is null)
                {
                    inventory = new List<Item>{item};
                    }
                else
                {
                    
                    inventory.Add(item);
                    
                }
                this.carryWeight -= item.weight;
                Console.WriteLine(item.name + " added to " + this.name + "'s inventory.");
            }
            else
            {
                Console.WriteLine(item.name + " couldn't be added to " + this.name + "'s inventory.");
            }
            
        }

        public void removeFromInventory(Item item)
        {
            carryWeight += item.weight;
            inventory.Remove(item);
            Console.WriteLine(item.name + " was removed from " + name + "'s inventory.");
        }

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }

        public abstract void getStatus();

        public void getParty(List<Entity> allies)
        {
            Console.WriteLine("Your party consists of: ");
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
                Console.WriteLine(i.name);
            }
        }
}
}
