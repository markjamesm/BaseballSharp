namespace MLBSharp.Models
{
    public class Team
    {
        public string FullName { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public int Id { get; private set; }
        public string LeagueName { get; private set; }
        public int LeagueId { get; private set; }
        public string DivisionName { get; private set; }
        public int DivisionId { get; private set; }
        public string Abbreviation { get; private set; } 
        public string VenueName { get; private set; }
        public int VenueId { get; private set; }

        public Team(string fullName, string name, string location, int id, string leagueName, int leagueId, 
            string divisionName, int divisionId, string abbreviation, string venueName, int venueId)
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
