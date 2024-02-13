namespace Console_RPG
{
    class Weapon : Item
    {
        public int attackDamage;
        public int curDurability, maxDurability;

        public Weapon(int price, float weight, string name, string description, int attackDamage,int durability) : base(price, weight, name, description)
        {
            this.attackDamage = attackDamage;
            this.curDurability = durability;
            this.maxDurability = durability;
        }

        public override void Use(Entity user, Entity target)
        {
            curDurability -= user.stats.strength;
            user.stats.strength += attackDamage;
            user.Attack(target);
            user.stats.strength -= attackDamage;
        }
    }
}
