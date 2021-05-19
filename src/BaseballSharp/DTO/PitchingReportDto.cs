using System;

namespace BaseballSharp.DTO.PitchingReport
{

    public class PitchingReportDto
    {
        public Date[] dates { get; set; }
    }

    public class Date
    {
        public string date { get; set; }
        public Game[] games { get; set; }
    }

    public class Game
    {
        public int gamePk { get; set; }
        public DateTime gameDate { get; set; }
        public Status status { get; set; }
        public Teams teams { get; set; }
    }

    public class Status
    {
        public string abstractGameState { get; set; }
    }

    public class Teams
    {
        public Away away { get; set; }
        public Home home { get; set; }
    }

    public class Away
    {
        public Team team { get; set; }
        public Probablepitcher probablePitcher { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Probablepitcher
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string note { get; set; }
    }

    public class Home
    {
        public Team1 team { get; set; }
        public Probablepitcher1 probablePitcher { get; set; }
    }

    public class Team1
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Probablepitcher1
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string note { get; set; }
    }

}
