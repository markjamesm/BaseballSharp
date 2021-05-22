using System.Text.Json;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using BaseballSharp.Models;
using BaseballSharp.DTO.GameSchedule;
using BaseballSharp.DTO.PitchingReport;
using BaseballSharp.DTO.Teams;
using BaseballSharp.DTO;
using BaseballSharp.DTO.Linescore;

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

            catch (WebException ex)
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

            catch (WebException ex)
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

        /// <summary>
        /// Returns a list of team roster data for a given season.
        /// Use the TeamData() call to obtain the id numbers needed to satisfy the teamId parameter. 
        /// </summary>
        /// <returns>A list of team objects.</returns>
        /// <param name="teamId">The team's ID number.</param>
        /// <param name="season">The desired season, eg: 2021.</param>
        /// <returns>A list of pitching report objects</returns>
        public static List<TeamRoster> TeamRoster(int teamId, int season)
        {
            List<TeamRoster> teamRosters = new();

            try
            {
                WebClient client = new();
                string jsonResponse = client.DownloadString(_baseUrl + "/teams/" + teamId + "/roster/fullRoster?season=" + season);

                TeamRosterDto? teamRostersJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

                foreach (var item in teamRostersJson.roster)
                {
                    teamRosters.Add(new TeamRoster(
                        item?.person?.id,
                        item?.person?.fullName,
                        item?.position?.name,
                        item?.position?.type,
                        item?.position?.code,
                        teamRostersJson?.teamId,
                        item?.position?.abbreviation,
                        item?.status?.code,
                        item?.status?.description));
                }
            }
            catch (WebException)
            {
                throw new WebException();
            }

            return teamRosters;
        }

        /// <summary>
        /// Returns a list of linescore data for the game in question.
        /// </summary>
        /// <returns>A list of Linescore objects.</returns>
        /// <param name="gameId">The ID number of the game.</param>
        /// <returns>A list of Linescore objects</returns>
        public static List<Linescore> LineScore(int gameId)
        {
            List<Linescore> lineScores = new();

            try
            {
                WebClient client = new();
                string jsonResponse = client.DownloadString(_baseUrl + "/game/" + gameId + "/linescore");

                LinescoreDto? lineScoresJson = JsonSerializer.Deserialize<LinescoreDto>(jsonResponse);

                foreach (var inning in lineScoresJson.innings)
                {
                    lineScores.Add(new Linescore(
                        lineScoresJson?.currentInning,
                        lineScoresJson?.inningHalf,
                        lineScoresJson?.scheduledInnings,
                        lineScoresJson?.teams?.home.runs,
                        lineScoresJson?.teams?.home.hits,
                        lineScoresJson?.teams?.home.errors,
                        lineScoresJson?.teams?.away.runs,
                        lineScoresJson?.teams?.away.hits,
                        lineScoresJson?.teams?.away.errors,
                        inning?.num,
                        lineScoresJson?.defense?.pitcher?.id,
                        lineScoresJson?.defense?.pitcher?.fullName,
                        lineScoresJson?.defense?.catcher?.fullName,
                        lineScoresJson?.defense?.catcher?.id,
                        lineScoresJson?.defense?.first?.fullName,
                        lineScoresJson?.defense?.first?.id,
                        lineScoresJson?.defense?.second?.fullName,
                        lineScoresJson?.defense?.second?.id,
                        lineScoresJson?.defense?.third?.fullName,
                        lineScoresJson?.defense?.third?.id,
                        lineScoresJson?.defense?.shortstop?.fullName,
                        lineScoresJson?.defense?.shortstop?.id,
                        lineScoresJson?.defense?.left?.fullName,
                        lineScoresJson?.defense?.left?.id,
                        lineScoresJson?.defense?.center?.fullName,
                        lineScoresJson?.defense?.center?.id,
                        lineScoresJson?.defense?.right?.fullName,
                        lineScoresJson?.defense?.right?.id,
                        lineScoresJson?.defense?.batter?.fullName,
                        lineScoresJson?.defense?.batter?.id,
                        lineScoresJson?.defense?.onDeck?.fullName,
                        lineScoresJson?.defense?.onDeck?.id,
                        lineScoresJson?.defense?.inHole?.fullName,
                        lineScoresJson?.defense?.inHole?.id,
                        lineScoresJson?.defense?.team?.name,
                        lineScoresJson?.defense?.team?.id,
                        lineScoresJson?.offense?.batter?.fullName,
                        lineScoresJson?.offense?.batter?.id,
                        lineScoresJson?.offense?.onDeck?.fullName,
                        lineScoresJson?.offense?.onDeck?.id,
                        lineScoresJson?.offense?.inHole?.fullName,
                        lineScoresJson?.offense?.inHole?.id));
                }
            }
            catch (WebException)
            {
                throw new WebException();
            }

            return lineScores;
        }
    }
}
