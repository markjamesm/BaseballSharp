namespace BaseballSharp.Models
{
    public class Division
    {
        /// <summary>
        /// The ID for the division. Can be used to build other API calls.
        /// </summary>
        public int? DivisionId { get; set; }

        /// <summary>
        /// The name of the division. Eg: "American League Central"
        /// </summary>
        public string? DivisionName { get; set; }

        /// <summary>
        /// The short name of the division. Eg: "AL Central"
        /// </summary>
        public string? ShortDivisionName { get; set; }

        /// <summary>
        /// The abbreviated name of the division. Eg: "ALC"
        /// </summary>
        public string? DivisionAbbreviation { get; set; }

        /// <summary>
        /// The ID of the division. Can be used to build other API calls.
        /// </summary>
        public int? LeagueId { get; set; }
    }

}