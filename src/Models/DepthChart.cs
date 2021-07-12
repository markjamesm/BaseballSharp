namespace BaseballSharp.Models
{
    public class DepthChart
    {
        /// <summary>
        /// The team's ID number. Useful for building other calls.
        /// </summary>
        public int? TeamId { get; set; }

        /// <summary>
        /// The roster type. 
        /// </summary>
        public string? RosterType { get; set; }

        /// <summary>
        /// The player's ID number. Useful for building other calls.
        /// </summary>
        public int? PlayerId { get; set; }

        /// <summary>
        /// Full name of the player.
        /// </summary>
        public string? PlayerFullName { get; set; }
        public string? JerseyNumber { get; set; }
        public string? PositionCode { get; set; }

        /// <summary>
        /// Name of the position held by the player, eg: "Pitcher".
        /// </summary>
        public string? PositionName { get; set; }
        public string? PositionType { get; set; }
        public string? PositionAbbrevition { get; set; }
        public string? StatusCode { get; set; }

        /// <summary>
        /// A description of the player's status, eg: "Active".
        /// </summary>
        public string? StatusDescription { get; set; }


    }
}
