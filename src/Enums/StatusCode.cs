namespace BaseballSharp.Enums;
/// <summary>
/// Represents the status of the game using predefined status codes.  Note that there may be more codes than these -- 
/// these are the status codes observed manually.
/// </summary>
public enum GameStatus
{
    Final,      // "F"
    InProgress, // "I"
    Delayed,    // "IR"
    PreGame,    // "P"
    Scheduled   // "S"
}
