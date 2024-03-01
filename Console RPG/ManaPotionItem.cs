using System;

namespace Console_RPG
{
    class ManaPotionItem : Item
    {
        public static ManaPotionItem manaPotion = new ManaPotionItem(10, 2, "Weak Mana Potion", "Recovers 10 mana", 10, 1);
        public static ManaPotionItem manaPotion2 = new ManaPotionItem(25, 3, "Moderate Mana Potion", "Recovers 30 mana", 30, 3);
        public static ManaPotionItem manaPotion3 = new ManaPotionItem(50, 4, "Strong Mana Potion", "Recovers 100 mana", 100, 10);

        public int manaAmount;
        public int manaSickness;

        public ManaPotionItem(int price, float weight, string name, string description, int manaAmount, int manaSickness) : base(price, weight, name, description)
        {
            this.manaAmount = manaAmount;
            this.manaSickness = manaSickness;
        }

        public override void Use(Entity user, Entity target)
        {
            Random random = new Random();
            if (random.Next(user.maxMana - user.currentMana) <= manaSickness)
            {
                user.maxMana -= manaSickness;
                Console.WriteLine(user.name + " lost " + manaSickness + " max mana from mana sickness.");
            }
            user.currentMana += manaAmount;
            if (user.currentMana > user.maxMana)
            {
                user.currentMana = user.maxMana;
            }
            Console.WriteLine(user.name + " recovered " + manaAmount + " mana!");
        }
    }
}
