namespace BaseballSharp.Models
{
    public class Team
    {
        public string? FullName { get; protected set; }
        public string? Name { get; protected set; }
        public string? Location { get; protected set; }
        public int? Id { get; protected set; }
        public string? LeagueName { get; protected set; }
        public int? LeagueId { get; protected set; }
        public string? DivisionName { get; protected set; }
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
