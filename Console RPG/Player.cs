using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Player : Entity
    {
        public int xp, level;
        public bool isMounted;

        public Player (string name, string race, int hp, int mana, Stats stats) : base(name, race, hp, mana, stats)
        {
            xp = 0;
            level = 1;
            isMounted = false;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target)
        {
            //finish this
            Random random = new Random();
            int damage = (stats.strength + random.Next(stats.strength)) - target.stats.defence;
            int dodgeChance = target.stats.speed;
            if (damage <= 0)
            {
                Console.WriteLine(target.name + " blocked the attack!");
            }
            else if (random.Next(40) <= dodgeChance)
            {
                Console.WriteLine(target.name + " dodged the attack!");
            }
            else
            {
                Console.WriteLine(name + " attacked " + target.name + " for " + damage + " damage!");
                target.currentHP -= damage;
            }
        }

        public void LevelUp()
        {
            if (xp >= level*10)
            {
                xp -= level * 10;
                level++;
                Console.WriteLine("You leveled up to level " + level + "! Choose a stat to level up.\nHP | Mana | Speed | Strength | Defence | Intelligence");
                String point = Console.ReadLine();
                if (point == "HP")
                {
                    maxHP += 10;
                    currentHP = maxHP;
                }
                else if (point == "Mana")
                {
                    maxMana += 10;
                    currentMana += maxMana;
                }
                else if (point == "Speed")
                {
                    stats.speed++;
                }
                else if (point == "Strength")
                {
                    stats.strength++;
                }
                else if (point == "Defence")
                {
                    stats.defence++;
                }
                else if (point == "Intelligence")
                {
                    stats.intelligence++;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    level--;
                    xp += level * 10;
                    LevelUp();
                }
            }
        }
    }
}
