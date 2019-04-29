using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Frog : IAnimal, IWalkable, ISwimable
    {
        public Frog(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string Name  {get; set;}
        public int Age  {get; set;}
        public double Health  {get; set;}
        public double SpeedRate { get; set; }

        public string EatFood()
        {
            string l = string.Empty;
            l = l + this.Name + " is a " + typeof(Frog).Name + " and is eating";
            return l;
        }

        public string Move(Environment e)
        {
            string l = string.Empty;
            if (e == Environment.Air)
            {
                l = l + this.Name + " is a " + typeof(Frog).Name + " and can't move in " + e + " environment";
                return l; 
            }
            else
            {
                if (e == Environment.Land)
                {
                    l = Walk();
                    return l;
                }

                else
                {
                    l = Swim();
                    return l;
                }  
            }
        }

        public string Reproduction(IAnimal animal)
        {
            string l = string.Empty;
            l = l + this.Name + " is a " + typeof(Frog).Name + " and reproductive with " + animal.Name;
            return l;
        }

        public string Swim()
        {
            string l = string.Empty;
            l = l + this.Name + " is a " + typeof(Frog).Name + " and is swimming";
            return l;
        }

        public string Walk()
        {
            string l = string.Empty;
            l = l + this.Name + " is a " + typeof(Frog).Name + " and is walking";
            return l;
        }
    }
}