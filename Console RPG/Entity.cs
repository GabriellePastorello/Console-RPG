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
                Console.WriteLine(i.name);
            }
            if (! (armour is null))
            {
                Console.WriteLine("Equiped armour: " + armour.name);
            }
            else
            {
                Console.WriteLine("Equiped armour: none");
            }
        }

        public void equipArmour(Armour armour)
        {
            if (this.armour is null)
            {
                this.armour = armour;
                carryWeight -= armour.weight;
                
            }
            else
            {
                carryWeight += this.armour.weight;
                stats.defence -= this.armour.defence;
                this.armour = armour;
                carryWeight += armour.weight;
            }
            Console.WriteLine(name + " equiped " + armour.name);
            stats.defence += armour.defence;
        }

        public void equipWeapon(Weapon weapon)
        {
            if (this.weapon is null)
            {
                this.weapon = weapon;
                carryWeight -= weapon.weight;

            }
            else
            {
                carryWeight += this.weapon.weight;
                stats.strength -= this.weapon.attackDamage;
                this.weapon = weapon;
                carryWeight += weapon.weight;
            }
            Console.WriteLine(name + " equiped " + weapon.name);
            stats.strength += weapon.attackDamage;
        }

        public abstract void DoTurn(List<Entity> allies, List<Enemy> enemies);

        public abstract void gainXP(int xp);
}
}
