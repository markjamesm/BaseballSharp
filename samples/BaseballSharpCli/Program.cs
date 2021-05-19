﻿using System;
using BaseballSharp;

namespace MLBSharpCli
{
    class Program
    {
        static void Main(string[] args)
        {
            string todaysDate = DateTime.Now.ToString("MM-dd-yyyy").Replace("-", "/");

            var upcomingGames =  Api.Schedule(todaysDate);

            foreach (var game in upcomingGames)
            {
                Console.WriteLine($"{game.AwayTeam} vs {game.HomeTeam} at {game.Ballpark}");
            }

            var pitching = Api.PitchingReports(todaysDate);

            foreach (var pitcher in pitching)
            {
                Console.WriteLine($"Home pitcher: {pitcher.HomeProbablePitcherName}, Notes: {pitcher.HomeProbablePitcherNotes}");
            }

            var teamsList = Api.TeamData();

            foreach (var team in teamsList)
            {
                Console.WriteLine($"{team.FullName}, {team.Id}");
            }

        }
    }
}