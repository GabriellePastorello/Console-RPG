using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy Ebony = new Enemy("Ebony", "Dragon", 10000, 10000, 10, new Stats(12, 12, 20, 18), 1000, 10000, 1, weapon: Weapon.blackSword);
        public static Enemy dragonScout = new Enemy("Brown Dragon", "Dragon", 500, 500, 10, new Stats(12, 9, 18, 17), 100, 1000, 2);
        public static Enemy dragonScout2 = new Enemy("Green Dragon", "Dragon", 500, 500, 10, new Stats(12, 9, 18, 17), 100, 1000, 2);
        public static Enemy dragonScout3 = new Enemy("Dragon Scout", "Dragon", 500, 500, 10, new Stats(12, 9, 18, 17), 100, 1000, 2);
        public static Enemy Cultist = new Enemy("Dragon Cultist", "Human", 80, 120, 10, new Stats(5, 4, 4, 6), 50, 100, 5, weapon: Weapon.cultistSword, armour: Armour.cultist);
        public static Enemy Cultist2 = new Enemy("Devout Dragon Cultist", "Human", 80, 120, 10, new Stats(5, 4, 4, 6), 50, 100, 5, weapon: Weapon.cultistSword2, armour: Armour.cultist2);
        public static Enemy Cultist3 = new Enemy("Dragon Cultist", "Human", 80, 120, 10, new Stats(5, 4, 4, 6), 50, 100, 5, weapon: Weapon.cultistSword3, armour: Armour.cultist3);
        public static Enemy Cultist4 = new Enemy("Elite Dragon Cultist", "Human", 80, 120, 10, new Stats(5, 4, 4, 6), 50, 100, 5, weapon: Weapon.cultistSword4, armour: Armour.cultist4);
        public static Enemy Cultist5 = new Enemy("Tall Dragon Cultist", "Human", 80, 120, 10, new Stats(5, 4, 4, 6), 50, 100, 5, weapon: Weapon.cultistSword5, armour: Armour.cultist5);
        public static Enemy CultistLeader = new Enemy("Dragon Cultist Leader", "Human", 90, 130, 10, new Stats(6, 5, 5, 7), 60, 200, 6, weapon: Weapon.ritualSword, armour: Armour.cultist6);
        public static Enemy Cultist6 = new Enemy("Dragon Cultist", "Human", 80, 120, 10, new Stats(5, 4, 4, 6), 50, 100, 5, weapon: Weapon.cultistSword6, armour: Armour.cultist7);
        public static Enemy Cultist7 = new Enemy("Scout Dragon Cultist", "Human", 80, 120, 10, new Stats(5, 4, 4, 6), 50, 100, 5, weapon: Weapon.cultistSword7, armour: Armour.cultist8);
        public static Enemy Drake = new Enemy("Cult Drake", "Drake", 100, 150, 10, new Stats(10, 2, 10, 6), 100, 40, 5);
        public static Enemy bandit = new Enemy("Bandit", "Human", 40, 10, 10, new Stats(6, 3, 8, 5), 25, 200, 3, weapon: Weapon.dagger, armour: Armour.bandit);
        public static Enemy bandit2 = new Enemy("Scout Bandit", "Human", 40, 10, 10, new Stats(6, 3, 8, 5), 25, 200, 3, weapon: Weapon.dagger2, armour: Armour.bandit2);
        public static Enemy bandit3 = new Enemy("Bandit", "Human", 40, 10, 10, new Stats(6, 3, 8, 5), 25, 200, 3, weapon: Weapon.dagger3, armour: Armour.bandit3);
        public static Enemy bandit4 = new Enemy("Tiny Bandit", "Human", 40, 10, 10, new Stats(6, 3, 8, 5), 25, 200, 3, weapon: Weapon.dagger4, armour: Armour.bandit4);
        public static Enemy bandit5 = new Enemy("Elite Bandit","Human", 40, 10, 10, new Stats(6, 3, 8, 5), 25, 200, 3, weapon: Weapon.dagger5, armour: Armour.bandit5);
        public static Enemy banditLeader = new Enemy("Bandit Leader", "Human", 50, 15, 10, new Stats(7, 4, 9, 6), 30, 500, 4, weapon: Weapon.sword6, armour: Armour.bandit6);
        public static Enemy bear = new Enemy("Bear", "Bear", 80, 1, 10, new Stats(3, 2, 7, 1), 40, 10, 1);

        public int expSpoils;
        public int goldSpoils;
        public int chaos;

        public Enemy(string name, string race, int hp, int mana, float carryWeight, Stats stats, int spoils, int goldSpoils, int chaos, Armour armour = null, Weapon weapon = null) : base(name, race, hp, mana, carryWeight, stats)
        {
            expSpoils = spoils;
            this.goldSpoils = goldSpoils;
            this.chaos = chaos;
            this.armour = armour;
            this.weapon = weapon;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            Entity target = targets[random.Next(targets.Count)];
            if (target.currentHP > 0)
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
            Console.WriteLine("\n");
            Random random = new Random();
            int damage = (stats.strength + random.Next(stats.strength)) - (target.stats.defence);
            int dodgeChance = target.stats.speed - this.stats.speed;
            if (random.Next(20) <= chaos)
            {
                damage *= 2;
                dodgeChance /= 2;
            }
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
                if (target.currentHP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta; 
                    Console.WriteLine(target.name + " has been defeated!");
                }
            }
        }

        public override void Spell(Entity target)
        {
            Console.WriteLine("\n");
            Random random = new Random();
            int damage = (stats.intelligence + random.Next(stats.intelligence)) - target.stats.intelligence;
            int dodgeChance = target.stats.speed - this.stats.speed;
            currentMana -= stats.intelligence;
            if (random.Next(20) <= chaos)
            {
                damage *= 2;
                dodgeChance /= 2;
            }
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
                target.maxHP -= damage;
                if (target.currentHP > target.maxHP)
                {
                    target.currentHP = target.maxHP;
                }
                if (!(target.armour is null))
                {
                    target.UseItem(target.armour, target);
                }
                if (target.currentHP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(target.name + " has been defeated!");
                    maxHP += damage;
                }
            }
        }

        public override void DoTurn(List<Entity> allies, List<Enemy> enemies)
        {
            Random random = new Random();
            int choice = random.Next(5);
            if (choice == 0)
            {
                if (name == "Ebony")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEbony does a sweep attack...");
                    foreach (Entity target in allies)
                    {
                        Attack(target);
                    }
                }
                else
                {
                    Attack(ChooseTarget(allies));
                }
            }
            else if (choice == 1)
            {
                if (currentMana >= stats.intelligence)
                {
                    Spell(ChooseTarget(allies));
                }
                else
                {
                    Console.WriteLine("\n" + name + " recovered 10 mana");
                    currentMana += 10;
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("\n" + name + " recovered " + chaos + " HP");
                currentHP += stats.intelligence;
                if (currentHP > maxHP)
                {
                    maxHP += 1;
                    currentHP = maxHP;
                }
            }
            else if (choice == 3 && race == "dragon")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + name + " breathes fire.");
                foreach (Entity target in allies)
                {
                    Spell(target);
                }
            }
            else
            {
                if (stats.strength > stats.intelligence)
                {
                    Attack(ChooseTarget(allies));
                }
                else
                {
                    if (currentMana >= stats.intelligence)
                    {
                        Spell(ChooseTarget(allies));
                    }
                    else
                    {
                        Console.WriteLine("\n" +name + " recovered 10 mana");
                        currentMana += 10;
                    }
                }
            }
            //players.Cast<Entity>().ToList();
            choice = random.Next(25);
            if (choice <= chaos)
            {
                Thread.Sleep(2000);
                Console.WriteLine("\n" + name + " took another turn...");
                Thread.Sleep(2000);
                DoTurn(allies, enemies);
            }
        }

        public override void gainXP(int xp)
        {
            
        }
    }
}
