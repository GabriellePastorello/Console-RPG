using System;

namespace Console_RPG
{
    class HealthPotionItem : Item
    {
        public int healAmount;
        public int cancer;

        public HealthPotionItem(int price, float weight, string name, string description, int healAmount, int cancer) : base(price, weight, name, description)
        {
            this.healAmount = healAmount;
            this.cancer = cancer;
        }

        public override void Use(Entity user, Entity target)
        {
            Random random = new Random();
            if (random.Next(20) <= cancer)
            {
                user.maxHP -= cancer;
                Console.WriteLine(user.name + " lost " + cancer + " max HP from cancer.");
            }
            user.currentHP += healAmount;
            if (user.currentHP > user.maxHP)
            {
                user.currentHP = user.maxHP;
            }
            Console.WriteLine(user.name + " healed for " + healAmount + " HP!");
        }

    }
}
