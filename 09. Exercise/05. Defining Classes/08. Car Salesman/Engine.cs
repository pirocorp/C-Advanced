namespace _07._Car_Salesman
{
    using System;

    public class Engine
    {
        public Engine(string model, int power, string displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        private string model;
        private int power;
        private string displacement;
        private string efficiency;
        
        public string Model
        {
            get => model;
            set => model = value;
        }

        public int Power
        {
            get => power;
            set => power = value;
        }

        public string Displacement
        {
            get => displacement;
            set => displacement = value;
        }

        public string Efficiency
        {
            get => efficiency;
            set => efficiency = value;
        }

        public static Engine Parse(string input)
        {
            var displacement = "n/a";
            var efficiency = "n/a";

            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var model = tokens[0];
            var power = int.Parse(tokens[1]);

            if (tokens.Length > 2)
            {
                var isdigit = int.TryParse(tokens[2], out var parsed);

                if (isdigit)
                {
                    displacement = parsed.ToString();
                }
                else
                {
                    efficiency = tokens[2];
                }

                if (tokens.Length > 3)
                {
                    if (isdigit)
                    {
                        efficiency = tokens[3];
                    }
                    else
                    {
                        displacement = tokens[3];
                    }
                }
            }

            return new Engine(model, power, displacement, efficiency);
        }

        public override string ToString()
        {
            return $"  {this.Model}:" + Environment.NewLine +
                   $"    Power: {this.Power}" + Environment.NewLine +
                   $"    Displacement: {this.Displacement}" + Environment.NewLine +
                   $"    Efficiency: {this.Efficiency}" + Environment.NewLine;
        }
    }
}