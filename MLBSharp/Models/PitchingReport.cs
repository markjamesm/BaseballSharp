namespace MLBSharp.Models
{
    public class PitchingReport
    {
        public string HomeTeam { get; private set; }
        public string AwayTeam { get; private set; }
        public string HomeProbablePitcherName { get; private set; }
        public int HomeProbablePitcherId { get; private set; }
        public string HomeProbablePitcherNotes { get; private set; }
        public string AwayProbablePitcherName { get; private set; }
        public string AwayProbablePitcherNotes { get; private set; }
        public int AwayProbablePitcherId { get; private set; }

        public PitchingReport(string homeTeam, string homeProbablePitcherName, int homeProbablePitcherId, 
            string homeProbablePitcherNotes, string awayTeam, string awayProbablePitcherName, int awayProbablePitcherId, 
            string awayProbablePitcherNotes)
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
