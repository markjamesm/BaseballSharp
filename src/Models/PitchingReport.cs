namespace BaseballSharp.Models
{
    public class PitchingReport
    {
        public string? HomeTeam { get; protected set; }
        public string? AwayTeam { get; protected set; }
        public string? HomeProbablePitcherName { get; protected set; }
        public int? HomeProbablePitcherId { get; protected set; }

        /// <summary>
        /// Notes on the probable home starting pitcher. Not always available.
        /// </summary>
        public string? HomeProbablePitcherNotes { get; protected set; }
        public string? AwayProbablePitcherName { get; protected set; }

        /// <summary>
        /// Notes on the probable away starting pitcher. Not always available.
        /// </summary>
        public string? AwayProbablePitcherNotes { get; protected set; }
        public int? AwayProbablePitcherId { get; protected set; }

        public PitchingReport(string? homeTeam, string? homeProbablePitcherName, int? homeProbablePitcherId, 
            string? homeProbablePitcherNotes, string? awayTeam, string? awayProbablePitcherName, int? awayProbablePitcherId, 
            string? awayProbablePitcherNotes)
        {
            HomeTeam = homeTeam;
            HomeProbablePitcherName = homeProbablePitcherName;
            HomeProbablePitcherId = homeProbablePitcherId;
            HomeProbablePitcherNotes = homeProbablePitcherNotes;
            AwayTeam = awayTeam;
            AwayProbablePitcherName = awayProbablePitcherName;
            AwayProbablePitcherId = awayProbablePitcherId;
            AwayProbablePitcherNotes = awayProbablePitcherNotes;
        }
    }
}
