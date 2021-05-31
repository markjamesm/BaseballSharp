namespace BaseballSharp.Models
{
    public class Division
    {
        /// <summary>
        /// The ID for the division. Can be used to build other API calls.
        /// </summary>
        public int? DivisionId { get; protected set; }

        /// <summary>
        /// The name of the division. Eg: "American League Central"
        /// </summary>
        public string? DivisionName { get; protected set; }

        /// <summary>
        /// The short name of the division. Eg: "AL Central"
        /// </summary>
        public string? ShortDivisionName { get; protected set; }

        /// <summary>
        /// The abbreviated name of the division. Eg: "ALC"
        /// </summary>
        public string? DivisionAbbreviation { get; protected set; }

        /// <summary>
        /// The ID of the division. Can be used to build other API calls.
        /// </summary>
        public int? LeagueId { get; protected set; }

        public Division(int? divisionId, string? divisionName, string? shortDivisionName, string? divisionAbbreviation, int? leagueId)
        {
            DivisionId = divisionId;
            DivisionName = divisionName;
            ShortDivisionName = shortDivisionName;
            DivisionAbbreviation = divisionAbbreviation;
            LeagueId = leagueId;
        }
    }
}