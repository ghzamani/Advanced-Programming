using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Shop
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
        private List<Customer> _customers = new List<Customer>();
        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                foreach (var customer in value)
                    _customers.Add(customer);
            }
        }

        public Shop(string name, List<Customer> customers)
        {
            Name = name;
            Customers = customers;
        }


        public List<City> CitiesCustomersAreFrom()
        {
            List<City> city = new List<City>();
            foreach(var customer in Customers)
            {
                if (city.Contains(customer.City)) ;
                else city.Add(customer.City); 
            }
            
            return city;
        }

        public List<Customer> CustomersFromCity(City city)
        {
            List<Customer> customers = new List<Customer>();
            foreach(var customer in Customers)
            {
                if (customer.City == city)
                    customers.Add(customer);
            }
            return customers;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            List<double> tedad = new List<double>();
            foreach(var customer in Customers)
            {
                tedad.Add(customer.Orders.Count);
            }
            double maxTedad = tedad.Max();
            List<Customer> returnedCustomers = new List<Customer>();
            for(int i = 0; i < tedad.Count; i++)
            {
                if(tedad[i] == maxTedad)
                {
                    returnedCustomers.Add(Customers[i]);
                }
            }
           
            return returnedCustomers;
        }
    }
}