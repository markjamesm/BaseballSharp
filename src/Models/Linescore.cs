namespace BaseballSharp.Models;

public class Linescore
{
    /// <summary>
    /// The current inning of play.
    /// </summary>
    public int? CurrentInning { get; set; }

    /// <summary>
    /// Whether or not its the bottom or top of the inning.
    /// </summary>
    public string? InningHalf { get; set; }

    /// <summary>
    /// The number of innings scheduled for the game..
    /// </summary>
    public int? ScheduledInnings { get; set; }

    /// <summary>
    /// The number of runs for the home team.
    /// </summary>
    public int? HometeamRuns { get; set; }

    /// <summary>
    /// The number of hits for the home team.
    /// </summary>
    public int? HometeamHits { get; set; }

    /// <summary>
    /// The number of errors for the home team.
    /// </summary>
    public int? HometeamErrors { get; set; }

    /// <summary>
    /// The number of runs for the away team.
    /// </summary>
    public int? AwayteamRuns { get; set; }

    /// <summary>
    /// The number of hits for the away.
    /// </summary>
    public int? AwayteamHits { get; set; }

    /// <summary>
    /// The number of errors for the home team.
    /// </summary>
    public int? AwayteamErrors { get; set; }

    /// <summary>
    /// The inning number.
    /// </summary>
    public int? InningNumber { get; set; }

    /// <summary>
    /// The ID of the defensive pitcher.
    /// </summary>
    public int? DefensivePitcherId { get; set; }

    /// <summary>
    /// The defensive pitcher's name.
    /// </summary>
    public string? DefensePitcherName { get; set; }

    /// <summary>
    /// The catcher's name.
    /// </summary>
    public string? CatcherName { get; set; }

    /// <summary>
    /// The ID of the catcher.
    /// </summary>
    public int? CatcherId { get; set; }

    /// <summary>
    /// The name of the first baseman.
    /// </summary>
    public string? FirstBasemanName { get; set; }

    /// <summary>
    /// The ID of the first baseman.
    /// </summary>
    public int? FirstBasemanId { get; set; }

    /// <summary>
    /// The name of the second baseman.
    /// </summary>
    public string? SecondBasemanName { get; set; }

    /// <summary>
    /// The ID of the second baseman.
    /// </summary>
    public int? SecondBasemanId { get; set; }

    /// <summary>
    /// The name of the third baseman.
    /// </summary>
    public string? ThirdBasemanName { get; set; }

    /// <summary>
    /// The ID of the third baseman.
    /// </summary>
    public int? ThirdBasemanId { get; set; }

    /// <summary>
    /// The name of the shortstop.
    /// </summary>
    public string? ShortstopName { get; set; }

    /// <summary>
    /// The ID number of the shortstop.
    /// </summary>
    public int? ShortstopId { get; set; }

    /// <summary>
    /// The name of the left fielder.
    /// </summary>
    public string? LeftFielderName { get; set; }

    /// <summary>
    /// The ID of the left fielder.
    /// </summary>
    public int? LeftFielderId { get; set; }

    /// <summary>
    /// The name of the center fielder.
    /// </summary>
    public string? CenterFielderName { get; set; }

    /// <summary>
    /// The ID of the center fielder.
    /// </summary>
    public int? CenterFielderId { get; set; }

    /// <summary>
    /// The name of the right fielder.
    /// </summary>
    public string? RightFielderName { get; set; }

    /// <summary>
    /// The ID of the right fielder.
    /// </summary>
    public int? RightFielderId { get; set; }

    /// <summary>
    /// The name of the defensive batter.
    /// </summary>
    public string? DefensiveBatterName { get; set; }

    /// <summary>
    /// The ID of the defensive batter.
    /// </summary>
    public int? DefensiveBatterId { get; set; }

    /// <summary>
    /// The name of the defensive on deck player.
    /// </summary>
    public string? DefensiveOnDeck { get; set; }

    /// <summary>
    /// The ID of the defensive on deck player.
    /// </summary>
    public int? DefensiveOnDeckId { get; set; }

    /// <summary>
    /// The name of defensive player in the hole.
    /// </summary>
    public string? DefensiveInHole { get; set; }

    /// <summary>
    /// The ID number of the defensive player in the hole.
    /// </summary>
    public int? DefensiveInHoleId { get; set; }

    /// <summary>
    /// The name of the defensive team.
    /// </summary>
    public string? DefensiveTeamName { get; set; }

    /// <summary>
    /// The id number of the defending team.
    /// </summary>
    public int? DefensiveTeamId { get; set; }

    /// <summary>
    /// The batter id number for the offensive team player.
    /// </summary>
    public int? OffensiveTeamBatterId { get; set; }

    /// <summary>
    /// The name of the current offensive batter.
    /// </summary>
    public string? OffensiveTeamBatterName { get; set; }

    /// <summary>
    /// The name of the offensive player on deck.
    /// </summary>
    public string? OffensiveTeamOnDeckName { get; set; }

    /// <summary>
    /// The on deck player id for the offensive team.
    /// </summary>
    public int? OffensiveTeamOnDeckId { get; set; }

    /// <summary>
    /// The name of the player in hole on the offensive team.
    /// </summary>
    public string? OffensiveTeamInHoleName { get; set; }

    /// <summary>
    /// The Id number for the in hole on the offensive team 
    /// </summary>
    public int? OffensiveTeamInHoleId { get; set; }

    /// <summary>
    /// The offensive team pitcher name.
    /// </summary>
    public string? OffensiveTeamPitcherName { get; set; }

    /// <summary>
    /// The Id number for the offensive team pitcher.
    /// </summary>
    public int? OffensiveTeamPitcherId { get; set; }

    /// <summary>
    /// The offensive team name.
    /// </summary>
    public string? OffensiveTeamName { get; set; }
}