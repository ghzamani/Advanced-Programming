using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Snake : ICrawlable, IAnimal
    {
        public Snake(string name, int age, double health, double speedRate)
        {
            this.SpeedRate = speedRate;
            this.Name = name;
            this.Age = age;
            this.Health = health;
        }

        public double SpeedRate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }

        public string Crawl()
        {
            string l = string.Empty;
            l = l + this.Name + " is a Snake" + " and is crawling";
            return l;
        }

        public string EatFood()
        {
            string l = string.Empty;
            l = l + this.Name + " is a Snake" + " and is eating";
            return l;
        }

        public string Move(Environment e)
        {
            string l = string.Empty;
            if (e == Environment.Land)
            {
                l = Crawl();
                return l;
            }
            else
            {
                l = l + this.Name + " is a Snake and can't move in " + e + " environment";
                return l;
            }
                
        }

        public string Reproduction(IAnimal animal)
        {

            string l = string.Empty;
            l = l + this.Name + " is a Snake" + " and reproductive with " + animal.Name;
            return l;
        }
    }
}