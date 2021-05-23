using System;

namespace _08._Pokemon_Trainer
{
    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }

        private string name;
        private string element;
        private int health;
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Element
        {
            get => element;
            set => element = value;
        }

        public int Health
        {
            get => health;
            set => health = value;
        }

        public static Pokemon Parse(string input)
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Pokemon Parse(string[] input)
        {
            var name = input[0];
            var element = input[1];
            var health = int.Parse(input[2]);

            return new Pokemon(name, element, health);
        }
    }
}
