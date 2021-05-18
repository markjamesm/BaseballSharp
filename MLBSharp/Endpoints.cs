using System.Text.Json;
using System.Net;
using System.Collections.Generic;

namespace MLBSharp
{
    public class Endpoints
    {
        /// <summary>
        /// Returns a list of the matchups and ballpark for the specified date (tab-delineated).
        /// </summary>
        /// <param name="date">The date (MM/dd/yyyy) to get data for in string format.</param>
        public static List<string> Matchups(string date)
        {
            List<string> teams = new();

            try
            {
                WebClient client = new();
                string json = client.DownloadString("http://statsapi.mlb.com/api/v1/schedule/games/?sportId=1&date=" + date);

                UpcomingGames games = JsonSerializer.Deserialize<UpcomingGames>(json);

                teams.Add($"Home team   Away team   Ballpark");

                foreach (var item in games.dates)
                {
                    foreach (var l in item.games)
                    {
                        teams.Add($"{l.teams.home.team.name}    {l.teams.away.team.name}    {l.venue.name}");
                    }
                }
            }

            catch(WebException ex)
            {
                teams.Add($"Error: {ex}");
            }

            return teams;
        }
    }
}
