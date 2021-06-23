namespace _05._Raw_Data
{
    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        private int engineSpeed;
        private int enginePower;
        
        public int EngineSpeed
        {
            get => engineSpeed;
            set => engineSpeed = value;
        }

        public int EnginePower
        {
            get => enginePower;
            set => enginePower = value;
        }
    }
}