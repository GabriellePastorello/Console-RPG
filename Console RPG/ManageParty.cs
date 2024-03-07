using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class ManageParty : Feature
    {

        public static ManageParty management = new ManageParty(false);
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
                    Console.WriteLine("\nYou decide to view the party's status.");
                    ChoosePartyMember(allies).viewStats();
                }
                else if (input == "View Inventory")
                {
                    Console.WriteLine("\nYou decide to check inventory.");
                    ChoosePartyMember(allies).showInventory();
                }
                else if (input == "Mount")
                {
                    Console.WriteLine("\nYou decide to mount someone.");
                    viewing = ChoosePartyMember(allies);
                    Player placeholder = viewing as Player;
                    if (!placeholder.isMounted)
                    {
                        placeholder.mountHorse(ChooseHorse(allies) as Mount);
                    }
                    else
                    {
                        Console.WriteLine("\n" + placeholder.name + " is already mounted.");
                    }
                }
                else if (input == "Dismount")
                {
                    Console.WriteLine("\nYou decide to dismount someone.");
                    viewing = ChoosePartyMember(allies);
                    Player placeholder = viewing as Player;
                    if (placeholder.isMounted)
                    {
                        placeholder.dismountHorse();
                    }
                    else
                    {
                        Console.WriteLine("\n" + placeholder.name + " is not mounted.");
                    }
                }
                else if (input == "Fire")
                {
                    Console.WriteLine("\nYou have chosen to fire someone.");
                    viewing = ChoosePartyMember(allies);
                    Entity.allies.Remove(viewing);

                }
                else if (input == "Done")
                {
                    Console.WriteLine("\nYou decide to move on.");
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
                if (i is Player)
                {
                    Console.WriteLine(i.name);
                }
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

        public Entity ChooseHorse(List<Entity> party)
        {
            String theTarget;
            Console.WriteLine("\nWho?");
            foreach (Entity i in party)
            {
                if (i is Mount)
                {
                    Console.WriteLine(i.name);
                }
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
            return ChooseHorse(party);
        }
    }
}
