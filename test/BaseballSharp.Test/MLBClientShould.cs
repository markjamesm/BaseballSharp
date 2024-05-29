
using System.Net;
using Moq;
using Moq.Protected;

namespace BaseballSharp.Test
{
    public class MLBClientShould
    {
        private HttpClient BuildMockedHttpClient(string returnContent)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            
            handlerMock
            .Protected()
            // Setup the PROTECTED method to mock
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            // Prepare the expected response of the mocked HttpClient
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(returnContent),
            })
            .Verifiable();

            return new HttpClient(handlerMock.Object);
        }

        [Fact]
        public async void ReturnAScheduleGivenAValidDate()
        {   
            var sut = new MLBClient
            {
                HttpClient = BuildMockedHttpClient(File.ReadAllText("Schedule.json")),
            };

            var game = (await sut.GetScheduleAsync(DateTime.Now)).ToList().Single();
            
            Assert.Equal("Toronto Blue Jays", game.AwayTeam);
            Assert.Equal("Comerica Park", game.Ballpark);
            Assert.Equal(746470, game.gameID);
            Assert.Equal("Detroit Tigers", game.HomeTeam);
            Assert.Equal(9, game.ScheduledInnings);
            Assert.Equal(Enums.GameStatus.PreGame, game.StatusCode);
        }

        [Fact]
        public async void ReturnAValidPitchingReportGivenAValidDate()
        {
            var sut = new MLBClient
            {
                HttpClient = BuildMockedHttpClient(File.ReadAllText("PitchingReports.json")),
            };

            var pitchingReport = (await sut.GetPitchingReportsAsync(DateTime.Now)).ToList().Single();
            
            Assert.Equal(607192, pitchingReport.AwayProbablePitcherId);
            Assert.Equal("Tyler Glasnow", pitchingReport.AwayProbablePitcherName);
            Assert.Equal("", pitchingReport.AwayProbablePitcherNotes);
            Assert.Equal("Los Angeles Dodgers", pitchingReport.AwayTeam);
            Assert.Equal(656731, pitchingReport.HomeProbablePitcherId);
            Assert.Equal("Tylor Megill", pitchingReport.HomeProbablePitcherName);
            Assert.Equal("", pitchingReport.HomeProbablePitcherNotes);
            Assert.Equal("New York Mets", pitchingReport.HomeTeam);
        }

        [Fact]
        public async void ReturnValidTeamData()
        {
            var sut = new MLBClient
            {
                HttpClient = BuildMockedHttpClient(File.ReadAllText("TeamData.json")),
            };

            var teamData = (await sut.GetTeamDataAsync()).ToList().Single();
            
            Assert.Equal("OAK", teamData.Abbreviation);
            Assert.Equal(200, teamData.DivisionId);
            Assert.Equal("American League West", teamData.DivisionName);
            Assert.Equal("Oakland Athletics", teamData.FullName);
            Assert.Equal(133, teamData.Id);
            Assert.Equal(103, teamData.LeagueId);
            Assert.Equal("American League", teamData.LeagueName);
            Assert.Equal("Oakland", teamData.Location);
            Assert.Equal("Athletics", teamData.Name);
            Assert.Equal(10, teamData.VenueId);
            Assert.Equal("Oakland Coliseum", teamData.VenueName);
        }
    }
}
