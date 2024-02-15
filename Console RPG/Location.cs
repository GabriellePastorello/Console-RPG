using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public String name;
        public String description;

        public Location north, east, south, west;

        public Location(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;

            if (!(north is null))
            {
                north.south = this;
            }
            if (!(east is null))
            {
                east.west = this;
            }
            if (!(west is null))
            {
                west.east = this;
            }
            if (!(south is null))
            {
                south.north = this;
            }
        }

        public void Resolve()
        {
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

            String direction = Console.ReadLine();
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
                this.Resolve();
            }

            nextLocation.Resolve();
        }


    }
}
