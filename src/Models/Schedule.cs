using BaseballSharp.Enums;

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
    /// The status of the game.  A few possible codes are "F" for Final, "I" for In Progress, 
    /// "IR" for Delayed, "P" for Pre-game, and "S" for Sceduled.
    /// </summary>
    public GameStatus? StatusCode { get; set; }

    /// <summary>
    /// Gets the GameStatus enum value based on the provided status code string.
    /// </summary>
    /// <param name="statusCode">The status code string.</param>
    /// <returns>The corresponding GameStatus enum value, or null if the status code is unknown.</returns>
    public static GameStatus? GetStatusCode(string? statusCode)
    {
        return statusCode switch
        {
            "F" => GameStatus.Final,
            "I" => GameStatus.InProgress,
            "IR" => GameStatus.Delayed,
            "P" => GameStatus.PreGame,
            "S" => GameStatus.Scheduled,
            _ => null,
        };
    }
}