using BaseballSharp.DTO;
using BaseballSharp.DTO.GameSchedule;
using BaseballSharp.DTO.Linescore;
using BaseballSharp.DTO.PitchingReport;
using BaseballSharp.DTO.Teams;
using BaseballSharp.Enums;
using BaseballSharp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// The BaseballSharp namespace contains the classes used to interface with the MLB Stats Api, as well as associated helper types.
/// </summary>
namespace BaseballSharp
{
    /// <summary>
    /// The Api class holds all MLB Stats API endpoints that can be accessed from Baseball Sharp.
    /// </summary>
    public static class Api
    {
        private static HttpClient _httpClient = new HttpClient();
        private static readonly string _baseUrl = "https://statsapi.mlb.com/api/v1";

        private static async Task<string> GetResponse(string? Endpoint)
        {
            var returnMessage = await _httpClient.GetAsync(_baseUrl + (Endpoint ?? "")).ConfigureAwait(false);

            return await returnMessage.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Returns a list of the matchups and ballpark for the specified date.
        /// </summary>
        /// <param name="date">The date to return data for.</param>
        /// <returns>A list of schedule objects.</returns>
        public static async Task<IEnumerable<Schedule>> Schedule(DateTime date)
        {
            List<Schedule> upcomingGames = new();

            string jsonResponse = await GetResponse("/schedule/games/?sportId=1&date=" + date.ToString("MM/dd/yyyy"));

            GameScheduleRoot? gameSchedule = JsonSerializer.Deserialize<GameScheduleRoot>(jsonResponse);

            foreach (DTO.GameSchedule.Date? item in (gameSchedule ?? new GameScheduleRoot()).dates ?? new DTO.GameSchedule.Date[0])
            {
                foreach (DTO.GameSchedule.Game? game in item.games ?? new DTO.GameSchedule.Game[0])
                {
                    upcomingGames.Add(new Models.Schedule()
                    {
                        gameID = game.gamePk,
                        AwayTeam = game?.teams?.away?.team?.name,
                        HomeTeam = game?.teams?.home?.team?.name,
                        ScheduledInnings = game?.scheduledInnings
                    });
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

            string jsonResponse = await GetResponse("/schedule?sportId=1&hydrate=probablePitcher(note)" +
                "&fields=dates,date,games,gamePk,gameDate,status,abstractGameState," +
                "teams,away,home,team,id,name,probablePitcher,id,fullName,note&" + date.ToString("MM/dd/yyyy"));

            PitchingReportDto? reports = JsonSerializer.Deserialize<PitchingReportDto>(jsonResponse);

            foreach (var selectedDate in (reports ?? new PitchingReportDto()).dates ?? new DTO.PitchingReport.Date[0])
            {
                foreach (var game in (selectedDate ?? new DTO.PitchingReport.Date()).games ?? new DTO.PitchingReport.Game[0])
                {
                    pitchingReports.Add(new PitchingReport()
                    {
                        HomeTeam = game?.teams?.home?.team?.name,
                        AwayTeam = game?.teams?.away?.team?.name,
                        AwayProbablePitcherId = game?.teams?.away?.probablePitcher?.id,
                        AwayProbablePitcherName = game?.teams?.away?.probablePitcher?.fullName,
                        AwayProbablePitcherNotes = game?.teams?.away?.probablePitcher?.note,
                        HomeProbablePitcherId = game?.teams?.home?.probablePitcher?.id,
                        HomeProbablePitcherName = game?.teams?.home?.probablePitcher?.fullName,
                        HomeProbablePitcherNotes = game?.teams?.home?.probablePitcher?.note
                    });
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

            string jsonResponse = await GetResponse("/teams?sportId=1");

            TeamDto? mlbTeams = JsonSerializer.Deserialize<TeamDto>(jsonResponse);

            foreach (var team in (mlbTeams ?? new TeamDto()).teams ?? new DTO.Teams.Team[0])
            {
                teamsList.Add(new Models.Team()
                {
                    Name = team?.name,
                    Location = team?.locationName,
                    Id = team?.id,
                    LeagueId = team?.league?.id,
                    LeagueName = team?.league?.name,
                    DivisionName = team?.division?.name,
                    DivisionId = team?.division?.id,
                    Abbreviation = team?.abbreviation,
                    VenueName = team?.venue?.name,
                    VenueId = team?.venue?.id
                });
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

            string jsonResponse = await GetResponse(type_string);

            TeamRosterDto? teamRostersJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

            foreach (var item in (teamRostersJson ?? new TeamRosterDto()).roster ?? new Roster[0])
            {
                teamRosters.Add(new TeamRoster()
                {
                    PlayerId = item?.person?.id,
                    PlayerFullName = item?.person?.fullName,
                    PlayerPosition = item?.position?.name,
                    PlayerType = item?.position?.type,
                    PositionCode = item?.position?.code,
                    TeamId = teamRostersJson?.teamId,
                    PositionAbbreviation = item?.position?.abbreviation,
                    StatusCode = item?.status?.code,
                    StatusDescription = item?.status?.description
                }
                );
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

            string jsonResponse = await GetResponse("/game/" + gameId + "/linescore");

            LinescoreDto? lineScoresJson = JsonSerializer.Deserialize<LinescoreDto>(jsonResponse);

            foreach (var inning in (lineScoresJson ?? new LinescoreDto()).innings ?? new List<Innings>())
            {
                lineScores.Add(new Linescore()
                {
                    CurrentInning = lineScoresJson?.currentInning,
                    InningHalf = lineScoresJson?.inningHalf,
                    ScheduledInnings = lineScoresJson?.scheduledInnings,
                    HometeamRuns = lineScoresJson?.teams?.home?.runs,
                    HometeamHits = lineScoresJson?.teams?.home?.hits,
                    HometeamErrors = lineScoresJson?.teams?.home?.errors,
                    AwayteamRuns = lineScoresJson?.teams?.away?.runs,
                    AwayteamHits = lineScoresJson?.teams?.away?.hits,
                    AwayteamErrors = lineScoresJson?.teams?.away?.errors,
                    InningNumber = inning?.num,
                    DefensivePitcherId = lineScoresJson?.defense?.pitcher?.id,
                    DefensePitcherName = lineScoresJson?.defense?.pitcher?.fullName,
                    CatcherName = lineScoresJson?.defense?.catcher?.fullName,
                    CatcherId = lineScoresJson?.defense?.catcher?.id,
                    FirstBasemanName = lineScoresJson?.defense?.first?.fullName,
                    FirstBasemanId = lineScoresJson?.defense?.first?.id,
                    SecondBasemanName = lineScoresJson?.defense?.second?.fullName,
                    SecondBasemanId = lineScoresJson?.defense?.second?.id,
                    ThirdBasemanName = lineScoresJson?.defense?.third?.fullName,
                    ThirdBasemanId = lineScoresJson?.defense?.third?.id,
                    ShortstopName = lineScoresJson?.defense?.shortstop?.fullName,
                    ShortstopId = lineScoresJson?.defense?.shortstop?.id,
                    LeftFielderName = lineScoresJson?.defense?.left?.fullName,
                    LeftFielderId = lineScoresJson?.defense?.left?.id,
                    CenterFielderName = lineScoresJson?.defense?.center?.fullName,
                    CenterFielderId = lineScoresJson?.defense?.center?.id,
                    RightFielderName = lineScoresJson?.defense?.right?.fullName,
                    RightFielderId = lineScoresJson?.defense?.right?.id,
                    DefensiveBatterName = lineScoresJson?.defense?.batter?.fullName,
                    DefensiveBatterId = lineScoresJson?.defense?.batter?.id,
                    DefensiveOnDeck = lineScoresJson?.defense?.onDeck?.fullName,
                    DefensiveOnDeckId = lineScoresJson?.defense?.onDeck?.id,
                    DefensiveInHole = lineScoresJson?.defense?.inHole?.fullName,
                    DefensiveInHoleId = lineScoresJson?.defense?.inHole?.id,
                    DefensiveTeamName = lineScoresJson?.defense?.team?.name,
                    DefensiveTeamId = lineScoresJson?.defense?.team?.id,
                    OffensiveTeamBatterName = lineScoresJson?.offense?.batter?.fullName,
                    OffensiveTeamBatterId = lineScoresJson?.offense?.batter?.id,
                    OffensiveTeamOnDeckName = lineScoresJson?.offense?.onDeck?.fullName,
                    OffensiveTeamOnDeckId = lineScoresJson?.offense?.onDeck?.id,
                    OffensiveTeamInHoleName = lineScoresJson?.offense?.inHole?.fullName,
                    OffensiveTeamInHoleId = lineScoresJson?.offense?.inHole?.id
                });
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

            string jsonResponse = await GetResponse("/teams/" + teamId + "/roster/depthChart");

            TeamRosterDto? depthChartJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

            foreach (var person in (depthChartJson ?? new TeamRosterDto()).roster ?? new Roster[0])
            {
                depthCharts.Add(new DepthChart()
                {
                    TeamId = depthChartJson?.teamId,
                    RosterType = depthChartJson?.rosterType,
                    PlayerId = person?.person?.id,
                    PlayerFullName = person?.person?.fullName,
                    JerseyNumber = person?.jerseyNumber,
                    PositionCode = person?.position?.code,
                    PositionName = person?.position?.name,
                    PositionType = person?.position?.type,
                    PositionAbbrevition = person?.position?.abbreviation,
                    StatusCode = person?.status?.code,
                    StatusDescription = person?.status?.description
                });
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

            string jsonResponse = await GetResponse("/divisions?sportId=1");

            DivisionsDto? teamDivisions = JsonSerializer.Deserialize<DivisionsDto>(jsonResponse);

            foreach (LeagueDivision? division in (teamDivisions ?? new DivisionsDto()).divisions ?? new LeagueDivision[0])
            {
                divisions.Add(new Models.Division()
                {
                    DivisionId = division?.id,
                    DivisionName = division?.name,
                    ShortDivisionName = division?.nameShort,
                    DivisionAbbreviation = division?.abbreviation,
                    LeagueId = division?.league?.id
                });
            }

            return divisions;
        }
    }
}