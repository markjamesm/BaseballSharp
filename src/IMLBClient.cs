using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseballSharp.Enums;
using BaseballSharp.Models;

namespace BaseballSharp;

/// <summary>
/// The IMLBClient interface can be used for testing purposes.
/// </summary>
public interface IMLBClient
{
    Task<IEnumerable<Schedule>> GetScheduleAsync(DateTime date);
    Task<IEnumerable<PitchingReport>> GetPitchingReportsAsync(DateTime date);
    Task<IEnumerable<Models.Team>> GetTeamDataAsync();

    Task<IEnumerable<TeamRoster>> GetTeamRosterAsync(int teamId, int season, DateTime date,
        rosterType roster = rosterType.rosterFull);

    Task<IEnumerable<Linescore>> GetLineScoreAsync(int gameId);
    Task<IEnumerable<DepthChart>> GetDepthChartAsync(int teamId);
    Task<IEnumerable<Models.Division>> GetDivisionsAsync();
}