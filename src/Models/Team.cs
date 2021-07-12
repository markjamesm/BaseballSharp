namespace BaseballSharp.Models
{
    public class Team
    {
        /// <summary>
        /// The team's full name. eg: "Toronto Blue Jays".
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// The team's name (eg: "Jays").
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Team hometown.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Team ID from the API (used for building other calls).
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The name of the league that the team plays in.
        /// </summary>
        public string? LeagueName { get; set; }

        /// <summary>
        /// The league ID (used for building other league calls).
        /// </summary>
        public int? LeagueId { get; set; }

        /// <summary>
        /// The name of the team's division, (eg. "American League West).
        /// </summary>
        public string? DivisionName { get; set; }

        /// <summary>
        /// Division ID from the API (used for building other calls).
        /// </summary>
        public int? DivisionId { get; set; }
        public string? Abbreviation { get; set; } 
        public string? VenueName { get; set; }
        public int? VenueId { get; set; }
    }
}
