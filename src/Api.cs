using System.Text.Json;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using BaseballSharp.Models;
using BaseballSharp.DTO.GameSchedule;
using BaseballSharp.DTO.PitchingReport;
using BaseballSharp.DTO.Teams;

namespace BaseballSharp
{
    public class Api
    {
        private static readonly string _baseUrl = "http://statsapi.mlb.com/api/v1";

        /// <summary>
        /// Returns a list of the matchups and ballpark for the specified date.
        /// </summary>
        /// <param name="date">The date (MM/dd/yyyy) to return data for.</param>
        /// <returns>A list of schedule objects.</returns>
        public static List<Schedule> Schedule(string date)
        {
            List<Schedule> upcomingGames = new();

            try
            {
                WebClient client = new();
                string jsonResponse = client.DownloadString(_baseUrl + "/schedule/games/?sportId=1&date=" + date);

                ScheduleDto? gameSchedule = JsonSerializer.Deserialize<ScheduleDto>(jsonResponse);

                foreach (var item in gameSchedule.dates)
                {
                    foreach (var game in item.games)
                    {
                        upcomingGames.Add(new Schedule(game?.teams?.home?.team?.name, 
                            game?.teams?.away?.team?.name, 
                            game?.venue?.name, 
                            game?.scheduledInnings));
                    }
                }
            }

            catch(WebException ex)
            {
                // Need to change this.
                Debug.WriteLine($"Error {ex}");
            }

            return upcomingGames;
        }

        /// <summary>
        /// Returns a list of pitchers and their associated game reports.
        /// </summary>
        /// <param name="date">The date (MM/dd/yyyy) to return data for.</param>
        /// <returns>A list of pitching report objects</returns>
        public static List<PitchingReport> PitchingReports(string date)
        {
            List<PitchingReport> pitchingReports = new();

            try
            {
                WebClient client = new();
                string jsonResponse = client.DownloadString(_baseUrl + "/schedule?sportId=1&hydrate=probablePitcher(note)" +
                    "&fields=dates,date,games,gamePk,gameDate,status,abstractGameState," +
                    "teams,away,home,team,id,name,probablePitcher,id,fullName,note&" + date);

                PitchingReportDto? reports = JsonSerializer.Deserialize<PitchingReportDto>(jsonResponse);

                foreach (var selectedDate in reports.dates)
                { 
                    foreach (var game in selectedDate.games)
                    {
                        pitchingReports.Add(new PitchingReport(game?.teams?.home?.team?.name,
                            game?.teams?.home?.probablePitcher?.fullName,
                            game?.teams?.home?.probablePitcher?.id,
                            game?.teams?.home?.probablePitcher?.note,
                            game?.teams?.away?.team?.name,
                            game?.teams?.away?.probablePitcher?.fullName,
                            game?.teams?.away?.probablePitcher?.id,
                            game?.teams?.away?.probablePitcher?.note));
                    }
                }
            }

            catch(WebException ex)
            {
                Debug.WriteLine($"Error {ex}");
            }

            return pitchingReports;
        }


        /// <summary>
        /// Returns a list of all MLB teams and some associated data. The ID parameters can be used to build other queries.
        /// </summary>
        /// <returns>A list of team objects.</returns>
        public static List<Models.Team> TeamData()
        {
            List<Models.Team> teamsList = new();

            try
            {
                WebClient client = new();
                string jsonResponse = client.DownloadString(_baseUrl + "/teams?sportId=1");

                TeamDto? mlbTeams = JsonSerializer.Deserialize<TeamDto>(jsonResponse);

                foreach (var team in mlbTeams.teams)
                {
                    teamsList.Add(new Models.Team(team.name, 
                        team?.teamName, 
                        team?.locationName, 
                        team?.id, 
                        team?.league?.name, 
                        team?.league?.id, 
                        team?.division?.name, 
                        team?.division?.id, 
                        team?.abbreviation, 
                        team?.venue?.name, 
                        team?.venue?.id));
                }
            }

            catch (WebException ex)
            {
                Debug.WriteLine($"Error {ex}");
            }

            return teamsList;
        }
    }
}
