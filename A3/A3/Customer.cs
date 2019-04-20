using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        private string _name;
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
        private City _city;
        public City City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }
        private List<Order> _orders = new List<Order>();
        public List<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                foreach (var order in value)
                    _orders.Add(order);
            }
        }

        public Customer(string name, City city, List<Order> orders)
        {
            Name = name;
            City = city;
            Orders = orders;
        }
        
        public Product MostOrderedProduct()
        {
            List<double> tedad = new List<double>();
            foreach(var order in Orders)
            {
                foreach(var product in order.Products)
                {
                    tedad.Add(0);
                    for(int i=0; i< Orders.Count; i++ )
                    {
                        for(int j=0; j< Orders[i].Products.Count; j++)
                        {
                            if(product == Orders[i].Products[j]
                                && i!=j)
                            {
                                tedad[tedad.Count-1]++;
                            }
                        }
                    }
                }
            }

            double max = tedad.Max();
            int indexeMax=tedad.IndexOf(max);
            int a = 0;
            for(int i=0; i<Orders.Count; i++)
            {
                for(int j=0; j < Orders[i].Products.Count; j++)
                {
                    if (a == indexeMax)
                    {
                        return Orders[i].Products[j];
                    }
                    a++;
                }
            }
           
            return null; 
        }

        public List<Order> UndeliveredOrders()
        {
            List<Order> unDeliveredItems = new List<Order>();
            foreach (var order in Orders)
            {
                if (order.IsDelivered == false)
                    unDeliveredItems.Add(order);
            }

            return unDeliveredItems;
        }
    }
}