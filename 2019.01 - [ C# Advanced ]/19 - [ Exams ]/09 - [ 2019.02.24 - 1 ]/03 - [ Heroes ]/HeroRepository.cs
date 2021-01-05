namespace Heroes
{
    using System.Linq;
    using System.Collections.Generic;

    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count
        {
            get => this.data.Count;
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            foreach (var hero in this.data.Where(x => x.Name == name))
            {
                this.data.Remove(hero);
                break;
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        }
    }
}