using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Console_RPG
{
    class Battle
    {
        public bool isResolved;
        public List<Enemy> enemies;
        public List<Entity> turnOrder;


        public Battle(List<Enemy> enemies)
        {
            this.enemies = enemies;
            isResolved = false;
        }

        public void Resolve(List<Entity> allies)
        {
            Random rand = new Random();
            if (rand.Next(5) + allies.Count <= enemies.Count && !(enemies is null) && enemies[0].name != "Ebony")
            {
                enemies.Remove(enemies[0]);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou have been attacked!");
            Thread.Sleep(1000);
            foreach (Enemy e in enemies)
            {
                Console.WriteLine(e.name + " entered combat!");
                Thread.Sleep(1000);
            }
            turnOrder = new List<Entity>() { enemies[0] };
            for (int k = 1; k < enemies.Count; k++)
            {
                turnOrder.Add(enemies[k]);
            }
            foreach (Entity ally in allies)
            {
                turnOrder.Add(ally);
            }
            for (int i = 0; i < turnOrder.Count; i++)
            {
                for (int j = i+1; j < turnOrder.Count; j++)
                {
                    Entity placeHolder = turnOrder[j];
                    if (turnOrder[i].stats.speed < placeHolder.stats.speed)
                    {
                        turnOrder[j] = turnOrder[i];
                        turnOrder[i] = placeHolder;
                    }
                }
            }

            while (true)
            {
                foreach (Entity entity in turnOrder)
                {
                    if (entity.currentHP > 0)
                    {
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        if (entity is Player)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nIt is " + entity.name + "'s turn. " + entity.currentHP + "/" + entity.maxHP + " HP " + entity.currentMana + "/" + entity.maxMana + " Mana");
                        }
                        entity.DoTurn(allies, enemies);
                        if (allies.TrueForAll(Entity => Entity.currentHP <= 0))
                        {
                            break;
                        }
                        if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                        {
                            break;
                        }
                    }
                    
                }
                if (allies.TrueForAll(Entity => Entity.currentHP <= 0))
                {
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine("Quest Failed");
                    break;
                }
                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nAttackers Defeated!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    foreach (Enemy enemy in enemies)
                    {
                        foreach (Entity ally in allies)
                        {
                            if (ally.currentHP > 0)
                            {
                                ally.gainXP(enemy.expSpoils);
                            }
                            
                        }
                        Player.gold += enemy.goldSpoils;
                        Console.WriteLine("Party gained " + enemy.goldSpoils + " gold.");
                    }
                    break;
                }
            }
        }
    }
}
