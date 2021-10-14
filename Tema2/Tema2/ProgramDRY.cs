using System;
using System.IO;
namespace Tema2
{

    class ProgramDRY
    {
        private static readonly int WEATHER_ARRAY_SIZE = 30;
        private static readonly int FOOTBALL_ARRAY_SIZE = 20;
        private int WeatherFound = 1;
        private int TemperaturesCount = 0;
        private int FootballTeamsFound = 1;
        private int TeamNamesFound = 0;
        private int TeamGoalsFound = 0;
        private readonly string[] WeatherDatContents = ParseDatFile("..\\..\\..\\weather.dat");
        private readonly string[] FootballDatContents = ParseDatFile("..\\..\\..\\football.dat");
        private WeatherData[] WeatherObjects = WeatherData.ArrayGenerator(WEATHER_ARRAY_SIZE);
        private TeamData[] TeamObjects = TeamData.ArrayGenerator(FOOTBALL_ARRAY_SIZE);
        public void Run()
        {
            InitObjects();
            Console.WriteLine("The day number with the smallest temperature spread is: " + ComputeMinTempDay());
            Console.WriteLine("The name of the team with the smallest difference in ‘for’ and ‘against’ goals is: " + ComputeMinGoalDifTeam());
        }

        // COMPUTING FUNCTIONS

        private int ComputeMinTempDay()
        {
            foreach (string s in WeatherDatContents)
            {
                if (WeatherFound.ToString() == s)
                {
                    WeatherObjects[WeatherFound - 1].Index = WeatherFound; //we look for the days after their I , then we look for the immediate 2 next temperatures of that day
                    TemperaturesCount = 2;
                    WeatherFound++;
                }
                else if (TemperaturesCount != 0)
                {
                    try
                    {
                        if (TemperaturesCount == 2) WeatherObjects[WeatherFound - 2].MaxTemp = Int32.Parse(s); //the first temperature is the max one , and the next is the minimum
                        else WeatherObjects[WeatherFound - 2].MinTemp = Int32.Parse(s);
                        TemperaturesCount--;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Parse Error!");
                    }
                }
            }
            int MinSpread = 100;
            int MinIndex = 0;
            foreach (WeatherData d in WeatherObjects)
            {
                if (MinSpread > d.MaxTemp - d.MinTemp)
                {
                    MinIndex = d.Index;
                    MinSpread = d.MaxTemp - d.MinTemp; //computing the minimum difference
                }
            }
            return MinIndex;
        }

        private string ComputeMinGoalDifTeam()
        {
            foreach (string s in FootballDatContents)
            {
                if ((FootballTeamsFound.ToString() + ".") == s)
                {
                    TeamNamesFound = 1;
                    TeamGoalsFound = 9;
                    FootballTeamsFound++;
                }
                else
                {
                    if (TeamNamesFound == 1)
                    {
                        TeamObjects[FootballTeamsFound - 2].Name = s;
                        TeamNamesFound = 0;
                    }
                    try
                    {
                        if (TeamGoalsFound == 4) TeamObjects[FootballTeamsFound - 2].ScoredGoals = Int32.Parse(s);
                        if (TeamGoalsFound == 2) TeamObjects[FootballTeamsFound - 2].ConcededGoals = Int32.Parse(s);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Parse Error!");
                    }
                    TeamGoalsFound--;
                }
            }
            int MinDif = 1000;
            string MinName = "";
            foreach (TeamData t in TeamObjects)
            {
                int diff = Math.Abs(t.ScoredGoals - t.ConcededGoals);
                if (MinDif > diff)
                {
                    MinDif = diff;
                    MinName = t.Name;
                }
            }
            return MinName;
        }

        // UTILITY FUNCTIONS

        private static string[] ParseDatFile(string path)
        {
            StreamReader objInputWeather = new StreamReader(path, System.Text.Encoding.Default);
            string contents = objInputWeather.ReadToEnd().Trim(); //getting the data from the table
            return contents.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
        }
        private void InitObjects()
        {
            for (int i = 0; i < FOOTBALL_ARRAY_SIZE; i++)
            {
                WeatherObjects[i] = new WeatherData();
                TeamObjects[i] = new TeamData();
            }
            for (int i = FOOTBALL_ARRAY_SIZE; i < WEATHER_ARRAY_SIZE; i++)
            {
                WeatherObjects[i] = new WeatherData();
            }
        }
    }
}
