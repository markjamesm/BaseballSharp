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
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Team = BaseballSharp.DTO.Teams.Team;

[assembly: InternalsVisibleTo("BaseballSharp.Test")]

namespace BaseballSharp
{
    /// <summary>
    /// The MLBClient class holds all MLB Stats API endpoints that can be accessed from Baseball Sharp.
    /// </summary>
    public class MLBClient : IMLBClient
    {
        private HttpClient _httpClient = new HttpClient();
        private static readonly string _baseUrl = "https://statsapi.mlb.com/api/v1";
        private static readonly short _outsInCompletedInning = 3;

        internal HttpClient HttpClient
        {
            set 
            {
                _httpClient = value;
            }
        }

        private async Task<string> GetResponseAsync(string endpoint)
        {

            var returnMessage = await _httpClient.GetAsync(_baseUrl + (endpoint ?? "")).ConfigureAwait(false);

            return await returnMessage.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Returns a list of the matchups and ballpark for the specified date.
        /// </summary>
        /// <param name="date">The date to return data for.</param>
        /// <returns>A list of schedule objects.</returns>
        public async Task<IEnumerable<Schedule>> GetScheduleAsync(DateTime date)
        {
            var upcomingGames = new List<Schedule>();

            var jsonResponse = await GetResponseAsync("/schedule/games/?sportId=1&date=" + date.ToString("MM/dd/yyyy"));
            var gameSchedule = JsonSerializer.Deserialize<GameScheduleRoot>(jsonResponse);

            foreach (var item in (gameSchedule ?? new GameScheduleRoot()).dates)
            {
                foreach (var game in item.games)
                {
                    upcomingGames.Add(new Models.Schedule()
                    {
                        gameID = game.gamePk,
                        AwayTeam = game.teams?.away?.team?.name,
                        HomeTeam = game.teams?.home?.team?.name,
                        Ballpark = game.venue?.name,
                        ScheduledInnings = game.scheduledInnings,
                        StatusCode = Schedule.GetStatusCode(game.status?.statusCode)
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
        public async Task<IEnumerable<PitchingReport>> GetPitchingReportsAsync(DateTime date)
        {
            var pitchingReports = new List<PitchingReport>();

            var jsonResponse = await GetResponseAsync("/schedule?sportId=1&hydrate=probablePitcher(note)" +
                "&fields=dates,date,games,gamePk,gameDate,status,abstractGameState," +
                "teams,away,home,team,id,name,probablePitcher,id,fullName,note&" + date.ToString("MM/dd/yyyy"));
            var reports = JsonSerializer.Deserialize<PitchingReportDto>(jsonResponse);

            foreach (var selectedDate in (reports ?? new PitchingReportDto()).dates ?? Array.Empty<DTO.PitchingReport.Date>())
            {
                foreach (var game in selectedDate.games ?? Array.Empty<DTO.PitchingReport.Game>())
                {
                    pitchingReports.Add(new PitchingReport()
                    {
                        HomeTeam = game.teams?.home?.team?.name,
                        AwayTeam = game.teams?.away?.team?.name,
                        AwayProbablePitcherId = game.teams?.away?.probablePitcher?.id,
                        AwayProbablePitcherName = game.teams?.away?.probablePitcher?.fullName,
                        AwayProbablePitcherNotes = game.teams?.away?.probablePitcher?.note,
                        HomeProbablePitcherId = game.teams?.home?.probablePitcher?.id,
                        HomeProbablePitcherName = game.teams?.home?.probablePitcher?.fullName,
                        HomeProbablePitcherNotes = game.teams?.home?.probablePitcher?.note
                    });
                }
            }

            return pitchingReports;
        }

        /// <summary>
        /// Returns a list of all MLB teams and some associated data. The ID parameters can be used to build other queries.
        /// </summary>
        /// <returns>A list of team objects.</returns>
        public async Task<IEnumerable<Models.Team>> GetTeamDataAsync()
        {
            var teamsList = new List<Models.Team>();

            var jsonResponse = await GetResponseAsync("/teams?sportId=1");
            var mlbTeams = JsonSerializer.Deserialize<TeamDto>(jsonResponse);

            foreach (var team in (mlbTeams ?? new TeamDto()).teams ?? Array.Empty<Team>())
            {
                teamsList.Add(new Models.Team()
                {
                    Name = team.name,
                    Location = team.locationName,
                    Id = team.id,
                    LeagueId = team.league?.id,
                    LeagueName = team.league?.name,
                    DivisionName = team.division?.name,
                    DivisionId = team.division?.id,
                    Abbreviation = team.abbreviation,
                    VenueName = team.venue?.name,
                    VenueId = team.venue?.id
                });
            }

            return teamsList;
        }

        /// <summary>
        /// Returns a list of team roster data for a given season.
        /// Use the GetTeamDataAsync() call to obtain the id numbers needed to satisfy the teamId parameter.
        /// </summary>
        /// <param name="teamId"> The team's MLB id (use enum)</param>
        /// <param name="season"> The year the season begins on</param>
        /// <param name="date"> A date to use, will return the roster as of that date</param>
        /// <param name="roster"> The roster type to return. Can choose either full roster, 25man or 40 man</param>
        /// <returns>An IEnumerable TeamRoster</returns>
        public async Task<IEnumerable<TeamRoster>> GetTeamRosterAsync(int teamId, int season, DateTime date, rosterType roster = rosterType.rosterFull)
        {
            List<TeamRoster> teamRosters = new();

            var typeString = "";

            switch (roster)
            {
                case rosterType.rosterFull:
                    typeString = "/teams/" + teamId + "/roster/fullRoster?season=" + season + "&date=" + date.ToString("MM/dd/yyyy");
                    break;

                case rosterType.roster25:
                    typeString = "/teams/" + teamId + "/roster?season=" + season + "&date=" + date.ToString("MM/dd/yyyy");
                    break;

                case rosterType.roster40:

                    typeString = "/teams/" + teamId + "/roster?season=" + season + "&rosterType=40Man" + "&date=" + date.ToString("MM/dd/yyyy");
                    break;
            }

            var jsonResponse = await GetResponseAsync(typeString);
            var teamRostersJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

            foreach (var item in (teamRostersJson ?? new TeamRosterDto()).roster ?? Array.Empty<Roster>())
            {
                teamRosters.Add(new TeamRoster()
                {
                    PlayerId = item.person?.id,
                    PlayerFullName = item.person?.fullName,
                    PlayerPosition = item.position?.name,
                    PlayerType = item.position?.type,
                    PositionCode = item.position?.code,
                    TeamId = teamRostersJson?.teamId,
                    PositionAbbreviation = item.position?.abbreviation,
                    StatusCode = item.status?.code,
                    StatusDescription = item.status?.description
                });
            }

            return teamRosters;
        }

        /// <summary>
        /// Returns a list of linescore data for the game in question.
        /// </summary>
        /// <returns>A list of Linescore objects.</returns>
        /// <param name="gameId">The ID number of the game.</param>
        /// <returns>A list of Linescore objects</returns>
        public async Task<IEnumerable<Linescore>> GetLineScoreAsync(int gameId)
        {
            var lineScores = new List<Linescore>();

            var jsonResponse = await GetResponseAsync("/game/" + gameId + "/linescore");
            var lineScoresJson = JsonSerializer.Deserialize<LinescoreDto>(jsonResponse);

            foreach (var inning in (lineScoresJson ?? new LinescoreDto()).innings ?? new List<Innings>())
            {
                lineScores.Add(new Linescore()
                {
                    CurrentInning = lineScoresJson?.currentInning,
                    InningHalf = lineScoresJson?.inningHalf,
                    // If it's the last inning, use outs from the dto.  Otherwise, use the number 
                    // of outs in an inning.  In the v1 api, "outs" at the root is the current number
                    // of outs in the current inning; it should not be extrapolated to all innings.
                    Outs = inning?.num == lineScoresJson?.currentInning ? lineScoresJson?.outs : _outsInCompletedInning,
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
        /// Use the GetTeamDataAsync() call to obtain the id numbers needed to satisfy the teamId parameter.
        /// </summary>
        /// <returns>A list of team objects.</returns>
        /// <param name="teamId">The team's ID number.</param>
        /// <returns>A list of pitching report objects</returns>
        public async Task<IEnumerable<DepthChart>> GetDepthChartAsync(int teamId)
        {
            var depthCharts = new List<DepthChart>();

            var jsonResponse = await GetResponseAsync("/teams/" + teamId + "/roster/depthChart");
            var depthChartJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

            foreach (var person in (depthChartJson ?? new TeamRosterDto()).roster ?? Array.Empty<Roster>())
            {
                depthCharts.Add(new DepthChart()
                {
                    TeamId = depthChartJson?.teamId,
                    RosterType = depthChartJson?.rosterType,
                    PlayerId = person.person?.id,
                    PlayerFullName = person.person?.fullName,
                    JerseyNumber = person.jerseyNumber,
                    PositionCode = person.position?.code,
                    PositionName = person.position?.name,
                    PositionType = person.position?.type,
                    PositionAbbrevition = person.position?.abbreviation,
                    StatusCode = person.status?.code,
                    StatusDescription = person.status?.description
                });
            }

            return depthCharts;
        }

        /// <summary>
        /// Endpoint to get the MLB divisions and associated data.
        /// </summary>
        /// <returns>A list of Division objects.</returns>
        public async Task<IEnumerable<Models.Division>> GetDivisionsAsync()
        {
            var divisions = new List<Models.Division>();

            var jsonResponse = await GetResponseAsync("/divisions?sportId=1");
            var teamDivisions = JsonSerializer.Deserialize<DivisionsDto>(jsonResponse);

            foreach (var division in (teamDivisions ?? new DivisionsDto()).divisions)
            {
                divisions.Add(new Models.Division()
                {
                    DivisionId = division.id,
                    DivisionName = division.name,
                    ShortDivisionName = division.nameShort,
                    DivisionAbbreviation = division.abbreviation,
                    LeagueId = division.league?.id
                });
            }

            return divisions;
        }
    }
}