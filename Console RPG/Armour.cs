using System;

namespace Console_RPG
{
    class Armour : Equipment
    {
        public static Armour adventureStuff = new Armour(5, 2, "Adveturer Tunic", "Doesn't protect against much", 1, 50);
        public static Armour leather = new Armour(12, 15.4f, "Leather Armour", "Simple leather armour.", 3, 27);
        public static Armour leather2 = new Armour(12, 15.4f, "Leather Armour", "Simple leather armour.", 3, 27);
        public static Armour leather3 = new Armour(12, 15.4f, "Leather Armour", "Simple leather armour.", 3, 27);
        public static Armour steel = new Armour(35, 40.5f, "Steel Armour", "This is heavy.", 6, 150);

        public static Armour bandit = new Armour(6, 7.25f, "Bandit Light Armour", "Armour for bandits", 4, 45);
        public static Armour bandit2 = new Armour(6, 7.25f, "Bandit Light Armour", "Armour for bandits", 4, 45);
        public static Armour bandit3 = new Armour(6, 7.25f, "Bandit Light Armour", "Armour for bandits", 4, 45);
        public static Armour bandit4 = new Armour(6, 7.25f, "Bandit Light Armour", "Armour for bandits", 4, 45);
        public static Armour bandit5 = new Armour(6, 7.25f, "Bandit Light Armour", "Armour for bandits", 4, 45);
        public static Armour bandit6 = new Armour(6, 7.25f, "Bandit Light Armour", "Armour for bandits", 4, 45);
        public static Armour cultist = new Armour(25, 3.5f, "Cultist Garb", "Cultists love these", 5, 50);
        public static Armour cultist2 = new Armour(25, 3.5f, "Cultist Garb", "Cultists love these", 5, 50);
        public static Armour cultist3 = new Armour(25, 3.5f, "Cultist Garb", "Cultists love these", 5, 50);
        public static Armour cultist4 = new Armour(25, 3.5f, "Cultist Garb", "Cultists love these", 5, 50);
        public static Armour cultist5 = new Armour(25, 3.5f, "Cultist Garb", "Cultists love these", 5, 50);
        public static Armour cultist6 = new Armour(25, 3.5f, "Cultist Garb", "Cultists love these", 5, 50);
        public static Armour cultist7 = new Armour(25, 3.5f, "Cultist Garb", "Cultists love these", 5, 50);
        public static Armour cultist8 = new Armour(25, 3.5f, "Cultist Garb", "Cultists love these", 5, 50);

        public static Armour shop = new Armour(150, 15.25f, "Enhanced Leather Armour", "Better durability", 3, 65);
        public static Armour shop2 = new Armour(250, 20.25f, "Armour or Mysterious Origin", "What is it made of?", 4, 85);
        public static Armour shop3 = new Armour(350, 25.25f, "Armour of Mysterious Origin", "???", 4, 105);
        public static Armour shop4 = new Armour(450, 30.25f, "Iron Armour", "Heavy", 5, 125);
        public static Armour shop5 = new Armour(550, 35.25f, "Enhanced Iron Armour", "Heavy", 5, 145);
        public static Armour shop6 = new Armour(650, 40.25f, "Enhacned Steel Armour", "Good durability", 6, 165);

        public int defence;

        public Armour(int price, float weight, string name, string description, int defence, int durability) : base(price, weight, name, description, durability)
        {
            this.defence = defence;
        }

        public override void Use(Entity user, Entity target)
        {
            if (curDurability > 0)
            {
                curDurability -= 1;
                if (curDurability <= 0)
                {
                    Console.WriteLine(name + " broke!");
                    user.stats.defence -= defence;
                }
            }
        }

        public void equip(Entity user)
        {
            isEquiped = !isEquiped;

            if (isEquiped)
            {
                user.stats.defence += defence;
                user.carryWeight -= weight;
            }
            else
            {
                user.stats.defence -= defence;
                user.carryWeight -= weight;
            }
        }

        public void repair(Entity user)
        {
            if (curDurability == 0)
            {
                user.stats.defence += defence;
            }
            curDurability = maxDurability;

        }
    }
}
