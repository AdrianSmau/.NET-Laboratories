using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Tema2
{
    class ProgramBeforeDRY
    {
        public void Run()
        {
            StreamReader objInputWeather = new StreamReader("..\\..\\..\\weather.dat", System.Text.Encoding.Default);
            string contents = objInputWeather.ReadToEnd().Trim(); //getting the data from the table
            string[] split = contents.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            int found = 1;
            int temperaturesCount = 0;
            WeatherData[] days = new WeatherData[30]; //storing the days and their temperatures in an array
            for (int i = 0; i < 30; i++)
            {
                days[i] = new WeatherData(); //intializing it 
            }
            foreach (string s in split)
            {
                if (found.ToString() == s)
                {
                    days[found - 1].Index = found; //we look for the days after their I , then we look for the immediate 2 next temperatures of that day 
                    temperaturesCount = 2;
                    found++;
                }
                else if (temperaturesCount != 0)
                {
                    try
                    {
                        if (temperaturesCount == 2) days[found - 2].MaxTemp = Int32.Parse(s); //the first temperature is the max one , and the next is the minimum
                        else days[found - 2].MinTemp = Int32.Parse(s);
                        temperaturesCount--;
                    }
                    catch (Exception) { }
                }
            }
            int MinSpread = 100;
            int MinIndex = 0;
            foreach (WeatherData d in days)
            {
                if (MinSpread > d.MaxTemp - d.MinTemp) { MinIndex = d.Index; MinSpread = d.MaxTemp - d.MinTemp; } //computing the minimum difference
            }
            Console.WriteLine("Ziua cu media cea mai mica este: " + MinIndex);


            StreamReader objInputFootball = new StreamReader("..\\..\\..\\football.dat", System.Text.Encoding.Default);
            contents = objInputFootball.ReadToEnd().Trim(); //getting the data from the table
            string[] parse = contents.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            found = 1;
            int namefound = 0;
            int goalsfound = 0;
            TeamData[] teams = new TeamData[20];
            for (int i = 0; i < 20; i++)
            {
                teams[i] = new TeamData();
            }
            foreach (string s in parse)
            {
                if ((found.ToString() + ".") == s)
                {
                    namefound = 1; goalsfound = 9; found++;
                    //Console.Write(s+" ");
                }
                else
                {
                    if (namefound == 1) { teams[found - 2].Name = s; namefound = 0; }
                    try
                    {
                        if (goalsfound == 4) { teams[found - 2].ScoredGoals = Int32.Parse(s); }
                        if (goalsfound == 2) { teams[found - 2].ConcededGoals = Int32.Parse(s); }
                    }
                    catch (Exception) { continue; }
                    goalsfound--;
                }
            }
            int MinDif = 1000;
            string MinName = "";
            foreach (TeamData t in teams)
            {
                int x = t.ScoredGoals - t.ConcededGoals;
                if (x < 0) x = -x;
                if (MinDif > x) { MinDif = x; MinName = t.Name; }
            }
            Console.WriteLine("Echipa cu cea mai mica diferenta de goluri : " + MinName);
        }
    }
}
