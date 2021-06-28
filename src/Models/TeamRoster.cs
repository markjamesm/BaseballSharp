namespace BaseballSharp.Models
{
    public class TeamRoster
    {
        /// <summary>
        /// The player's ID number. Useful for building other calls."
        /// </summary>
        public int? PlayerId { get; set; }

        /// <summary>
        /// The player's full name. eg: "Mike Trout"
        /// </summary>
        public string? PlayerFullName { get; set; }

        /// <summary>
        /// The player's position name (eg: "Pitcher").
        /// </summary>
        public string? PlayerPosition { get; set; }

        /// <summary>
        /// The player type (eg: "Pitcher").
        /// </summary>
        public string? PlayerType { get; set; }

        /// <summary>
        /// The code for the position (eg: 1).
        /// </summary>
        public string? PositionCode { get; set; }

        /// <summary>
        /// The team's ID number. Useful for building other calls."
        /// </summary>
        public int? TeamId { get; set; }

        /// <summary>
        /// Abbreviated form of the positin (eg: "P" for Pitcher).
        /// </summary>
        public string? PositionAbbreviation { get; set; }

        public string? StatusCode { get; set; }

        public string? StatusDescription { get; set; }
    }
}
