namespace BaseballSharp.DTO
{
    public class DivisionsDto
    {
        public string? copyright { get; set; }
        public LeagueDivision[]? divisions { get; set; }
    }

    public class LeagueDivision
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? season { get; set; }
        public string? nameShort { get; set; }
        public string? link { get; set; }
        public string? abbreviation { get; set; }
        public League? league { get; set; }
        public Sport? sport { get; set; }
        public bool? hasWildcard { get; set; }
        public int? numPlayoffTeams { get; set; }
    }

    public class League
    {
        public int? id { get; set; }
        public string? link { get; set; }
    }

    public class Sport
    {
        public int? id { get; set; }
        public string? link { get; set; }
    }

}