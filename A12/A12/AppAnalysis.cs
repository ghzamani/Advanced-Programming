using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A12
{
    public class AppAnalysis
    {
        public List<AppData> Apps = new List<AppData>();
        
        public static AppAnalysis AppAnalysisFactory(string appDatapath)
        {
            var appAnalysis = new AppAnalysis();
            using (TextFieldParser parser = new TextFieldParser(appDatapath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields(); //jahate skip kardane khate aval
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    appAnalysis.AppendApp(fields);
                }
            } 
            return appAnalysis;
        }

        private void AppendApp(string[] fields)
        {
            AppData lineData = new AppData(fields);
            Apps.Add(lineData);
        }

        public long AllAppsCount()
        {
             return Apps.Count();
        }

        public long AppsAboveXRatingCount(double x)
        { 
            return Apps.Select(rate => rate.Rating)
                .Where(rate => rate >= x).Count();
        }

        public long RecentlyUpdatedCount(DateTime boundary)
        {
            return Apps.Select(lU => lU.LastUpdate)
                .Where(lU => lU >= boundary).Count(); 
        }

        public string RecentlyUpdatedFreqCat(DateTime boundary)
        {
            var c = Apps.Where(d => d.LastUpdate >= boundary)
                .GroupBy(d => d.Category)
                .OrderByDescending(g => g.Count()).ToList();            
            return c[0].Key; 
        }
        
        public List<string> MostRatedCategories(double ratingBoundary, int n)
        {
            return Apps.Where(rate => rate.Rating > ratingBoundary)
                .GroupBy(d => d.Category).OrderByDescending(g => g.Count())
                .Take(n).Select(d => d.Key).ToList();
        }

        public double TopQuarterBoundary(string category = "PHOTOGRAPHY")
        {
            var firstQuarter = Apps.Where(d => d.Category == category)
                .OrderByDescending(d => d.Rating)
                .Skip(Apps.Where(d => d.Category == category)
                .OrderByDescending(d => d.Rating).Count()/4).First();
                
            return firstQuarter.Rating;
        }

        public Tuple<string,string> ExtremeMeanUpdateElapse(DateTime today)
        {
            var l = Apps.GroupBy(d => d.Category)
                .Select(g => g.Average(x => (today - x.LastUpdate).TotalDays)).OrderBy(x => x)
                .ToList();
            string str1 = Apps.GroupBy(d => d.Category)
                .Where(g => g.Average(x => (today - x.LastUpdate).TotalDays) == l.First())
                .ToList().First().Key;
            string str2 = Apps.GroupBy(d => d.Category)
                .Where(g => g.Average(x => (today - x.LastUpdate).TotalDays) == l.Last())
                .ToList().First().Key;

            return new Tuple<string, string>(str1, str2);

        }

        public List<string> XMostProfitables(int x)
        {
            return Apps.Where(d => !d.IsFree).OrderByDescending(d => d.Installs * d.Price)
                .Select(d => d.Name).Take(x).ToList();            
        }

        public List<string> XCoolestApps(int x , Func<AppData, double> criteria)
        {
            return Apps.OrderBy(d => criteria(d)).Take(x).Select(d => d.Name).ToList();            
        }
    }
}
