using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Crow : IFlyable , IAnimal
    {
        public Crow(string name, int age, double health, double speedRate)
        {
        }

        public double SpeedRate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }

        public string EatFood()
        {
            string l = string.Empty;
            l = l + this.Name + " is a " + typeof(Crow).Name + " and is eating";
            return l;
        }

        public string Fly()
        {
            string l = string.Empty;
            l = l + Name + " is a " + typeof(Crow).Name + " and is flying";
            return l;
        }

        public string Move(Environment e)
        {
            string l = string.Empty;
            if(e == Environment.Air)
            {
                l = Fly();
                return l;
            }
            else
            {
                l = l + this.Name + " is a " + typeof(Crow).Name + " and can't move in " + e + " environment";
                return l;
            }
        }

        public string Reproduction(IAnimal animal)
        {
            string l = string.Empty;
            l = l + this.Name + " is a " + typeof(Crow).Name + " and reproductive with " + animal.Name;
            return l;
        }
    }
}