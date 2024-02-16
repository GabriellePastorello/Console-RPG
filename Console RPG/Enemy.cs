using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public int expSpoils;
        public int goldSpoils;
        public int chaos;

        public Enemy(string name, string race, int hp, int mana, float carryWeight, Stats stats, int spoils, int goldSpoils, int chaos) : base(name, race, hp, mana, carryWeight, stats)
        {
            expSpoils = spoils;
            this.goldSpoils = goldSpoils;
            this.chaos = chaos;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target)
        {
            Random random = new Random();
            int damage = (stats.strength + random.Next(stats.strength)) - target.stats.defence;
            int dodgeChance = target.stats.speed;
            if (damage <= 0)
            {
                Console.WriteLine(target.name + " blocked the attack!");
                target.damageTaken = 0;
            }
            else if (random.Next(40) <= dodgeChance)
            {
                Console.WriteLine(target.name + " dodged " + "'s attack!");
                target.damageTaken = 0;
            }
            else
            {
                Console.WriteLine(name + " attacked " + target.name + " for " + damage + " damage!");
                target.currentHP -= damage;
                target.damageTaken = damage;
            }
        }

        public override void getStatus()
        {
            Console.WriteLine("Name: " + this.name);
            Console.WriteLine("Race: " + this.race);
            Console.WriteLine("Chaos: " + this.chaos);
            Console.WriteLine("Health: " + this.currentHP + "/" + this.maxHP);
            Console.WriteLine("Mana: " + this.currentMana + "/" + this.maxMana);
            Console.WriteLine("Speed: " + this.stats.speed + " Strength: " + this.stats.strength + " Defence: " + this.stats.defence + " Intelligence: " + this.stats.intelligence);
            if (isMounted)
            {
                Console.WriteLine("Mount: " + this.mount.name);
            }
            else
            {
                Console.WriteLine("Mount: none");
            }
        }
    }
}
