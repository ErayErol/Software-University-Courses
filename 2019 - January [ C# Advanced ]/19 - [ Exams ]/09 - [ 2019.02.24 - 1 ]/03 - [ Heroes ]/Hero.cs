namespace Heroes
{
    using System;

    public class Hero
    {
        private Item item;

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            return $"Hero: {this.Name} – {this.Level}lvl" + Environment.NewLine +
                   $"Item:" + Environment.NewLine +
                   $"  * Strength: {this.Item.Strength}" + Environment.NewLine +
                   $"  * Ability: {this.Item.Ability}" + Environment.NewLine +
                   $"  * Intelligence: {this.Item.Intelligence}";
        }
    }
}