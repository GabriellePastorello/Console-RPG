using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            // stats = speed, defence, strength, intelligence
            //entity = name, race, health, mana, stats
            Console.WriteLine("What is your name?");
            Console.ForegroundColor = ConsoleColor.White;
            String input = Console.ReadLine();
            Player.player.changeName(input);
            Console.ForegroundColor = ConsoleColor.Gray;

            

            
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

            //Console.WriteLine("\nYour quest is to defeat the dragons of Cinder Mountain. For years they have been a threat to the people, stealing livestock and plundering villages. Now, with the rise of dragon worshippers, the people have been calling to defeat the dragons once and for all. Many nations have sent armies to defeat them, but none have succeeded. So you decide to go up the mountain yourself, hoping to take down their leader, Ebony. You start your adventure in your hometown, where you grew up under the constant threat of dragon attacks. You have planned a route to sneak onto the mountain, and today is the day you set of on your journey.");
            //Thread.Sleep(5000);
            //Console.WriteLine("\nVillager: Hey " + Player.player.name + ", I see you have a horse. Where are you going?");
            //Thread.Sleep(2000);
            //Console.WriteLine("\nVillager: Cinder Mountain you say? Surely you're not going alone!");
            //Thread.Sleep(2000);
            //Console.WriteLine("\nVillager: You should hire a sellsword at least. There's all sorts of dangers out there. Why don't you go to the shop, make sure you're prepared.");
            //Thread.Sleep(2000);
            //Console.WriteLine("\nVillager: Oh, and I suggest you go west, so you don't run into any dragon cultists.");
            //Thread.Sleep(2000);
            Location.startingTown.Resolve(Entity.allies);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nCongrats! You have defeated Ebony, the leader of the dragons of Cinder Mountain! You return back home a hero!");

            
        }
    }





}
