using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Mount : Entity
    {
        public static Mount horse = new Mount("Horse", "Horse", 150, 30, 500, new Stats(10, 7, 7, 2), 2);
        public static Mount horse2 = new Mount("Other Horse", "Horse", 150, 30, 500, new Stats(10, 7, 7, 2), 2);
        public static Mount horse3 = new Mount("Other Other Horse", "Horse", 150, 30, 500, new Stats(10, 7, 7, 2), 2);
        public static Mount Qilin = new Mount("Qilin", "Qilin", 250, 50, 800, new Stats(15, 9, 9, 4), 1);

        public int curPassengers, maxPassengers;

        public Mount(string name, string race, int hp, int mana, float carryWeight, Stats stats, int passengers) : base(name, race, hp, mana, carryWeight, stats)
        {
            curPassengers = 0;
            maxPassengers = passengers;
        }

        public void changeName (String name)
        {
            this.name = name;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            Entity target = targets[random.Next(targets.Count)];
            if (target.currentHP > 0 )
            {
                return target;
            }
            else
            {
                return ChooseTarget(targets);
            }
        }
        public override void Attack(Entity target)
        {
            if (curPassengers == 0)
            {
                Console.WriteLine("\n");
                Random random = new Random();
                int damage = (stats.strength + random.Next(stats.strength)) - target.stats.defence;
                int dodgeChance = target.stats.speed - this.stats.speed;
                if (damage <= 0)
                {
                    Console.WriteLine(target.name + " blocked " + name + "'s attack!");
                    if (!(target.armour is null))
                    {
                        target.UseItem(target.armour, target);
                    }
                }
                else if (random.Next(40) <= dodgeChance)
                {
                    Console.WriteLine(target.name + " dodged " + name + "'s attack!");
                }
                else
                {
                    Console.WriteLine(name + " attacked " + target.name + " for " + damage + " damage!");
                    target.currentHP -= damage;
                    if (!(target.armour is null))
                    {
                        target.UseItem(target.armour, target);
                    }
                }
                if (target.currentHP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(target.name + " has been defeated!");
                }
            }
        }

        public override void Spell(Entity target)
        {
            if (curPassengers == 0)
            {
                Console.WriteLine("\n");
                Random random = new Random();
                int damage = (stats.intelligence + random.Next(stats.intelligence)) - target.stats.intelligence;
                int dodgeChance = target.stats.speed - this.stats.speed;
                currentMana -= stats.intelligence;
                if (damage <= 0)
                {
                    Console.WriteLine(target.name + " resisted " + name + "'s spell!");
                    if (!(target.armour is null))
                    {
                        target.UseItem(target.armour, target);
                    }
                }
                else if (random.Next(40) <= dodgeChance)
                {
                    Console.WriteLine(target.name + " dodged " + name + "'s spell!");
                }
                else
                {
                    Console.WriteLine(name + " attacked " + target.name + " with a spell for " + damage + " damage!");
                    target.currentHP -= damage;
                    if (!(target.armour is null))
                    {
                        target.UseItem(target.armour, target);
                    }
                }
                if (target.currentHP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(target.name + " has been defeated!");
                    maxHP += damage;
                }
            }
        }

        public override void DoTurn(List<Entity> allies, List<Enemy> enemies)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Attack(ChooseTarget(enemies.Cast<Entity>().ToList()));
            //players.Cast<Entity>().ToList();
        }

        public override void gainXP(int xp)
        {
            currentHP = maxHP;
        }
    }
}
