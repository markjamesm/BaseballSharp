namespace BaseballSharp.Models
{
    public class DepthChart
    {
        /// <summary>
        /// The team's ID number. Useful for building other calls.
        /// </summary>
        public int? TeamId { get; protected set; }

        /// <summary>
        /// The roster type. 
        /// </summary>
        public string? RosterType { get; protected set; }

        /// <summary>
        /// The player's ID number. Useful for building other calls.
        /// </summary>
        public int? PlayerId { get; protected set; }

        /// <summary>
        /// Full name of the player.
        /// </summary>
        public string? PlayerFullName { get; protected set; }
        public string? JerseyNumber { get; protected set; }
        public string? PositionCode { get; protected set; }

        /// <summary>
        /// Name of the position held by the player, eg: "Pitcher".
        /// </summary>
        public string? PositionName { get; protected set; }
        public string? PositionType { get; protected set; }
        public string? PositionAbbrevition { get; protected set; }
        public string? StatusCode { get; protected set; }

        /// <summary>
        /// A description of the player's status, eg: "Active".
        /// </summary>
        public string? StatusDescription { get; protected set; }

        /// <summary>
        /// DepthChart class constructor.
        /// </summary>
        public DepthChart(int? teamId, string? rosterType, int? playerId, 
            string? playerFullName, string? jerseyNumber, string? positionCode, 
            string? positionName, string? positionType, string? positionAbbreviation,
            string? statusCode, string? statusDescription)
        {
            TeamId = teamId;
            RosterType = rosterType;
            PlayerId = playerId;
            PlayerFullName = playerFullName;
            JerseyNumber = jerseyNumber;
            PositionCode = positionCode;
            PositionName = positionName;
            PositionType = positionType;
            PositionAbbrevition = positionAbbreviation;
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

    }
}
