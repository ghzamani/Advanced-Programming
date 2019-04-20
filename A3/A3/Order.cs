using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        private List<Product> _products = new List<Product>();
        private bool _delivered;
        public List<Product> Products
        {
            get
            {
                return _products; 
            }
            set
            {
                foreach (var v in value)
                    _products.Add(v);
            }
        }
        public bool IsDelivered
        {
            get
            {
                return _delivered;
            }
            set
            {
                _delivered = value;
            }
        }

        public Order(List<Product> products, bool isDelivered)
        {
            Products = products;
            IsDelivered = isDelivered;
        }

        public float CalculateTotalPrice()
        {
            float totalPrice=0;
            foreach (var Product in Products)
                totalPrice += Product.Price;
            return totalPrice;
        }
    }
}