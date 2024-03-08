using System.Collections.Generic;
using System;

namespace Console_RPG
{
    class NPC : Feature
    {
        public static NPC adventurerEncounter = new NPC(Player.adventurer as Entity, "You find an adventurer who has set up a small camp. Wierd how they weren't noticed by the dragon cultists...", "Hello fellow adventurers. If you're heading west, could you tell me if you find the mythical Qilin? I've been looking for it, but the dragon cultists are trying to capture it first.", "Wow, you actually found the Qilin? Well then, I'll join you. If you do beat Ebony, I'll want to be part of it.", "Sorry, but I'm still looking for the Qilin. Maybe next time?", false);
        public static NPC warriorEncounter = new NPC(Player.warrior as Entity, "You find a warrior at the foot of the mountain. They don't seem to be dangerous.", "Are you planning on going onto Cinder Mountain? You should climb up the cliffs if you don't want to run into any trouble.", "You want me to join you? Eh, why not.", "You want me to join you? It doesn't look like you'll last up there.", false);
        public static NPC QilinEncounter = new NPC(Mount.Qilin as Entity, "You find a horse covered in scales with white antlers and fire burning at its shoulders. It's the mythical Qilin.", "*stares*", "*the Qilin walks up and nuzzles you*", "*it turns away from you*", false);

        public Entity npc;
        public string intro;
        public string dialogue;
        public string recruitDialogue;
        public string failRecruitDialogue;

        public NPC(Entity npc, string intro, string dialogue, string recruitDialogue, string failRecruitDialogue, bool isResolved) : base(isResolved)
        {
            this.npc = npc;
            this.intro = intro;
            this.dialogue = dialogue;
            this.recruitDialogue = recruitDialogue;
            this.failRecruitDialogue = failRecruitDialogue;
        }

        public override void Resolve(List<Entity> allies)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + intro);
            while (true)
            {
                Console.WriteLine("What would you like to do?\nTalk\nRecruit\nLeave");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                if (input == "Talk")
                {
                    Console.WriteLine("\n" + npc.name + ": " + dialogue);
                }
                else if (input == "Recruit")
                {
                    if (npc.name == "Adventurer")
                    {
                        if (findEntity(allies, "Qilin"))
                        {
                            Console.WriteLine("\n" + npc.name + ": " + recruitDialogue);
                            Entity.allies.Add(npc);
                            isResolved = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n" + npc.name + ": " + failRecruitDialogue);
                        }
                    }
                    else if (npc.name == "Warrior")
                    {
                        if (findEntity(allies, "Sellsword") && findEntity(allies, "Sell sword"))
                        {
                            Console.WriteLine("\n" + npc.name + ": " + recruitDialogue);
                            Entity.allies.Add(npc);
                            isResolved = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n" + npc.name + ": " + failRecruitDialogue);
                        }
                    }
                    else
                    {
                        if (Player.gold >= 1000)
                        {
                            Console.WriteLine("\n" + npc.name + ": " + recruitDialogue);
                            Entity.allies.Add(npc);
                            isResolved = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n" + npc.name + ": " + failRecruitDialogue);
                        }
                    }
                }
                else if (input == "Leave")
                {
                    Console.WriteLine("\n" + npc.name + ": Bye");
                    break;
                }
                else
                {
                    Console.WriteLine("\n" + npc.name + ": ?");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public bool findEntity(List<Entity> entities, String entityName)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].name == entityName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
