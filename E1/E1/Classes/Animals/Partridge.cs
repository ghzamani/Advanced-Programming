using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Partridge : IWalkable , IFlyable , IAnimal
    {
        public Partridge(string name, int age, double speedRate, double health)
        {
            Name = name;
            Age = age;
            SpeedRate = speedRate;
            Health = health;
        }

        public double SpeedRate  {get; set;}
        public string Name {get; set;}
        public int Age {get; set;}
        public double Health { get; set; }

        public string EatFood()
        {
            string l = string.Empty;
            l = l + Name + " is a " + typeof(Partridge).Name + " and is eating";
            return l;
        }

        public string Fly()
        {
            string l = string.Empty;
            l = l + Name + " is a " + typeof(Partridge).Name + " and is flying";
            return l;
        }

        public string Move(Environment e)
        {
            string l = string.Empty;
            if( e == Environment.Watery)
            {
                l = l + this.Name + " is a " + typeof(Partridge).Name + " and can't move in " + e + " environment";
                return l;
            }
            else
            {
                if(e== Environment.Land)
                {
                    l = Walk();
                    return l;
                }
                else
                {
                    l = Fly();
                    return l;
                }
            }
        }

        public string Reproduction(IAnimal animal)
        {
            string l = string.Empty;
            l = l + Name + " is a " + typeof(Partridge).Name + " and reproductive with " + animal.Name;
            return l;
        }

        public string Walk()
        {
            string l = string.Empty;
            l = l + Name + " is a " + typeof(Partridge).Name + " and is walking";
            return l;
        }
    }
}