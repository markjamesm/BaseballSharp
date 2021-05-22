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
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? CatcherId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? FirstBasemanName { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? FirstBasemanId { get; protected set; }

        /// <summary>
        /// The name of the second baseman.
        /// </summary>
        public string? SecondBasemanName { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? SecondBasemanId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? ThirdBasemanName { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? ThirdBasemanId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? ShortstopName { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? ShortstopId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? LeftFielderName { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? LeftFielderId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? CenterFielderName { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? CenterFielderId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? RightFielderName { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? RightFielderId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? DefensiveBatterName { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? DefensiveBatterId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? DefensiveOnDeck { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? DefensiveOnDeckId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? DefensiveInHole { get; protected set; }

        /// <summary>
        /// The ID of the defensive pitcher.
        /// </summary>
        public int? DefensiveInHoleId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? DefensiveTeamName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public int? DefensiveTeamId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public int? OffensiveTeamBatterId { get; protected set; }

        /// <summary>
        /// The name of the current offensive batter.
        /// </summary>
        public string? OffensiveTeamBatterName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? OffensiveTeamOnDeckName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public int? OffensiveTeamOnDeckId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? OffensiveTeamInHoleName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public int? OffensiveTeamInHoleId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? OffensiveTeamPitcherName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public int? OffensiveTeamPitcherId { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public string? OffensiveTeamName { get; protected set; }

        /// <summary>
        /// The name of the third baseman.
        /// </summary>
        public int? OffensiveTeamId { get; protected set; }

        public Linescore(int? currentInning,
            string? inningHalf,
            int? scheduledInnings,
            int? hometeamRuns,
            int? hometeamHits,
            int? hometeamErrors,
            int? awayteamRuns,
            int? awayteamHits,
            int? awayteamErrors,
            int? inningNumber,
            int? defensivePitcherId,
            string? pitcherName,
            string? catcherName,
            int? catcherId,
            string? firstBasemanName,
            int? firstBasemanId,
            string? secondBasemanName,
            int? secondBasemanId,
            string? thirdBasemanName,
            int? thirdBasemanId,
            string? shortstopName,
            int? shortstopId,
            string? leftFielderName,
            int? leftFielderId,
            string? centerFielderName,
            int? centerFielderId,
            string? rightFielderName,
            int? rightFielderId,
            string? defensiveBatterName,
            int? defensiveBatterId,
            string? defensiveOnDeck,
            int? defensiveOnDeckId,
            string? defensiveInHole,
            int? defensiveInHoleId,
            string? defensiveTeamName,
            int? defensiveTeamId,
            string? offensiveTeamBatterName,
            int? offensiveTeamBatterId,
            string? offensiveTeamOnDeckName,
            int? offensiveTeamOnDeckId,
            string? offensiveTeamInHoleName,
            int? offensiveTeamInHoleId)
        {
            InningHalf = inningHalf;
            ScheduledInnings = scheduledInnings;
            HometeamRuns = hometeamRuns;
            HometeamHits = hometeamHits;
            HometeamErrors = hometeamErrors;
            AwayteamRuns = awayteamRuns;
            AwayteamHits = awayteamHits;
            AwayteamErrors = awayteamErrors;
            InningNumber = inningNumber;
            DefensivePitcherId = defensivePitcherId;
            PitcherName = pitcherName;
            CatcherName = catcherName;
            CatcherId = catcherId;
            FirstBasemanName = firstBasemanName;
            FirstBasemanId = firstBasemanId;
            SecondBasemanName = secondBasemanName;
            SecondBasemanId = secondBasemanId;
            ThirdBasemanName = thirdBasemanName;
            ThirdBasemanId = thirdBasemanId;
            ShortstopName = shortstopName;
            ShortstopId = shortstopId;
            LeftFielderName = leftFielderName;
            LeftFielderId = leftFielderId;
            CenterFielderName = centerFielderName;
            CenterFielderId = centerFielderId;
            RightFielderName = rightFielderName;
            RightFielderId = rightFielderId;
            DefensiveBatterName = defensiveBatterName;
            DefensiveBatterId = defensiveBatterId;
            DefensiveOnDeck = defensiveOnDeck;
            DefensiveOnDeckId = defensiveOnDeckId;
            DefensiveInHole = defensiveInHole;
            DefensiveInHoleId = defensiveInHoleId;
            DefensiveTeamName = defensiveTeamName;
            DefensiveTeamId = defensiveTeamId;
            OffensiveTeamBatterName = offensiveTeamBatterName;
            OffensiveTeamBatterId = offensiveTeamBatterId;
            OffensiveTeamOnDeckName = offensiveTeamOnDeckName;
            OffensiveTeamOnDeckId = offensiveTeamOnDeckId;
            OffensiveTeamInHoleName = offensiveTeamInHoleName;
            OffensiveTeamInHoleId = offensiveTeamInHoleId;
        }
    }
}
