namespace _08._Pokemon_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokemonTrainer
    {
        public static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();

            var inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "Tournament")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                var currentTrainerName = tokens[0];
                var currentPokemon = Pokemon.Parse(tokens.Skip(1).ToArray());

                if (!trainers.ContainsKey(currentTrainerName))
                {
                    trainers.Add(currentTrainerName, new Trainer(currentTrainerName));
                }

                trainers[currentTrainerName].Pokemons.Add(currentPokemon);
            }

            while ((inputLine = Console.ReadLine()) != "End")
            {
                trainers
                    .ToList()
                    .ForEach(x => x.Value.ProccessElement(inputLine));
            }

            trainers
                .OrderByDescending(x => x.Value.Badges)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Value.Name} {x.Value.Badges} {x.Value.Pokemons.Count}"));
        }
    }
}
