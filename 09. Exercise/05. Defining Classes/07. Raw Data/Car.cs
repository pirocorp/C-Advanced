namespace _05._Raw_Data
{
    using System;

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }

        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public string Model
        {
            get => model;
            set => model = value;
        }

        public Engine EngineProp
        {
            get => engine;
            set => engine = value;
        }
        
        public Cargo CargoProp
        {
            get => cargo;
            set => cargo = value;
        }

        public Tire[] Tires
        {
            get => tires;
            set => tires = value;
        }

        public static Car Parse(string input)
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var model = tokens[0];

            var engineSpeed = int.Parse(tokens[1]);
            var enginePower = int.Parse(tokens[2]);

            var currentEngine = new Engine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(tokens[3]);
            var cargoType = tokens[4];

            var currentCargo = new Cargo(cargoWeight, cargoType);

            var tires = new Tire[4];
            var tireIndex = 0;

            for (var i = 1; i < 9; i += 2)
            {
                var pressureIndex = 4 + i;
                var ageIndex = 5 + i;

                var currentPresure = double.Parse(tokens[pressureIndex]);
                var currentAge = int.Parse(tokens[ageIndex]);

                var currentTire = new Tire(currentPresure, currentAge);
                tires[tireIndex++] = currentTire;
            }

            return new Car(model, currentEngine, currentCargo, tires);
        }
    }
}
