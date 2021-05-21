namespace BaseballSharp.Models
{
    class Linescore
    {
        /// <summary>
        /// The current inning of play.
        /// </summary>
        public int? CurrentInning { get; protected set; }

        /// <summary>
        /// Whether or not its the bottom or top of the inning.
        /// </summary>
        public string? InningHalf { get; protected set; }

        /// <summary>
        /// The number of innings scheduled for the game.
        /// </summary>
        public int? ScheduledInnings { get; protected set; }

        /// <summary>
        /// The number of runs for the home team
        /// </summary>
        public int? HometeamRuns { get; protected set; }

        /// <summary>
        /// The number of hits for the hometeam
        /// </summary>
        public int? HometeamHits { get; protected set; }

        /// <summary>
        /// The number of errors for the home team
        /// </summary>
        public int? HometeamErrors { get; protected set; }
    }
}
