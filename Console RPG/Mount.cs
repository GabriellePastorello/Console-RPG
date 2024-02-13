using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Mount : Entity
    {
        public int curPassengers, maxPassengers;
        public int braveness;

        public Mount(string name, string race, int hp, int mana, Stats stats, int passengers, int braveness) : base(name, race, hp, mana, stats)
        {
            curPassengers = 0;
            maxPassengers = passengers;
            this.braveness = braveness;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }
        public override void Attack(Entity target)
        {
            //finish
            if (curPassengers == 0)
            {
                Console.WriteLine("Horse attacked an enemy");
            }
        }
    }
}
