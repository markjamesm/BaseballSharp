namespace MLBSharp.DTO.Teams
{

    public class TeamDto
    {
        public string copyright { get; set; }
        public Team[] teams { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public int season { get; set; }
        public Venue venue { get; set; }
        public Springvenue springVenue { get; set; }
        public string teamCode { get; set; }
        public string fileCode { get; set; }
        public string abbreviation { get; set; }
        public string teamName { get; set; }
        public string locationName { get; set; }
        public string firstYearOfPlay { get; set; }
        public League league { get; set; }
        public Division division { get; set; }
        public Sport sport { get; set; }
        public string shortName { get; set; }
        public Springleague springLeague { get; set; }
        public string allStarStatus { get; set; }
        public bool active { get; set; }
    }

    public class Venue
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Springvenue
    {
        public int id { get; set; }
        public string link { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Division
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Sport
    {
        public int id { get; set; }
        public string link { get; set; }
        public string name { get; set; }
    }

    public class Springleague
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string abbreviation { get; set; }
    }
}
