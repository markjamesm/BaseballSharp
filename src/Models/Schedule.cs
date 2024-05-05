namespace BaseballSharp.Models;

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

    /// <summary>
    /// The status of the game.  Some possible codes are "F" for Final, "I" for In Progress, 
    /// "IR" for Delayed, "P" for Pre-game, and "S" for Sceduled.
    /// </summary>
    public string? StatusCode { get; set; }
}