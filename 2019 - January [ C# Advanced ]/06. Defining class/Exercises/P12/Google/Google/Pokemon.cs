namespace Google
{
    public class Pokemon
    {
        private string pokemonName;
        private string pokemonType;

        public Pokemon()
        {

        }
        public Pokemon(string pokemonName, string pokemonType)
        {
            this.PokemonName = pokemonName;
            this.PokemonType = pokemonType;
        }
        public override string ToString()
        {
            if (pokemonName == null)
            {
                return "";
            }
            return "\r\n" + this.PokemonName + " " + this.PokemonType;
        }

        public string PokemonName { get => pokemonName; set => pokemonName = value; }
        public string PokemonType { get => pokemonType; set => pokemonType = value; }
    }
}