namespace BaseballSharp.Models
{
    public class Schedule
    {
        public int? gameID { get; set; }
        public string? HomeTeam { get; set; }
        public string? AwayTeam { get; set; }

        /// <summary>
        /// The stadium that the team is playing at.
        /// </summary>
        public string? Ballpark { get; set; }

        /// <summary>
        /// The number of innings scheduled for the game. 
        /// </summary>
        public int? ScheduledInnings { get; set; }
    }
}
