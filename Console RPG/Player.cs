using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Console_RPG
{
    class Player : Entity
    {
        public static Player player = new Player("You", "Human", 80, 100, 100, new Stats(5, 5, 5, 5), weapon: Weapon.sword3, armour: Armour.leather);
        public static Player hiredBlade = new Player("Sellsword", "Human", 75, 80, 100, new Stats(4, 5, 6, 4), weapon: Weapon.sword, armour: Armour.leather2);
        public static Player hiredBlade2 = new Player("Sell sword", "Human", 75, 80, 100, new Stats(4, 5, 6, 4), weapon: Weapon.sword2, armour: Armour.leather3);
        public static Player adventurer = new Player("Adventurer", "Human", 65, 90, 100, new Stats(6, 4, 3, 6), weapon: Weapon.sword4, armour: Armour.adventureStuff);
        public static Player warrior = new Player("Warrior", "Human", 100, 120, 120, new Stats(6, 6, 6, 6), weapon: Weapon.sword5, armour: Armour.steel);

        public int xp, level;
        public static int gold = 150;
        public bool isMounted;
        public Mount mount;
        public bool isChaotic;

        public Player(string name, string race, int hp, int mana, float carryWeight, Stats stats, Mount mount = null, Armour armour = null, Weapon weapon = null) : base(name, race, hp, mana, carryWeight, stats)
        {
            xp = 0;
            level = 1;
            isMounted = false;
            isChaotic = false;
            if (name == "Adventurer")
            {
                isChaotic = true;
            }
            this.mount = mount;
            this.armour = armour;
            this.weapon = weapon;
        }

        public void changeName(String name)
        {
            this.name = name;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            String theTarget;
            Console.WriteLine("Choose a target");
            foreach (Entity i in targets)
            {
                if (i.currentHP > 0)
                {
                    Console.WriteLine(i.name + " " + i.currentHP + "/" + i.maxHP);
                }
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
            Console.WriteLine("\n");
            Random random = new Random();
            int damage = (stats.strength + random.Next(stats.strength)) - (target.stats.defence);
            int dodgeChance = target.stats.speed - this.stats.speed;
            if (isChaotic && random.Next(15) <= 1)
            {
                damage *= 2;
                dodgeChance /= 2;
            }
            
            if (damage <= 0)
            {
                Console.WriteLine(target.name + " blocked " + name + "'s attack!");
                if (!(target.armour is null))
                {
                    target.UseItem(target.armour, target);
                }
            }
            else if (random.Next(40) <= dodgeChance)
            {
                Console.WriteLine(target.name + " dodged " + name + "'s attack!");
            }
            else
            {
                Console.WriteLine(name + " attacked " + target.name + " for " + damage + " damage!");
                target.currentHP -= damage;
                if (!(target.armour is null))
                {
                    target.UseItem(target.armour, target);
                }
            }
            if (!(weapon is null))
            {
                UseItem(weapon, this);
            }
            if (target.currentHP <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(target.name + " has been defeated!");
            }
        }

        public override void Spell(Entity target)
        {
            if ((currentMana < stats.intelligence))
            {
                Console.WriteLine("Not enough mana");
                return;
            }
            Console.WriteLine("\n");
            Random random = new Random();
            int damage = (stats.intelligence + random.Next(stats.intelligence)) - target.stats.intelligence;
            int dodgeChance = target.stats.speed - this.stats.speed;
            if (isChaotic && random.Next(15) <= 1)
            {
                damage *= 2;
                dodgeChance /= 2;
            }
            currentMana -= stats.intelligence;
            if (damage <= 0)
            {
                Console.WriteLine(target.name + " resisted " + name + "' spell!");
                if (!(target.armour is null))
                {
                    target.UseItem(target.armour, target);
                }
            }
            else if (random.Next(40) <= dodgeChance)
            {
                Console.WriteLine(target.name + " dodged " + name + "'s spell!");
            }
            else
            {
                Console.WriteLine(name + " attacked " + target.name + " with a spell for " + damage + " damage!");
                target.maxHP -= damage;
                if (target.currentHP > target.maxHP)
                {
                    target.currentHP = target.maxHP;
                }
                if (!(target.armour is null))
                {
                    target.UseItem(target.armour, target);
                }
            }
            if (target.currentHP <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(target.name + " has been defeated!");
                maxHP += damage;
            }
        }

        public void LevelUp()
        {
            if (xp >= level*10)
            {
                xp -= level * 10;
                level++;
                Console.WriteLine(name + " leveled up to level " + level + "! Choose a stat to level up.\nHP " + maxHP + " --> " + (maxHP+10) + " | Mana " + maxMana + " --> " + (maxMana+10) + " | Speed " + stats.speed + " --> " + (stats.speed+1) + " | Strength " + stats.strength + " --> " + (stats.strength+1) + " | Defence " + stats.defence + " --> " + (stats.defence+1) + " | Intelligence " + stats.speed + "-- > " + (stats.speed+1));
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
                    giveTo.inventory.Remove(takeFrom.inventory[itemID]);
                    takeFrom.inventory.Remove(takeFrom.inventory[itemID]);
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

        public Item ChooseItem(List<Item> items)
        {
            String theTarget;
            Console.WriteLine("Choose an item");
            foreach (Item i in items)
            {
                Console.WriteLine(i.name);
            }
            theTarget = Console.ReadLine();
            foreach (Item i in items)
            {
                if (i.name == theTarget)
                {
                    return i;
                }
            }
            Console.WriteLine("Invalid Target. Try again.");
            return ChooseItem(items);
        }
        public override void DoTurn(List<Entity> allies, List<Enemy> enemies)
        {
            if (!(mount is null))
            {
                if (mount.currentHP <= 0)
                {
                    dismountHorse();
                }
            }
            Console.WriteLine("What would " + name + " like to do?\na.Use Item\nb.Attack\nc.Spell\nd.Skip");
            String choice = Console.ReadLine();
            if (choice == "a" && !(inventory is null) && inventory.Count > 0)
            {
                Item item = ChooseItem(inventory);
                UseItem(item, this);
                inventory.Remove(item);
            }
            else if (choice == "a")
            {
                Console.WriteLine("No items in inventory");
                DoTurn(allies, enemies);
            }
            else if (choice == "b")
            {
            
               Attack(ChooseTarget(enemies.Cast<Entity>().ToList()));
            }
            else if (choice == "c")
            {
                Spell(ChooseTarget(enemies.Cast<Entity>().ToList()));
            }
            else if (choice == "d")
            {
                Console.WriteLine("\n" + name + " skipped their turn.");
                currentHP += 2;
                if (currentHP > maxHP)
                {
                    maxHP += 1;
                    currentHP = maxHP;
                }
                currentMana += 2;
                if (currentMana > maxMana)
                {
                    maxMana += 1;
                    currentMana = maxMana;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input.");
                DoTurn(allies, enemies);
            }
            Random random = new Random();
            if (isChaotic && random.Next(15) <= 1)
            {
                Thread.Sleep(2000);
                Console.WriteLine("\n" +name + " takes another turn.");
                Thread.Sleep(2000);
                DoTurn(allies, enemies);
            }

        }

        public override void gainXP(int xp)
        {
            this.xp += xp;
            while (this.xp >= level*10)
            {
                LevelUp();
            }
        }
    }
}