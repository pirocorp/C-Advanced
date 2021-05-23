namespace SoftUniParking
{
    using System.Collections.Generic;

    public class Parking
    {
        private readonly Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, Car>(capacity);
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            if (this.cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.cars.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            var success = this.cars.Remove(registrationNumber);

            if (!success)
            {
                return "Car with that registration number, doesn't exist!";
            }

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            if (!this.cars.ContainsKey(registrationNumber))
            {
                return null;
            }

            return this.cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                this.cars.Remove(registrationNumber);
            }
        }
    }
}
