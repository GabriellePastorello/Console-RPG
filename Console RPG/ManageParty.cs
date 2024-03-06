using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class ManageParty : Feature
    {
        public ManageParty(bool isResolved) : base(isResolved)
        {
        }

        public override void Resolve(List<Entity> allies)
        {
            while (true)
            {
                Console.WriteLine("\nWhat would you like to do?\nView Party\nView Inventory\nMount\nDismount\nFire\nDone");
                string input = Console.ReadLine();
                Entity viewing = null;
                if (input == "View Party")
                {

                }
                else if (input == "View Inventory")
                {

                }
                else if (input == "Mount")
                {

                }
                else if (input == "Dismount")
                {
                    Console.WriteLine("\nYou");
                }
                else if (input == "Fire")
                {
                    Console.WriteLine("\nYou have chosen to fire someone.");
                    viewing = ChoosePartyMember(allies);
                    Entity.allies.Remove(viewing);

                }
                else if (input == "Done")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
        }

        public Entity ChoosePartyMember(List<Entity> party)
        {
            String theTarget;
            Console.WriteLine("\nWho?");
            foreach (Entity i in party)
            {
                Console.WriteLine(i.name);
            }
            theTarget = Console.ReadLine();
            foreach (Entity i in party)
            {
                if (i.name == theTarget)
                {
                    return i;
                }
            }
            Console.WriteLine("\nInvalid input. Try again.");
            return ChoosePartyMember(party);
        }
    }
}
