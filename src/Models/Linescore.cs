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
        /// The number of innings scheduled for the game..
        /// </summary>
        public int? ScheduledInnings { get; protected set; }

        /// <summary>
        /// The number of runs for the home team.
        /// </summary>
        public int? HometeamRuns { get; protected set; }

        /// <summary>
        /// The number of hits for the home team.
        /// </summary>
        public int? HometeamHits { get; protected set; }

        /// <summary>
        /// The number of errors for the home team.
        /// </summary>
        public int? HometeamErrors { get; protected set; }

        /// <summary>
        /// The number of runs for the away team.
        /// </summary>
        public int? AwayteamRuns { get; protected set; }

        /// <summary>
        /// The number of hits for the away.
        /// </summary>
        public int? AwayteamHits { get; protected set; }

        /// <summary>
        /// The number of errors for the home team.
        /// </summary>
        public int? AwayteamErrors { get; protected set; }

        /// <summary>
        /// The inning number.
        /// </summary>
        public int? InningNumber { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? DefensivePitcherId { get; protected set; }

        /// <summary>
        /// The defensive pitcher's name.
        /// </summary>
        public string? PitcherName { get; protected set; }

        /// <summary>
        /// The catcher's name.
        /// </summary>
        public string? CatcherName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? FirstBasemanName { get; protected set; }

        /// <summary>
        /// The name of the second baseman.
        /// </summary>
        public string? SecondBasemanName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? ThirdBasemanName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? ShortstopName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? LeftFielderName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? CenterFielderName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? RightFielderName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? DefensiveBatterName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? DefensiveOnDeck { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? DefensiveInHole { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? DefensiveTeamName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public int? DefensiveTeamId { get; protected set; }
    }
}
