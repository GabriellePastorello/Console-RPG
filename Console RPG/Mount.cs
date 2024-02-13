using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Mount : Entity
    {
        public int curPassengers, maxPassengers;

        public Mount(string name, string race, int hp, int mana, Stats stats, int passengers) : base(name, race, hp, mana, stats)
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

        public override void GetStats()
        {
            throw new NotImplementedException();
        }
    }
}
