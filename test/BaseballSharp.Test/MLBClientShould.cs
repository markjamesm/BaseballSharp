
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
    }
}
