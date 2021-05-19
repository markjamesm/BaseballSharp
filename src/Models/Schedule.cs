namespace BaseballSharp.Models
{
    public class Schedule
    {
        public string? HomeTeam { get; protected set; }
        public string? AwayTeam { get; protected set; }
        public string? Ballpark { get; protected set; }
        public int? ScheduledInnings { get; protected set; }

        public Schedule(string? homeTeam, string? awayTeam, string? ballpark, int? scheduledInnings)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Ballpark = ballpark;
            ScheduledInnings = scheduledInnings;
        }
    }
}
