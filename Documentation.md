# Documentation

## Usage

Clone the repository and reference MLBSharp in your project. Next, import MLB Sharp and then reference it with:

```csharp
using MLBSharp;
```

Currently, the [MlbApi class](https://github.com/markjamesm/MLB-Sharp/blob/master/MLBSharp/MlbApi.cs) contains the endpoint functionality.


## Endpoints

Endpoints are limited at the moment, but will be expanding as the library is in active development.

#### ```Schedule(string date)```

Returns a ```list<Schedule>``` of containing games played on the specified date. Dates should be specified in mm/DD/yyyy format. Note: This endpoint is still being worked with plans to obtain game ids and other endpoints.

The list contains: 

* HomeTeam
* AwayTeam
* BallPark
* Scheduled innings: The number of scheduled innings for the game.


#### ```PitchingReports(date)```

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

Returns a ```list<Team>``` containing the following information:

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
