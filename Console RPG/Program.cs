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
            Enemy Ebony = new Enemy("Ebony", "Dragon", 10000, 10000, 10, new Stats(15, 19, 20, 18), 100000, 1000000, 1);
            Enemy Cultist = new Enemy("Dragon Cultist", "Human", 80, 120, 10, new Stats(5, 4, 4, 6), 50, 100, 5);
            Enemy dragonScout = new Enemy("Dragon Scout", "Dragon", 500, 500, 10, new Stats(18, 12, 18, 17), 1000, 10000, 2);
            Enemy bandit = new Enemy("Bandit", "Human", 40, 10, 10, new Stats(6, 3, 8, 5), 25, 200, 3);

            Player player = new Player(input, "Human", 80, 100, 100, new Stats(5, 5, 5, 5));
            Mount horse = new Mount("Horse", "Horse", 150, 30, 500, new Stats(10, 7, 7, 2), 2);

            List<Entity> enemies = new List<Entity> { null};
            List<Entity> allies = new List<Entity> { player, horse };

            Weapon sword = new Weapon(10, 15.0f, "sword", "a normal sword", 10, 80);

            Location startingTown = new Location("Hometown", "A small town, where you will start your journey.");
            Location banditPass = new Location("Bandit Pass", "A path used by bandits that connects to two towns.");
            Location banditCamp = new Location("Bandit Camp", "A camp of bandits nestled between two towns.");
            Location smallTown = new Location("Small Town", "It's a town near the mountain's foot. There's valuable goods to buy here.");
            Location forestPath = new Location("Forest Path", "A path that leads to Cinder Mountain. It's an abandoned road that few dare to tread.");
            Location northernForestPath = new Location("Northern Forest Path", "A road that is most often used by those who worship the dragons.");
            Location cultistCamp = new Location("Cultist Camp", "The dragon cultists settled here, gaurding the mountains from 'trespassers'.");
            Location mountainFoot = new Location("Mountain's Foot", "The foot of Cinder Mountain.");
            Location mountainSide = new Location("Mountainside", "The side of Cinder Mountain, where few trees grow and dragons patrol from above.");
            Location cliffs = new Location("Cliffs", "The cliffs of Cinder Mountain, few dragons bother here but the path is dangerous to travel.");                               
            Location QilinsLake = new Location("Quilin's Lake", "A lake where it is fabled that the mythical Quilin lives.");
            Location cave = new Location("Cave", "A cave in the face of the mountain. Probably a good place to rest.");
            Location mountainPeak = new Location("Mountain Peak", "The top of Cinder Mountain. You can see the forest stretch out below you.");
            Location EbonysCrevass = new Location("Ebony's Crevass", "A large crevass in the side of Cinder Mountain, the battlefield were many armies have fallen in an attempt to defeat the dragons.");

            startingTown.SetNearbyLocations(east: forestPath, west: banditPass);
            forestPath.SetNearbyLocations(north: northernForestPath);
            northernForestPath.SetNearbyLocations(north: cultistCamp, west: QilinsLake);
            cultistCamp.SetNearbyLocations(north: mountainFoot);
            banditPass.SetNearbyLocations(north: banditCamp);
            smallTown.SetNearbyLocations(east: mountainFoot, south: banditCamp);
            mountainFoot.SetNearbyLocations(north: mountainSide, east: cliffs, west: smallTown);
            mountainSide.SetNearbyLocations(north: EbonysCrevass);
            cliffs.SetNearbyLocations(east: cave, north: mountainPeak);
            mountainPeak.SetNearbyLocations(west: EbonysCrevass, south: cliffs);

            Console.WriteLine("\nYour quest is to defeat the dragons of Cinder Mountain. For years they have been a threat, the people are afraid of a dragon attack on the village. Especially now, with the rise of dragon worshippers. However, no one has succeeded, not even well-trained armies. So you decide to go up the mountain yourself, hoping to take down their leader, Ebony. You start your adventure in a small town.");
            player.getParty(allies);
            horse.addToInventory(sword);
            player.transferItem(allies, input, "Horse", "sword");
            player.showInventory();
            horse.showInventory();
            startingTown.Resolve();

            
        }
    }





}
