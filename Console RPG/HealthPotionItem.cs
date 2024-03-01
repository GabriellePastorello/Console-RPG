using System;

namespace Console_RPG
{
    class HealthPotionItem : Item
    {
        public static HealthPotionItem healthPotion = new HealthPotionItem(10, 2, "Weak Health Potion", "Heals 10 health", 10, 1);
        public static HealthPotionItem healthPotion2 = new HealthPotionItem(25, 3, "Moderate Health Potion", "Heals 30 health", 30, 3);
        public static HealthPotionItem healthPotion3 = new HealthPotionItem(50, 4, "Strong Health Potion", "Heals 100 health", 100, 10);

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
            if (random.Next(user.maxHP - user.currentHP) <= cancer)
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
