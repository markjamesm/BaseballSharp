namespace MLBSharp.Models
{
    public class UpcomingGames
    {
        public string HomeTeam { get; private set; }
        public string AwayTeam { get; private set; }
        public string Ballpark { get; private set; }
        public int ScheduledInnings { get; private set; }

        public UpcomingGames(string homeTeam, string awayTeam, string ballpark, int scheduledInnings)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Ballpark = ballpark;
            ScheduledInnings = scheduledInnings;
        }
    }
}
