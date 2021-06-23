namespace _05._Raw_Data
{
    public class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }

        private int cargoWeight;
        private string cargoType;
        
        public int CargoWeight
        {
            get => cargoWeight;
            set => cargoWeight = value;
        }

        public string CargoType
        {
            get => cargoType;
            set => cargoType = value;
        }
    }
}
