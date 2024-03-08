using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location startingTown = new Location("Hometown", "A small town, where you prepare for the journey ahead.", new Shop("Shopkeeper Darrin", "The Store of Adventure", new List<Item>() { HealthPotionItem.healthPotion, HealthPotionItem.healthPotion2, HealthPotionItem.healthPotion3}, "Here, we have everything you need for any adventure!", Player.hiredBlade, Mount.horse2, new List<Weapon>() { Weapon.sword7, Weapon.sword8, Weapon.sword10}, new List<Armour>() { Armour.shop, Armour.shop2, Armour.shop3 }), ManageParty.management);
        public static Location banditPass = new Location("Bandit Pass", "A path used by bandits that connects to two towns.", new Battle(new List<Enemy>() { Enemy.bandit, Enemy.bandit2 }), ManageParty.management);
        public static Location banditCamp = new Location("Bandit Camp", "A camp of bandits nestled between two towns.", new Battle(new List<Enemy>() { Enemy.bandit3, Enemy.bandit4, Enemy.bandit5, Enemy.banditLeader }), ManageParty.management);
        public static Location smallTown = new Location("Small Town", "It's a town near the mountain's foot. There's valuable goods to buy here.", new Shop("Shopkeeper Lucky", "The Dragon Hoard", new List<Item>() { HealthPotionItem.healthPotion, HealthPotionItem.healthPotion2, HealthPotionItem.healthPotion3, ManaPotionItem.manaPotion, ManaPotionItem.manaPotion2, ManaPotionItem.manaPotion3 }, "With our equipment, you can survive anything!", Player.hiredBlade2, Mount.horse3, new List<Weapon>() { Weapon.ritualSword2, Weapon.sword9, Weapon.spear}, new List<Armour>() { Armour.shop4, Armour.shop5, Armour.shop6 }), ManageParty.management);
        public static Location forestPath = new Location("Forest Path", "A path that leads to Cinder Mountain. It's an abandoned road that few dare to tread.", new Battle(new List<Enemy>() { Enemy.bear }), ManageParty.management);
        public static Location northernForestPath = new Location("Northern Forest Path", "A road that is most often used by those who worship the dragons.", new Battle(new List<Enemy>() { Enemy.Cultist, Enemy.Cultist2 }), NPC.adventurerEncounter, ManageParty.management);
        public static Location cultistCamp = new Location("Cultist Camp", "The dragon cultists settled here, gaurding the mountains from 'trespassers'.", new Battle(new List<Enemy>() { Enemy.Cultist3, Enemy.Cultist4, Enemy.Cultist5, Enemy.CultistLeader }), ManageParty.management);
        public static Location mountainFoot = new Location("Mountain's Foot", "The foot of Cinder Mountain.", NPC.warriorEncounter, ManageParty.management);
        public static Location mountainSide = new Location("Mountainside", "The side of Cinder Mountain, where few trees grow and dragons patrol from above.", new Battle(new List<Enemy>() { Enemy.dragonScout, Enemy.dragonScout2 }), ManageParty.management);
        public static Location cliffs = new Location("Cliffs", "The cliffs of Cinder Mountain, few dragons bother here but the path is dangerous to travel.", ManageParty.management);
        public static Location QilinsLake = new Location("Quilin's Lake", "A lake where it is fabled that the mythical Quilin lives. It is said to be a creature of wealth.", new Battle(new List<Enemy>() { Enemy.Cultist6, Enemy.Cultist7, Enemy.Drake }), NPC.QilinEncounter, ManageParty.management);
        public static Location cave = new Location("Cave", "A cave in the face of the mountain. Probably a good place to rest.", new Battle(new List<Enemy>() { Enemy.dragonScout3 }), ManageParty.management);
        public static Location mountainPeak = new Location("Mountain Peak", "The top of Cinder Mountain. You can see the forest stretch out below you.", ManageParty.management);
        public static Location EbonysCrevass = new Location("Ebony's Crevass", "A large crevass in the side of Cinder Mountain, the battlefield were many armies have fallen in an attempt to defeat the dragons.", new Battle(new List<Enemy>() { Enemy.Ebony }), ManageParty.management);


        public String name;
        public String description;
        public Feature interaction;
        public Feature secondInteraction;
        public Feature finalInteraction;

        public Location north, east, south, west;

        public Location(string name, string description, Feature interaction = null, Feature secondInteraction = null, Feature finalInteraction = null)
        {
            this.name = name;
            this.description = description;
            this.interaction = interaction;
            this.secondInteraction = secondInteraction;
            this.finalInteraction = finalInteraction;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            if (!(north is null))
            {
                north.south = this;
                this.north = north;
            }
            if (!(east is null))
            {
                east.west = this;
                this.east = east;
            }
            if (!(west is null))
            {
                west.east = this;
                this.west = west;
            }
            if (!(south is null))
            {
                south.north = this;
                this.south = south;
            }
        }

        public void Resolve(List<Entity> allies)
        {
            if (!(interaction is null))
            {
                if (interaction.isResolved == false)
                {
                    interaction.Resolve(allies);
                }
            }
            if (!(secondInteraction is null))
            {
                if (secondInteraction.isResolved == false)
                {
                    secondInteraction.Resolve(allies);
                }
            }
            if (!(finalInteraction is null))
            {
                if (finalInteraction.isResolved == false)
                {
                    finalInteraction.Resolve(allies);
                }
            }
            if (allies.TrueForAll(Entity => Entity.currentHP <= 0))
            {
                return;
            }
            Console.WriteLine("\nYou find yourself in " + name + ".");
            Console.WriteLine(description);
            if (!(north is null))
            {
                Console.WriteLine("To your north is " + north.name);
            }
            if (!(east is null))
            {
                Console.WriteLine("To your east is " + east.name);
            }
            if (!(south is null))
            {
                Console.WriteLine("To your south is " + south.name);
            }
            if (!(west is null))
            {
                Console.WriteLine("To your west is " + west.name);
            }
            Console.ForegroundColor = ConsoleColor.White;
            String direction = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Location nextLocation = null;

            if (direction == "north" && !(north is null))
            {
                nextLocation = north;
            }
            else if (direction == "east" && !(east is null))
            {
                nextLocation = east;
            }
            else if (direction == "south" && !(south is null))
            {
                nextLocation = south;
            }
            else if (direction == "west" && !(west is null))
            {
                nextLocation = west;
            }
            else
            {
                Console.WriteLine("That is not a valid direction. Try north, east, south or west.");
                this.Resolve(allies);
            }
            if (Enemy.Ebony.currentHP > 0)
            {
                nextLocation.Resolve(allies);
            }
        }


    }
}
