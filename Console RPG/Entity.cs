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
        public int damageTaken;
        public bool isMounted;
        public Mount mount;
        //This is called composition
        public Stats stats;
        public Entity(string name, string race, int hp, int mana, Stats stats)
        {
            this.name = name;
            this.race = race;
            currentHP = hp;
            maxHP = hp;
            currentMana = mana;
            maxMana = mana;
            this.stats = stats;
            damageTaken = 0;
            isMounted = false;

        }

        public abstract Entity ChooseTarget(List<Entity> targets);

        public abstract void Attack(Entity target);

        public abstract void GetStats();

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
    }
}
