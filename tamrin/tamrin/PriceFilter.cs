using System;

namespace tamrin
{
    public interface IFilter
    {
        bool Filter(Item item);
    }

    public class PriceFilter : IFilter
    {
        public double Price;
        
        public bool Filter(Item item)
        {
            return Price >= item.Price;
        }
    }

    public class PriceRangeFilter : IFilter
    {
        public double minPrice;
        public double maxPrice;

        public bool Filter(Item item)
        {
            if (item.Price <= minPrice && item.Price >= maxPrice)
                return true;
            return false;
        }
    }

    public class ReleasedDateFilter : IFilter
    {
        public DateTime Date;
        public bool Filter(Item item)
        {
            return item.RealeseDate >= Date;
        }
    }

    public class BrandFilter : IFilter
    {
        public string MyBrand; 
        public bool Filter(Item item)
        {
            return item.Brand == MyBrand;
        }
    }
}