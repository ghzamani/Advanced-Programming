using System;
using System.Collections.Generic;

namespace A7
{
    public static class PoliceStation
    {

        private static List<string> _blackList;
        public static List<string> BlackList
        {
            get => _blackList;
            set
            {
                _blackList = value;
            }
        }
        public static bool BackgroundCheck(ICitizen citizen)
        {
            return BlackList.Contains(citizen.Name);
        }
    }
}