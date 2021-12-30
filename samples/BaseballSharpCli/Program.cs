using BaseballSharp;
using System;
using BaseballSharp.Enums;

namespace MLBSharpCli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var upcomingGames = Api.Schedule(DateTime.Now).GetAwaiter().GetResult();

            foreach (var game in upcomingGames)
            {
                Console.WriteLine($"{game.AwayTeam} vs {game.HomeTeam} at {game.Ballpark}");
            }

            var pitching = Api.PitchingReports(DateTime.Now).GetAwaiter().GetResult();

            foreach (var pitcher in pitching)
            {
                Console.WriteLine($"Home pitcher: {pitcher.HomeProbablePitcherName}, Notes: {pitcher.HomeProbablePitcherNotes}");
            }

            var teamsList = Api.TeamData().GetAwaiter().GetResult();

            foreach (var team in teamsList)
            {
                Console.WriteLine($"{team.FullName}, {team.Id}");
            }

            // Example of casting the team ids enum to int in the parameter.
            var teamRoster = Api.TeamRoster((int)eTeamId.BlueJays, 2021, DateTime.Now, rosterType.rosterFull).GetAwaiter().GetResult();

            foreach (var team in teamRoster)
            {
                Console.WriteLine($"{team.PlayerFullName}, {team.PlayerPosition}, {team.StatusCode}");
            }

            // Display some basic data from the LineScore endpoint.
            var lineScore = Api.LineScore(529572).GetAwaiter().GetResult();

            foreach (var inning in lineScore)
            {
                Console.WriteLine($"Inning: {inning.InningNumber}, 2nd base: {inning.SecondBasemanName}, 1st base: {inning.FirstBasemanName}");
            }

            // Get a team's depth chart
            var depthChart = Api.DepthChart(111).GetAwaiter().GetResult();

            foreach (var person in depthChart)
            {
                Console.WriteLine($"Name: {person.PlayerFullName}, position: {person.PositionName}");
            }

            // Get a list of divisions
            var divisions = Api.Divisions().GetAwaiter().GetResult();

            foreach (var division in divisions)
            {
                Console.WriteLine($"Division name: {division.DivisionName}, Division ID: {division.DivisionId}");
            }
        }
    }
}