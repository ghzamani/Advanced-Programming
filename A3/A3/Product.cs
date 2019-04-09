using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Product
    {
        private string _name;
        private float _price;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public float Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}