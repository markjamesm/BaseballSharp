# Getting Started

## Usage

Clone the repository or install [from Nuget](https://www.nuget.org/packages/BaseballSharp/0.1.1-alpha). Next, import Baseball Sharp into your project with:

```csharp
using BaseballSharp;
```

Currently, the [MlbApi class](https://markjames.dev/Baseball-Sharp/api/index.html) contains all the endpoint functionality. 

You can also see examples of how to use the endpoint functions in the MLBSharpCli [Program.cs file](https://github.com/markjamesm/Baseball-Sharp/blob/master/MLBSharpCli/Program.cs).


## Endpoints

Endpoints are limited at the moment, but will be expanding as the library is in active development. The [Api Documentation](https://markjames.dev/Baseball-Sharp/api/index.html) section contains the most up to date endpoints reference.

#### ```Schedule(string date)```

Returns a ```list<Schedule>``` of containing games played on the specified date. Dates should be specified in mm/DD/yyyy format. Note: This endpoint is still being worked with plans to obtain game ids and other endpoints.

The list contains: 

* HomeTeam
* AwayTeam
* BallPark
* Scheduled innings: The number of scheduled innings for the game.


#### ```PitchingReports(string date)```

Returns a ```list<PitchingReport>``` containing the following information for a specified date (mm/DD/yyyy format):

* HomeTeam
* HomeProbablePitcherName
* HomeProbablePitcherId
* HomeProbablePitcherNotes
* AwayTeam
* AwayProbablePitcherName
* AwayProbablePitcherNotes
* AwayProbablePitcherId


#### ```TeamData()```

Returns a ```list<Team>``` of all teams in the league. Contains the following information:

* FullName - Full team name, eg: "Toronto Blue Jays"
* Name - Team name, eg: "Blue Jays"
* Location
* Id 
* LeagueName
* Division Name
* DivisionId
* Abbreviation
* VenueName
* VenueId
