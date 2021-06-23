namespace _05._Raw_Data
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }

        private double pressure;
        private int age;

        public double Pressure
        {
            get => pressure;
            set => pressure = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }
    }
}
