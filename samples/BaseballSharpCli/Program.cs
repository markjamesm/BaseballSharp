using System;
using System.Threading.Tasks;
using BaseballSharp;
using BaseballSharp.Enums;

namespace BaseballSharpCli
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var mlbClient = new MLBClient();

            var upcomingGames = await mlbClient.GetScheduleAsync(DateTime.Now);

            foreach (var game in upcomingGames)
            {
                Console.WriteLine($"{game.AwayTeam} vs {game.HomeTeam} at {game.Ballpark}");
            }

            var pitching = await mlbClient.GetPitchingReportsAsync(DateTime.Now);

            foreach (var pitcher in pitching)
            {
                Console.WriteLine($"Home pitcher: {pitcher.HomeProbablePitcherName}, Notes: {pitcher.HomeProbablePitcherNotes}");
            }

            var teamsList = await mlbClient.GetTeamDataAsync();

            foreach (var team in teamsList)
            {
                Console.WriteLine($"{team.FullName}, {team.Id}");
            }

            // Example of casting the team ids enum to int in the parameter.
            var teamRoster = await mlbClient.GetTeamRosterAsync(eTeamIdEnum.BlueJays.Id, 2021, DateTime.Now, rosterType.rosterFull);

            foreach (var team in teamRoster)
            {
                Console.WriteLine($"{team.PlayerFullName}, {team.PlayerPosition}, {team.StatusCode}");
            }

            // Display some basic data from the LineScore endpoint.
            var lineScore = await mlbClient.GetLineScoreAsync(529572);

            foreach (var inning in lineScore)
            {
                Console.WriteLine($"Inning: {inning.InningNumber}, 2nd base: {inning.SecondBasemanName}, 1st base: {inning.FirstBasemanName}");
            }

            // Get a team's depth chart
            var depthChart = await mlbClient.GetDepthChartAsync(111);

            foreach (var person in depthChart)
            {
                Console.WriteLine($"Name: {person.PlayerFullName}, position: {person.PositionName}");
            }

            // Get a list of divisions
            var divisions = await mlbClient.GetDivisionsAsync();

            foreach (var division in divisions)
            {
                Console.WriteLine($"Division name: {division.DivisionName}, Division ID: {division.DivisionId}");
            }
        }
    }
}