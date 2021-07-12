namespace BaseballSharp.Models
{
    public class PitchingReport
    {
        public string? HomeTeam { get; set; }
        public string? AwayTeam { get; set; }
        public string? HomeProbablePitcherName { get; set; }
        public int? HomeProbablePitcherId { get; set; }

        /// <summary>
        /// Notes on the probable home starting pitcher. Not always available.
        /// </summary>
        public string? HomeProbablePitcherNotes { get; set; }
        public string? AwayProbablePitcherName { get; set; }

        /// <summary>
        /// Notes on the probable away starting pitcher. Not always available.
        /// </summary>
        public string? AwayProbablePitcherNotes { get; set; }
        public int? AwayProbablePitcherId { get; set; }
    }
}
