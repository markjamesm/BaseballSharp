namespace BaseballSharp.Models
{
    public class TeamRoster
    {
        /// <summary>
        /// The player's ID number. Useful for building other calls."
        /// </summary>
        public int? PlayerId { get; protected set; }

        /// <summary>
        /// The player's full name. eg: "Mike Trout"
        /// </summary>
        public string? PlayerFullName { get; protected set; }

        /// <summary>
        /// The player's position name (eg: "Pitcher").
        /// </summary>
        public string? PlayerPosition { get; protected set; }

        /// <summary>
        /// The player type (eg: "Pitcher").
        /// </summary>
        public string? PlayerType { get; protected set; }

        /// <summary>
        /// The code for the position (eg: 1).
        /// </summary>
        public string? PositionCode { get; protected set; }

        /// <summary>
        /// The team's ID number. Useful for building other calls."
        /// </summary>
        public int? TeamId { get; protected set; }

        /// <summary>
        /// Abbreviated form of the positin (eg: "P" for Pitcher).
        /// </summary>
        public string? PositionAbbreviation { get; protected set; }

        public string? StatusCode { get; protected set; }

        public string? StatusDescription { get; protected set; }


        public TeamRoster(int? playerId, string? playerFullName, 
            string? playerPosition, string? playerType, string? positionCode, 
            int? teamId, string? positionAbbreviation, 
            string? statusCode, string statusDescription)
        {
            PlayerId = playerId;
            PlayerFullName = playerFullName;
            PlayerPosition = playerPosition;
            PlayerType = playerType;
            PositionCode = positionCode;
            TeamId = teamId;
            PositionAbbreviation = positionAbbreviation;
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

    }
}
