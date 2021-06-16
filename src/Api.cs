using BaseballSharp.DTO;
using BaseballSharp.DTO.GameSchedule;
using BaseballSharp.DTO.Linescore;
using BaseballSharp.DTO.PitchingReport;
using BaseballSharp.DTO.Teams;
using BaseballSharp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseballSharp
{
    /// <summary>
    /// The Api class holds all MLB Stats API endpoints that can be accessed from Baseball Sharp.
    /// </summary>
    public class Api
    {
        private static readonly string _baseUrl = "https://statsapi.mlb.com/api/v1";

        private static async Task<string> getResponse(string? Endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                var return_message = new HttpResponseMessage();

                try
                {
                    return_message = await client.GetAsync(_baseUrl + (Endpoint ?? "")).ConfigureAwait(false);
                }
                catch (System.Exception ex)
                {
                    throw;
                }

                return await return_message.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Returns a list of the matchups and ballpark for the specified date.
        /// </summary>
        /// <param name="date">The date to return data for.</param>
        /// <returns>A list of schedule objects.</returns>
        public static async Task<IEnumerable<Schedule>> Schedule(DateTime date)
        {
            List<Schedule> upcomingGames = new();

            string jsonResponse = await getResponse("/schedule/games/?sportId=1&date=" + date.ToString("MM/dd/yyyy"));

            ScheduleDto? gameSchedule = JsonSerializer.Deserialize<ScheduleDto>(jsonResponse);

            foreach (DTO.GameSchedule.Date? item in (gameSchedule ?? new ScheduleDto()).dates ?? new List<DTO.GameSchedule.Date>())
            {
                foreach (DTO.GameSchedule.Game? game in item.games ?? new DTO.GameSchedule.Game[0])
                {
                    upcomingGames.Add(new Schedule(game?.teams?.home?.team?.name,
                        game?.teams?.away?.team?.name,
                        game?.venue?.name,
                        game?.scheduledInnings));
                }
            }

            return upcomingGames;
        }

        /// <summary>
        /// Returns a list of pitchers and their associated game reports.
        /// </summary>
        /// <param name="date">The date to return data for.</param>
        /// <returns>A list of pitching report objects</returns>
        public static async Task<IEnumerable<PitchingReport>> PitchingReports(DateTime date)
        {
            List<PitchingReport> pitchingReports = new();

            string jsonResponse = await getResponse("/schedule?sportId=1&hydrate=probablePitcher(note)" +
                "&fields=dates,date,games,gamePk,gameDate,status,abstractGameState," +
                "teams,away,home,team,id,name,probablePitcher,id,fullName,note&" + date.ToString("MM/dd/yyyy"));

            PitchingReportDto? reports = JsonSerializer.Deserialize<PitchingReportDto>(jsonResponse);

            foreach (var selectedDate in (reports ?? new PitchingReportDto()).dates ?? new DTO.PitchingReport.Date[0])
            {
                foreach (var game in (selectedDate ?? new DTO.PitchingReport.Date()).games ?? new DTO.PitchingReport.Game[0])
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

            return pitchingReports;
        }

        /// <summary>
        /// Returns a list of all MLB teams and some associated data. The ID parameters can be used to build other queries.
        /// </summary>
        /// <returns>A list of team objects.</returns>
        public static async Task<IEnumerable<Models.Team>> TeamData()
        {
            List<Models.Team> teamsList = new();

            string jsonResponse = await getResponse("/teams?sportId=1");

            TeamDto? mlbTeams = JsonSerializer.Deserialize<TeamDto>(jsonResponse);

            foreach (var team in (mlbTeams ?? new TeamDto()).teams ?? new DTO.Teams.Team[0])
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

            return teamsList;
        }

        /// <summary>
        /// Returns a list of team roster data for a given season.
        /// Use the TeamData() call to obtain the id numbers needed to satisfy the teamId parameter.
        /// </summary>
        /// <param name="teamId"> The team's MLB id (use enum)</param>
        /// <param name="season"> The year the season begins on</param>
        /// <param name="date"> A date to use, will return the roster as of that date</param>
        /// <param name="roster"> The roster type to return. Can choose either full roster, 25man or 40 man</param>
        /// <returns>An IEnumerable TeamRoster</returns>
        public static async Task<IEnumerable<TeamRoster>> TeamRoster(int teamId, int season, DateTime date, rosterType roster = rosterType.rosterFull)
        {
            List<TeamRoster> teamRosters = new();

            string type_string = "";

            switch (roster)
            {
                case rosterType.rosterFull:
                    type_string = "/teams/" + teamId + "/roster/fullRoster?season=" + season + "&date=" + date.ToString("MM/dd/yyyy");
                    break;

                case rosterType.roster25:
                    type_string = "/teams/" + teamId + "/roster?season=" + season + "&date=" + date.ToString("MM/dd/yyyy");
                    break;

                case rosterType.roster40:

                    type_string = "/teams/" + teamId + "/roster?season=" + season + "&rosterType=40Man" + "&date=" + date.ToString("MM/dd/yyyy");
                    break;

                default:
                    break;
            }

            string jsonResponse = await getResponse(type_string);

            TeamRosterDto? teamRostersJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

            foreach (var item in (teamRostersJson ?? new TeamRosterDto()).roster ?? new Roster[0])
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

            return teamRosters;
        }

        /// <summary>
        /// Returns a list of linescore data for the game in question.
        /// </summary>
        /// <returns>A list of Linescore objects.</returns>
        /// <param name="gameId">The ID number of the game.</param>
        /// <returns>A list of Linescore objects</returns>
        public static async Task<IEnumerable<Linescore>> LineScore(int gameId)
        {
            List<Linescore> lineScores = new();

            string jsonResponse = await getResponse("/game/" + gameId + "/linescore");

            LinescoreDto? lineScoresJson = JsonSerializer.Deserialize<LinescoreDto>(jsonResponse);

            foreach (var inning in (lineScoresJson ?? new LinescoreDto()).innings ?? new List<Innings>())
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

            return lineScores;
        }

        /// <summary>
        /// Returns a list of depth chart information for a given team.
        /// Use the TeamData() call to obtain the id numbers needed to satisfy the teamId parameter.
        /// </summary>
        /// <returns>A list of team objects.</returns>
        /// <param name="teamId">The team's ID number.</param>
        /// <returns>A list of pitching report objects</returns>
        public static async Task<IEnumerable<DepthChart>> DepthChart(int teamId)
        {
            List<DepthChart> depthCharts = new();

            string jsonResponse = await getResponse("/teams/" + teamId + "/roster/depthChart");

            TeamRosterDto? depthChartJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

            foreach (var person in (depthChartJson ?? new TeamRosterDto()).roster ?? new Roster[0])
            {
                depthCharts.Add(new DepthChart(
                    depthChartJson?.teamId,
                    depthChartJson?.rosterType,
                    person?.person?.id,
                    person?.person?.fullName,
                    person?.jerseyNumber,
                    person?.position?.code,
                    person?.position?.name,
                    person?.position?.type,
                    person?.position?.abbreviation,
                    person?.status?.code,
                    person?.status?.description));
            }

            return depthCharts;
        }

        /// <summary>
        /// Endpoint to get the MLB divisions and associated data.
        /// </summary>
        /// <returns>A list of Division objects.</returns>
        public static async Task<IEnumerable<Models.Division>> Divisions()
        {
            List<Models.Division> divisions = new();

            string jsonResponse = await getResponse("/divisions?sportId=1");

            DivisionsDto? teamDivisions = JsonSerializer.Deserialize<DivisionsDto>(jsonResponse);

            foreach (LeagueDivision? division in (teamDivisions ?? new DivisionsDto()).divisions ?? new LeagueDivision[0])
            {
                divisions.Add(new Models.Division(
                division?.id,
                division?.name,
                division?.nameShort,
                division?.abbreviation,
                division?.league?.id));
            }

            return divisions;
        }
    }
}