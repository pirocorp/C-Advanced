using System;
using System.Linq;

namespace _08._Pokemon_Trainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        public Trainer(string name):this(name, 0, new List<Pokemon>())
        {
        }

        private Trainer(string name, int badges, List<Pokemon> pokemons)
        {
            this.name = name;
            this.badges = badges;
            this.pokemons = pokemons;
        }

        private string name;
        private int badges;
        private List<Pokemon> pokemons;
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Badges
        {
            get => badges;
            set => badges = value;
        }

        public List<Pokemon> Pokemons
        {
            get => pokemons;
            set => pokemons = value;
        }

        public void ProccessElement(string element)
        {
            var hasPokemonWithElement = Pokemons.Any(x => string.Equals(x.Element, element, StringComparison.CurrentCultureIgnoreCase));

            if (hasPokemonWithElement)
            {
                badges++;
            }
            else
            {
                PokemonsLoseHealth(10);
            }
        }

        private void PokemonsLoseHealth(int i)
        {
            pokemons.ForEach(x => x.Health -= 10);
            pokemons = pokemons.Where(x => x.Health > 0).ToList();
        }
    }
}
