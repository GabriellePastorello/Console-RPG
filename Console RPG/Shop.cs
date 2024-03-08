using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    internal class Shop : Feature
    {
        public string ownerName;
        public string shopName;
        public List<Item> items;
        public string slogan;
        public Player sellsword;
        public Mount horse;
        public List<Weapon> weapons;
        public List<Armour> armours;

        public Shop(string ownername, string shopName, List<Item> items, string slogan, Player sellsword, Mount horse, List<Weapon> weapons, List<Armour> armours) : base(false)
        {
            this.ownerName = ownername;
            this.shopName = shopName;
            this.items = items;
            this.slogan = slogan;
            this.sellsword = sellsword;
            this.horse = horse;
            this.weapons = weapons;
            this.armours = armours;
        }

        public override void Resolve(List<Entity> allies)
        {
            Random random = new Random();
            int rotation = random.Next(weapons.Count);
            Console.WriteLine("\n" + ownerName + ": Hello, welcome to " + shopName + "! " + slogan);

            while (true)
            {
                Console.WriteLine("\nWhat would you like to do? Gold: " + Player.gold + "\nShop\nTrade\nHire\nStable\nRepair\nTalk\nLeave");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                if (input == "Shop")
                {
                    Item item = ChooseItem(items);
                    if (item.price <= Player.gold)
                    {
                        Entity buyer = ChooseBuyer(allies);
                        if (buyer.carryWeight >= item.weight)
                        {
                            Player.gold -= item.price;
                            buyer.inventory.Add(item);
                            buyer.carryWeight -= item.weight;
                            Console.WriteLine(buyer.name + " bought " + item.name);
                        }
                        else
                        {
                            Console.WriteLine("\n" + buyer.name + " doesn't have enough space for that.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("\n" + ownerName + ": Don't got enough money for that.");
                    }
                }
                else if (input == "Trade")
                {
                    Entity buyer = ChooseBuyer(allies);
                    if (buyer is Mount)
                    {
                        Console.WriteLine("\n" + ownerName + ": I don't trade with horses.");
                    }
                    else
                    {
                        Console.WriteLine("\n" + ownerName + ": What would you like to trade?");
                        int tradePrice = weapons[rotation].price - buyer.weapon.price;
                        tradePrice += 1;
                        int otherTradePrice = armours[rotation].price - buyer.armour.price;
                        otherTradePrice += 1;
                        Console.WriteLine(weapons[rotation].name + ": $" + tradePrice);
                        Console.WriteLine(armours[rotation].name + ": $" + otherTradePrice);
                        Console.ForegroundColor = ConsoleColor.White;
                        input = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (input == weapons[rotation].name)
                        {
                            if (Player.gold >= tradePrice && buyer.carryWeight >= (weapons[rotation].weight - buyer.weapon.weight))
                            {
                                Player.gold -= tradePrice;
                                buyer.weapon.equip(buyer);
                                weapons[rotation].equip(buyer);
                                weapons.Add(buyer.weapon);
                                buyer.weapon = weapons[rotation];
                                weapons.Remove(buyer.weapon);
                                Console.WriteLine("\nWeapons traded!");
                                rotation = weapons.Count - 1;
                            }
                            else if (Player.gold >= tradePrice)
                            {
                                Console.WriteLine("\n" + ownerName + ": You don't have enough money for that.");
                            }
                            else if (buyer.carryWeight >= (weapons[rotation].weight - buyer.weapon.weight))
                            {
                                Console.WriteLine("\nThe weapon is too heavy to equip.");
                            }
                            else
                            {
                                Console.WriteLine("\n" + ownerName + ": I don't know what you're looking for, but we don't have that here.");
                            }
                        }
                        else if (input == armours[rotation].name)
                        {
                            if (Player.gold >= otherTradePrice && buyer.carryWeight >= (armours[rotation].weight - buyer.armour.weight))
                            {
                                Player.gold -= otherTradePrice;
                                buyer.armour.equip(buyer);
                                armours[rotation].equip(buyer);
                                armours.Add(buyer.armour);
                                buyer.armour = armours[rotation];
                                armours.Remove(buyer.armour);
                                Console.WriteLine("\nArmour traded!");
                            }
                            else if (Player.gold >= otherTradePrice)
                            {
                                Console.WriteLine("\n" + ownerName + ": You don't have enough money for that.");
                            }
                            else if (buyer.carryWeight >= (armours[rotation].weight - buyer.armour.weight))
                            {
                                Console.WriteLine("\nThe armour is too heavy to equip.");
                            }
                            else
                            {
                                Console.WriteLine("\n" + ownerName + ": I don't know what you're looking for, but we don't have that here.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n" + ownerName + ": We don't have that.");
                        }
                    }
                }
                else if (input == "Hire")
                {
                    if (!(sellsword == null))
                    {
                        Console.WriteLine("\n" + ownerName + ": We got someone you can hire for $250.");
                        Console.WriteLine("Hire " + sellsword.name + "?\nYes\nNo");
                        Console.ForegroundColor = ConsoleColor.White;
                        input = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (input == "Yes")
                        {
                            if (Player.gold >= 250)
                            {
                                Player.gold -= 250;
                                Entity.allies.Add(sellsword);
                                Console.WriteLine(sellsword.name + " has been added to your party!");
                                sellsword = null;
                            }
                            else
                            {
                                Console.WriteLine("\n" + ownerName + ": Come back when you get enough money.");
                            }
                        }
                        else if (input == "No")
                        {
                            Console.WriteLine("\n" + ownerName + ": Alright then. Anything else?");
                        }
                        else
                        {
                            Console.WriteLine("\n" + ownerName + ": I'll just take that as a no.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n" + ownerName + ": There's no one here to hire.");
                    }
                }
                else if (input == "Stable")
                {
                    if (!(horse == null))
                    {
                        Console.WriteLine("\n" + ownerName + ": We got a horse here for $500.");
                        Console.WriteLine("Buy " + horse.name + "?\nYes\nNo");
                        Console.ForegroundColor = ConsoleColor.White;
                        input = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (input == "Yes")
                        {
                            if (Player.gold >= 500)
                            {
                                Player.gold -= 500;
                                Entity.allies.Add(horse);
                                Console.WriteLine(horse.name + " has been added to your party!");
                                horse = null;
                            }
                            else
                            {
                                Console.WriteLine("\n" + ownerName + ": Come back when you get enough money.");
                            }
                        }
                        else if (input == "No")
                        {
                            Console.WriteLine("\n" + ownerName + ": Alright then. Anything else?");
                        }
                        else
                        {
                            Console.WriteLine("\n" + ownerName + ": I'll just take that as a no.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n" + ownerName + ": There's no horses in the stables right now.");
                    }
                }
                else if (input == "Repair")
                {
                    Entity buyer = ChooseBuyer(allies);
                    if (buyer is Mount)
                    {
                        Console.WriteLine("\n" + ownerName + ": Uh, I don't repair weapons and armour for a horse.");
                    }
                    else
                    {
                        Console.WriteLine("\n" + ownerName + ": What would you like to repair?\nArmour: $" + buyer.armour.price + "\nWeapon: $" + buyer.weapon.price);
                        Console.ForegroundColor = ConsoleColor.White;
                        input = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (input == "Armour")
                        {
                            if (buyer.armour.price <= Player.gold)
                            {
                                buyer.armour.repair(buyer);
                                Player.gold -= buyer.armour.price;
                                Console.WriteLine("\nArmour repaired!");
                            }
                            else
                            {
                                Console.WriteLine("\n" + ownerName + ": You don't have enough money for that.");
                            }
                        }
                        else if (input == "Weapon")
                        {
                            if (buyer.weapon.price <= Player.gold)
                            {
                                buyer.weapon.repair(buyer);
                                Player.gold -= buyer.weapon.price;
                                Console.WriteLine("\nWeapon repaired!");
                            }
                            else
                            {
                                Console.WriteLine("\n" + ownerName + ": You don't have enough money for that.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n" + ownerName + ": I don't know what that means.");
                        }
                    }
                }
                else if (input == "Talk")
                {
                    List<String> dialogue = new List<string> { ": I heard there's a lot of chaos out there. Watch out for anyone who can warp time.", ": I suggest you stay away from spellcasters, they drain your vitality.", ": Keep your party small, less of a chance you'll be spotted by enemies.", ": I don't really feel like talking right now.", ": Try not to overuse those potions.", ": Hi", ": If you want to trade, come back later to see if I've got something new in stock.", ": Sometimes, it's better to take a step back.", ": Fighting on horseback is always easier." };
                    Console.WriteLine("\n" + ownerName + dialogue[random.Next(8)]);
                }
                else if (input == "Leave")
                {
                    break;
                }
                else if (input == "Sell")
                {
                    Console.WriteLine("\n" + ownerName + ": Hey, I don't want your random stuff. Why don't you try selling that to someone else?");
                }
                else
                {
                    Console.WriteLine("\n" + ownerName + ": So... you gonna buy something or what?");
                }
            }
            Console.WriteLine("\n" + ownerName + ": Have a good day! And good luck on your adventure!");

        }

        public Item ChooseItem(List<Item> items)
        {
            String theTarget;
            Console.WriteLine("\n" + ownerName + ": Take a look at our stock.");
            foreach (Item i in items)
            {
                Console.WriteLine(i.name + ": $" + i.price);
            }
            Console.ForegroundColor = ConsoleColor.White;
            theTarget = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (Item i in items)
            {
                if (i.name == theTarget)
                {
                    return i;
                }
            }
            Console.WriteLine("\n" + ownerName + ": Sorry, don't know what you're lookin' for.");
            return ChooseItem(items);
        }

        public Entity ChooseBuyer(List<Entity> party)
        {
            String theTarget;
            Console.WriteLine("\nWho's buying?");
            foreach (Entity i in party)
            {
                if (i is Player)
                {
                    Console.WriteLine(i.name);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            theTarget = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (Entity i in party)
            {
                if (i.name == theTarget)
                {
                    return i;
                }
            }
            Console.WriteLine("\nInvalid input. Try again.");
            return ChooseBuyer(party);
        }
    }
}
