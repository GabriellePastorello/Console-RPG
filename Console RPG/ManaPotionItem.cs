using System;

namespace Console_RPG
{
    class ManaPotionItem : Item
    {
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
            if (random.Next(20) <= manaSickness)
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
