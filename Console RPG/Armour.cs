namespace Console_RPG
{
    class Armour : Item
    {
        public int defence;
        public int curDurability, maxDurability;

        public Armour(int price, float weight, string name, string description, int defence, int durability) : base(price, weight, name, description)
        {
            this.defence = defence;
            this.curDurability = durability;
            this.maxDurability = durability;
        }

        public override void Use(Entity user, Entity target)
        {
            curDurability -= user.damageTaken;
        }
    }
}
