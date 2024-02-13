using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            // stats = speed, defence, strength, intelligence
            //entity = name, race, health, mana, stats
            Console.WriteLine("What is your name?");
            String input = Console.ReadLine();
            Enemy Ebony = new Enemy("Ebony", "Dragon", 10000, 10000, new Stats(15, 19, 20, 18), 100000, 1);
            Enemy Cultist = new Enemy("Dragon Cultist", "Human", 80, 120, new Stats(5, 4, 4, 6), 50, 5);
            Enemy dragonScout = new Enemy("Dragon Scout", "Dragon", 500, 500, new Stats(18, 12, 18, 17), 1000, 2);
            Enemy bandit = new Enemy("Bandit", "Human", 40, 10, new Stats(6, 3, 8, 5), 25, 3);

            Player player = new Player(input, "Human", 80, 100, new Stats(5, 5, 5, 5));
            Mount horse = new Mount("Horse", "Horse", 150, 30, new Stats(10, 7, 7, 2), 2);

            List<Entity> enemies = new List<Entity> { null};
            List<Entity> allies = new List<Entity> { player, horse };

            Weapon sword = new Weapon(10, 15.0f, "sword", "a normal sword", 10, 80);

            player.UseItem(sword, bandit);

            
        }
    }





}
