using System;
using System.Collections.Generic;
using System.Text;

namespace Tema2
{
    class WeatherData
    {
        public int Index { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public WeatherData()
        {
            Index = 0;
            MaxTemp = 0;
            MinTemp = 0;
        }

        public static WeatherData[] ArrayGenerator(int size)
        {
            return new WeatherData[size];
        }
    }
}
