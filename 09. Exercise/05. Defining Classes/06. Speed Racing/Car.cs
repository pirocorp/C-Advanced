namespace _04._Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionFor1Km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionFor1km = fuelConsumptionFor1Km;
            this.DistanceTraveled = 0;
        }

        private string model;
        private double fuelAmount;
        private double fuelConsumptionFor1km;
        private double distanceTraveled;
        
        public string Model
        {
            get => model;
            set => model = value;
        }

        public double FuelAmount
        {
            get => fuelAmount;
            set => fuelAmount = value;
        }

        public double FuelConsumptionFor1km
        {
            get => fuelConsumptionFor1km;
            private set => fuelConsumptionFor1km = value;
        }

        public double DistanceTraveled
        {
            get => distanceTraveled;
            private set => distanceTraveled = value;
        }

        public static Car Parse(string input)
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var carModel = tokens[0];
            var carFuelAmount = double.Parse(tokens[1]);
            var carFuelConsumption = double.Parse(tokens[2]);

            return new Car(carModel, carFuelAmount, carFuelConsumption);
        }

        public bool Drive(double amountOfKm)
        {
            var currentFuel = this.FuelAmount;
            var currentConsumption = this.FuelConsumptionFor1km;
            var neededFuel = currentConsumption * amountOfKm;

            if (currentFuel < neededFuel)
            {
                return false;
            }
            else
            {
                this.fuelAmount -= neededFuel;
                this.DistanceTraveled += amountOfKm;
                return true;
            }
        }
    }
}
