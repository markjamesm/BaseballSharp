# API Documentation
Browse the API documentation. 

## Namespaces

- The [BaseballSharp namespace](https://markjames.dev/Baseball-Sharp/api/BaseballSharp.html) contains the classes used to interface with the MLB Stats Api, as well as associated helper types:
    - The [Api class](https://markjames.dev/Baseball-Sharp/api/BaseballSharp.Api.html) holds all MLB Stats API endpoints that can be accessed from Baseball Sharp.
    - The [eTeamId enum](https://markjames.dev/Baseball-Sharp/api/BaseballSharp.eTeamId.html) contains handy references to all team ids (team ids are used as parameters for certain API calls).

- [BaseballSharp.Models](https://markjames.dev/Baseball-Sharp/api/BaseballSharp.Models.html) contains the deserialized JSON responses from the Stats API, as well as their associated properties. These are the model classes that the functions in the [Api class](https://markjames.dev/Baseball-Sharp/api/BaseballSharp.Api.html) return.