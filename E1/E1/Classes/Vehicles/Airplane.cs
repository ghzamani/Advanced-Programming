using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Airplane : IFlyable
    {
        public string Model { get; set; }
        public double SpeedRate { get; set; }

        public Airplane(double speedRate, string model)
        {
            this.Model = model;
            this.SpeedRate = speedRate;

        }

        public string Fly()
        {
            string l = string.Empty;
            l = l + this.Model + " with " + this.SpeedRate + " speed rate is flying";
            return l;
        }
    }
}