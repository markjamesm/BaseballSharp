using System;
using MLBSharp;

namespace MLBSharpCli
{
    class Program
    {
        static void Main(string[] args)
        {
            string todaysDate = DateTime.Now.ToString("MM-dd-yyyy").Replace("-", "/");

            var upcomingGames =  MlbApi.Schedule(todaysDate);

            foreach (var game in upcomingGames)
            {
                Console.WriteLine($"{game.AwayTeam} vs {game.HomeTeam} at {game.Ballpark}");
            }

            var pitching = MlbApi.PitchingReports(todaysDate);

            foreach (var pitcher in pitching)
            {
                Console.WriteLine($"Home pitcher: {pitcher.HomeProbablePitcherName}, Notes: {pitcher.HomeProbablePitcherNotes}");
            }

            var teamsList = MlbApi.TeamData();

            foreach (var team in teamsList)
            {
                Console.WriteLine($"{team.FullName}, {team.Id}");
            }

        }
    }
}
