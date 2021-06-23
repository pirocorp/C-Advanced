namespace _07._Car_Salesman
{
    using System;

    public class Car
    {
        public Car(string model, Engine engine, string weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        private string model;
        private Engine engine;
        private string weight;
        private string color;
        
        public string Model
        {
            get => model;
            set => model = value;
        }

        public Engine Engine
        {
            get => engine;
            set => engine = value;
        }

        public string Weight
        {
            get => weight;
            set => weight = value;
        }

        public string Color
        {
            get => color;
            set => color = value;
        }

        public static Car Parse(string input, Engine engine)
        {
            var weight = "n/a";
            var color = "n/a";

            var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var model = tokens[0];

            if (tokens.Length > 2)
            {
                var isdigit = int.TryParse(tokens[2], out var parsed);

                if (isdigit)
                {
                    weight = parsed.ToString();
                }
                else
                {
                    color = tokens[2];
                }

                if (tokens.Length > 3)
                {
                    if (isdigit)
                    {
                        color = tokens[3];
                    }
                    else
                    {
                        weight = tokens[3];
                    }
                }
            }

            return new Car(model, engine, weight, color);
        }

        public override string ToString()
        {
            return $"{this.Model}:" + Environment.NewLine +
                   $"{this.Engine}" +
                   $"  Weight: {this.Weight}" + Environment.NewLine +
                   $"  Color: {this.Color}" + Environment.NewLine;
        }
    }
}
