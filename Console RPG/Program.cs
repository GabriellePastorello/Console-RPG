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
            Player.player.changeName(input);

            List<Entity> allies = new List<Entity> { Player.player, Mount.horse, Player.adventurer, Player.warrior };


            
            Location.startingTown.SetNearbyLocations(east: Location.forestPath, west: Location.banditPass);
            Location.forestPath.SetNearbyLocations(north: Location.northernForestPath);
            Location.northernForestPath.SetNearbyLocations(north: Location.cultistCamp, west: Location.QilinsLake);
            Location.cultistCamp.SetNearbyLocations(north: Location.mountainFoot);
            Location.banditPass.SetNearbyLocations(north: Location.banditCamp);
            Location.smallTown.SetNearbyLocations(east: Location.mountainFoot, south: Location.banditCamp);
            Location.mountainFoot.SetNearbyLocations(north: Location.mountainSide, east: Location.cliffs, west: Location.smallTown);
            Location.mountainSide.SetNearbyLocations(north: Location.EbonysCrevass);
            Location.cliffs.SetNearbyLocations(east: Location.cave, north: Location.mountainPeak);
            Location.mountainPeak.SetNearbyLocations(west: Location.EbonysCrevass, south: Location.cliffs);

            Console.WriteLine("\nYour quest is to defeat the dragons of Cinder Mountain. For years they have been a threat to the people, stealing livestock and plundering villages. Now, with the rise of dragon worshippers, the people have been calling to defeat the dragons once and for all. Many nations have sent armies to defeat them, but none have succeeded. So you decide to go up the mountain yourself, hoping to take down their leader, Ebony. You start your adventure in your hometown, where you grew up under the constant threat of dragon attacks. You have planned a route to sneak onto the mountain, and today is the day you set of on your journey.");
            Player.player.getParty(allies);
            Player.player.mountHorse(Mount.horse);
            Location.startingTown.Resolve(allies);

            
        }
    }





}
