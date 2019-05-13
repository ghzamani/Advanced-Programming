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
        public double MinPrice;
        public double MaxPrice;
        public PriceRangeFilter(double min, double max)
        {
            this.MinPrice = min;
            this.MaxPrice = max;
        }
        public bool Filter(Item item)
        {
            if (item.Price >= MinPrice && item.Price <= MaxPrice)
                return true;
            return false;
        }
    }

    public class ReleaseDateFilter : IFilter
    {
        public DateTime Date;
        public ReleaseDateFilter(DateTime date)
        {
            Date = date;
        }
        public bool Filter(Item item)
        {
            return item.RealeseDate >= Date;
        }
    }

    public class BrandFilter : IFilter
    {
        public string MyBrand;
        public BrandFilter(string myBrand)
        {
            MyBrand = myBrand;
        }
        public bool Filter(Item item)
        {
            return item.Brand == MyBrand;
        }
    }
}