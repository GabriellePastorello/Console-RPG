using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public int expSpoils;
        public int chaos;

        public Enemy(string name, string race, int hp, int mana, Stats stats, int spoils, int chaos) : base(name, race, hp, mana, stats)
        {
            expSpoils = spoils;
            this.chaos = chaos;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target)
        {
            //finish
            Console.WriteLine("Enemy attacked target");
        }
    }
}
