# Baseball Sharp
[![C#](https://img.shields.io/badge/Language-CSharp-darkgreen.svg)](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)) [![Build](https://github.com/markjamesm/Baseball-Sharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/markjamesm/Baseball-Sharp/actions) [![NuGet](https://img.shields.io/nuget/vpre/BaseballSharp)](https://www.nuget.org/packages/BaseballSharp/) [![License](https://img.shields.io/badge/License-MIT-red.svg)](https://opensource.org/licenses/MIT)

## About

Baseball Sharp is an unofficial .NET API client for accessing the public facing (but undocumented) MLB Stats API. Currently runs on .NET 7.

## Usage

Clone the repository or [install from Nuget](https://www.nuget.org/packages/BaseballSharp/). Next, import Baseball Sharp into your project with:
```
using BaseballSharp;
```

The solution contains two projects: 

* BaseballSharp - The MLB Stats API wrapper library.
* BaseballSharpCli - Command line app which contains an example implementation of Baseball Sharp's features.

## Documentation

* Read the [getting started guide](https://baseballsharp.markjames.dev/articles/intro.html).
* View the [API reference](https://baseballsharp.markjames.dev/api/BaseballSharp.html).
* [Read the changelog](https://baseballsharp.markjames.dev/articles/changelog).

## Planned

* Continue implementing API endpoints and helper functions. 
* Add unit tests.
* Develop BaseballSharp CLI example to showcase usage.

## Copyright Notice 

This package and its author are not affiliated with MLB or any MLB team. This API wrapper interfaces with MLB's Stats API. Use of MLB data is subject to the notice posted at http://gdx.mlb.com/components/copyright.txt.
