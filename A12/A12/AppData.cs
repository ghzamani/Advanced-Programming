using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace A12
{
    public class AppData
    {
        public string Name;
        public string Category;
        public double Rating;
        public long Reviews;
        public double Size;
        public long Installs;
        public bool IsFree; 
        public double Price;
        public string ContentRating;
        public List<string> Genres = new List<string>(); 
        public DateTime LastUpdate;
        public string CurrentVersion;
        public string AndroidVersion;

        public AppData(string[] fields)
        {
            Name = fields[0];
            Category = fields[1];

            if (!double.TryParse(fields[2], out Rating))
                Rating = 0;
                
            Reviews = long.Parse(fields[3]);

            if (!double.TryParse(fields[4].Trim('M'), out Size))
                Size = 0;
            
            Installs = long.Parse(fields[5].Trim('+'), NumberStyles.AllowThousands);

            if (fields[6] == "Free")
                IsFree = true;
            else IsFree = false;

            Price = double.Parse(fields[7].Trim('$'));
            ContentRating = fields[8];

            var genres = fields[9].Split(';');
            this.Genres = genres.ToList();

            DateTime.TryParse(fields[10],out LastUpdate);
            //if (LastUpdate == DateTime.MinValue) ; //khob?

            CurrentVersion = fields[11];
            AndroidVersion = fields[12];
        }
    }
}
