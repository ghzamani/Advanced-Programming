using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamrin
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime RealeseDate { get; set; }
        public string Brand { get; set; }

        public Item(int id,string title, double price, 
            DateTime realeseDate, string brand)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.RealeseDate = realeseDate;
        }

        public Item() { }

        public double UpdatePrice (double newPrice)
        {
            this.Price = 1.2 * newPrice;  
            return (newPrice >= Price ? Price : newPrice);
        }

        /*public void AddToCart (Customer customer)
        {

        }*/
    }

    

    public class ItemInventory 
    {
        public List<Item> Items = new List<Item>();

        public List<Item> Filter (List<IFilter> filters)
        {
            List<Item> Result = new List<Item>();
            foreach (var item in Items)
            {
                bool AllPassed = true;
                foreach(var filter in filters)
                {
                    if (!filter.Filter(item))
                        AllPassed = false;
                }
                if (AllPassed)
                    Result.Add(item);
            }
            return Result;
        }

        public Item GetItemById(int id)
        {
            foreach(var item in this.Items)
            {
                if (item.Id == id)
                    return item;
            }
            return new Item();
        }

        public int AddItem(Item item)
        {
            Items.Add(item);
            return Items.Count;
        }

        public bool RemoveItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
