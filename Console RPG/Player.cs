using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Player : Entity
    {
        public int xp, level;
        public int gold;

        public Player (string name, string race, int hp, int mana, float carryWeight, Stats stats) : base(name, race, hp, mana, carryWeight, stats)
        {
            xp = 0;
            level = 1;
            gold = 150;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            String theTarget;
            Console.WriteLine("Choose a target");
            foreach (Entity i in targets)
            {
                Console.WriteLine(i.name);
            }
            theTarget = Console.ReadLine();
            foreach (Entity i in targets)
            {
                if (i.name == theTarget)
                {
                    return i;
                }
            }
            Console.WriteLine("Invalid Target. Try again.");
            return ChooseTarget(targets);
        }

        public override void Attack(Entity target)
        {
            Random random = new Random();
            int damage = (stats.strength + random.Next(stats.strength)) - target.stats.defence;
            int dodgeChance = target.stats.speed;
            if (damage <= 0)
            {
                Console.WriteLine(target.name + " blocked the attack!");
            }
            else if (random.Next(40) <= dodgeChance)
            {
                Console.WriteLine(target.name + " dodged " + name + "'s attack!");
            }
            else
            {
                Console.WriteLine(name + " attacked " + target.name + " for " + damage + " damage!");
                target.currentHP -= damage;
            }
        }

        public void LevelUp()
        {
            if (xp >= level*10)
            {
                xp -= level * 10;
                level++;
                Console.WriteLine("You leveled up to level " + level + "! Choose a stat to level up.\nHP | Mana | Speed | Strength | Defence | Intelligence");
                String point = Console.ReadLine();
                if (point == "HP")
                {
                    maxHP += 10;
                    currentHP = maxHP;
                }
                else if (point == "Mana")
                {
                    maxMana += 10;
                    currentMana += maxMana;
                }
                else if (point == "Speed")
                {
                    stats.speed++;
                }
                else if (point == "Strength")
                {
                    stats.strength++;
                }
                else if (point == "Defence")
                {
                    stats.defence++;
                }
                else if (point == "Intelligence")
                {
                    stats.intelligence++;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    level--;
                    xp += level * 10;
                    LevelUp();
                }
            }
        }


        public override void getStatus()
        {
            Console.WriteLine("\nName: " + this.name);
            Console.WriteLine("Race: " + this.race);
            Console.WriteLine("Level: " + this.level);
            Console.WriteLine("XP: " + this.xp + "/" + this.level*10);
            Console.WriteLine("Gold: " + this.gold);
            Console.WriteLine("Health: " + this.currentHP + "/" + this.maxHP);
            Console.WriteLine("Mana: " + this.currentMana + "/" + this.maxMana);
            Console.WriteLine("Remaining carry weight: " + this.carryWeight);
            Console.WriteLine("Speed: " + this.stats.speed + " Strength: " + this.stats.strength + " Defence: " + this.stats.defence + " Intelligence: " + this.stats.intelligence);
            if (isMounted)
            {
                Console.WriteLine("Mount: " + this.mount.name);
            }
            else
            {
                Console.WriteLine("Mount: none");
            }
        }

        public void mountHorse(Mount mount)
        {
            if (isMounted)
            {
                Console.WriteLine(name + " is already mounted.");
            }
            else if (mount.curPassengers == mount.maxPassengers)
            {
                Console.WriteLine(mount.name + " can't carry any more passengers.");
            }
            else
            {
                isMounted = true;
                this.mount = mount;
                mount.curPassengers += 1;
                this.stats.defence *= 2;
                this.stats.strength *= 2;
                Console.WriteLine(this.name + " has mounted " + mount.name);
            }
            
        }

        public void dismountHorse()
        {
            if (!(this.mount is null))
            {
                this.mount.curPassengers -= 1;
                this.stats.defence /= 2;
                this.stats.strength /= 2;
                this.mount = null;
                isMounted = false;
                Console.WriteLine(this.name + " has dismounted.");
            }
            else
            {
                Console.WriteLine(name + " is not currently mounted.");
            }
        }

        public Entity findEntity(List<Entity> entities, String entityName)
        {
            int listNum = -1;
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].name == entityName)
                {
                    listNum = i;
                }
            }
            if (listNum >= 0)
            {
                return entities[listNum];
            }
            else
            {
                Console.WriteLine(entityName + " couldn't be found.");
                return null;
            }
        }

        public void transferItem(List<Entity> entities, string transferTo, string transferFrom, string itemName)
        {
            Entity takeFrom = findEntity(entities, transferFrom);
            Entity giveTo = findEntity(entities, transferTo);
            int itemID = -1;
            for (int i = 0; i < takeFrom.inventory.Count; i++)
            {
                if (takeFrom.inventory[i].name == itemName)
                {
                    itemID = i;
                    i += takeFrom.inventory.Count;
                }
            }
            if (itemID >= 0)
            {
                if (takeFrom.inventory[itemID].weight <= giveTo.carryWeight)
                {
                    giveTo.addToInventory(takeFrom.inventory[itemID]);
                    takeFrom.removeFromInventory(takeFrom.inventory[itemID]);
                }
                else
                {
                    Console.WriteLine("Item couldn't be transfered, it was too heavy.");
                }
            }
            else
            {
                Console.WriteLine(itemName + " couldn't be found.");
            }
        }
    }
}
