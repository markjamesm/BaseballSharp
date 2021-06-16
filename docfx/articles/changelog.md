# Changelog

#### 0.1.6-alpha

- Added ability to pull roster back by either full, 25man or 40 man.
- Moved http calls to https to avoid mixed-content errors and because it's just better.

#### 0.1.5-alpha

##### Endpoints

- Added Divisions() endpoint.

##### Backend changes

- Removed dependency on WebClient, this was causing issues with Blazor when the API was called (WASM requires HttpClient).
- Moved all calls to a private method to remove the need to create a new webclient with each call, also helps declutter the calling methods.
- Moved API calls to async to take advantage of the async HttpClient calls.
- Add null-coalescing logic to avoid null exceptions if the MLB API returns a null result.
- Updated CLI project to account for these changes.

#### 0.1.4-alpha

- Added DepthChart() endpoint.
- Added eTeamId enum to make getting team ids easier.

#### 0.1.3-alpha

- Added TeamRoster() endpoint function.
- Added Linescore() endpoint.

#### 0.1.2-alpha

- Refactored project to use nullable value types in case some data is missing from a JSON response.

#### 0.1.1-alpha

- Renamed project to Baseball Sharp.

#### 0.1.0-alpha

- Initial commit.