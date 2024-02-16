using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Mount : Entity
    {
        public int curPassengers, maxPassengers;

        public Mount(string name, string race, int hp, int mana, float carryWeight, Stats stats, int passengers) : base(name, race, hp, mana, carryWeight, stats)
        {
            curPassengers = 0;
            maxPassengers = passengers;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }
        public override void Attack(Entity target)
        {
            //finish
            if (curPassengers == 0)
            {
                Random random = new Random();
                int damage = (stats.strength + random.Next(stats.strength)) - target.stats.defence;
                int dodgeChance = target.stats.speed;
                if (damage <= 0)
                {
                    Console.WriteLine(target.name + " blocked the attack!");
                }
                else if (random.Next(40) <= dodgeChance)
                {
                    Console.WriteLine(target.name + " dodged " + name + "' attack!");
                }
                else
                {
                    Console.WriteLine(name + " attacked " + target.name + " for " + damage + " damage!");
                    target.currentHP -= damage;
                }
            }
        }

        public override void getStatus()
        {
            Console.WriteLine("Name: " + this.name);
            Console.WriteLine("Race: " + this.race);
            Console.WriteLine("Health: " + this.currentHP + "/" + this.maxHP);
            Console.WriteLine("Mana: " + this.currentMana + "/" + this.maxMana);
            Console.WriteLine("Remaining carry weight: " + this.carryWeight);
            Console.WriteLine("Passengers: " + curPassengers + "/" + maxPassengers);
            Console.WriteLine("Speed: " + this.stats.speed + " Strength: " + this.stats.strength + " Defence: " + this.stats.defence + " Intelligence: " + this.stats.intelligence);
        }
    }
}
