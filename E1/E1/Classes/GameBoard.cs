using System;
using System.Collections.Generic;
using System.Linq;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
    {
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }

        public List<IAnimal> Animals { get; set; }

        public string[] MoveAnimals()
        {
            List<string> result = new List<string>();
            List<Environment> environments = new List<Environment>()
            { Environment.Air , Environment.Land , Environment.Watery};
            foreach(IAnimal animal in Animals)
            {
                foreach(var e in environments)
                {
                    string str = animal.Move(e);
                    result.Add(str);
                }
            }
            return result.ToArray();
        }
    }
}