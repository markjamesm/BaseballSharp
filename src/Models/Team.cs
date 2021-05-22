namespace BaseballSharp.Models
{
    public class Team
    {
        /// <summary>
        /// The team's full name. eg: "Toronto Blue Jays".
        /// </summary>
        public string? FullName { get; protected set; }

        /// <summary>
        /// The team's name (eg: "Jays").
        /// </summary>
        public string? Name { get; protected set; }

        /// <summary>
        /// Team hometown.
        /// </summary>
        public string? Location { get; protected set; }

        /// <summary>
        /// Team ID from the API (used for building other calls).
        /// </summary>
        public int? Id { get; protected set; }

        /// <summary>
        /// The name of the league that the team plays in.
        /// </summary>
        public string? LeagueName { get; protected set; }

        /// <summary>
        /// The league ID (used for building other league calls).
        /// </summary>
        public int? LeagueId { get; protected set; }

        /// <summary>
        /// The name of the team's division, (eg. "American League West).
        /// </summary>
        public string? DivisionName { get; protected set; }

        /// <summary>
        /// Division ID from the API (used for building other calls).
        /// </summary>
        public int? DivisionId { get; protected set; }
        public string? Abbreviation { get; protected set; } 
        public string? VenueName { get; protected set; }
        public int? VenueId { get; protected set; }

        public Team(string? fullName, string? name, string? location, int? id, string? leagueName, int? leagueId, 
            string? divisionName, int? divisionId, string? abbreviation, string? venueName, int? venueId)
        {
            FullName = fullName;
            Name = name;
            Location = location;
            Id = id;
            LeagueName = leagueName;
            LeagueId = leagueId;
            DivisionName = divisionName;
            DivisionId = divisionId;
            Abbreviation = abbreviation;
            VenueName = venueName;
            VenueId = venueId;
        }
    }
}
