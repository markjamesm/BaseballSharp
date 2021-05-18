using System;
using System.Collections.Generic;

namespace MLBSharp.DTO.GameSchedule
{
    public class ScheduleDto
    {
        public string copyright { get; set; }
        public int totalItems { get; set; }
        public int totalEvents { get; set; }
        public int totalGames { get; set; }
        public int totalGamesInProgress { get; set; }
        public List<Date> dates { get; set; }
    }

    public class Date
    {
        public string date { get; set; }
        public int totalItems { get; set; }
        public int totalEvents { get; set; }
        public int totalGames { get; set; }
        public int totalGamesInProgress { get; set; }
        public Game[] games { get; set; }
        public object[] events { get; set; }
    }

    public class Game
    {
        public int gamePk { get; set; }
        public string link { get; set; }
        public string gameType { get; set; }
        public string season { get; set; }
        public DateTime gameDate { get; set; }
        public string officialDate { get; set; }
        public Status status { get; set; }
        public Teams teams { get; set; }
        public Venue venue { get; set; }
        public Content content { get; set; }
        public int gameNumber { get; set; }
        public bool publicFacing { get; set; }
        public string doubleHeader { get; set; }
        public string gamedayType { get; set; }
        public string tiebreaker { get; set; }
        public string calendarEventID { get; set; }
        public string seasonDisplay { get; set; }
        public string dayNight { get; set; }
        public int scheduledInnings { get; set; }
        public bool reverseHomeAwayStatus { get; set; }
        public int inningBreakLength { get; set; }
        public int gamesInSeries { get; set; }
        public int seriesGameNumber { get; set; }
        public string seriesDescription { get; set; }
        public string recordSource { get; set; }
        public string ifNecessary { get; set; }
        public string ifNecessaryDescription { get; set; }
    }

    public class Status
    {
        public string abstractGameState { get; set; }
        public string codedGameState { get; set; }
        public string detailedState { get; set; }
        public string statusCode { get; set; }
        public bool startTimeTBD { get; set; }
        public string abstractGameCode { get; set; }
    }

    public class Teams
    {
        public Away away { get; set; }
        public Home home { get; set; }
    }

    public class Away
    {
        public Leaguerecord leagueRecord { get; set; }
        public Team team { get; set; }
        public bool splitSquad { get; set; }
        public int seriesNumber { get; set; }
    }

    public class Leaguerecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string pct { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Home
    {
        public Leaguerecord1 leagueRecord { get; set; }
        public Team1 team { get; set; }
        public bool splitSquad { get; set; }
        public int seriesNumber { get; set; }
    }

    public class Leaguerecord1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string pct { get; set; }
    }

    public class Team1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Venue
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Content
    {
        public string link { get; set; }
    }

}