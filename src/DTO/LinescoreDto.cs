using System.Collections.Generic;

namespace BaseballSharp.DTO.Linescore;
public class Home
{
    public int? runs { get; set; }
    public int? hits { get; set; }
    public int? errors { get; set; }
    public int? leftOnBase { get; set; }
}

public class Away
{
    public int? runs { get; set; }
    public int? hits { get; set; }
    public int? errors { get; set; }
    public int? leftOnBase { get; set; }
}

public class Innings
{
    public int? num { get; set; }
    public string? ordinalNum { get; set; }
    public Home? home { get; set; }
    public Away? away { get; set; }
}

public class Teams
{
    public Home? home { get; set; }
    public Away? away { get; set; }
}

public class Pitcher
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Catcher
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class First
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Second
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Third
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Shortstop
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Left
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Center
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Right
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Batter
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class OnDeck
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class InHole
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? link { get; set; }
}

public class Team
{
    public int? id { get; set; }
    public string? name { get; set; }
    public string? link { get; set; }
}

public class Defense
{
    public Pitcher? pitcher { get; set; }
    public Catcher? catcher { get; set; }
    public First? first { get; set; }
    public Second? second { get; set; }
    public Third? third { get; set; }
    public Shortstop? shortstop { get; set; }
    public Left? left { get; set; }
    public Center? center { get; set; }
    public Right? right { get; set; }
    public Batter? batter { get; set; }
    public OnDeck? onDeck { get; set; }
    public InHole? inHole { get; set; }
    public int? battingOrder { get; set; }
    public Team? team { get; set; }
}

public class Offense
{
    public Batter? batter { get; set; }
    public OnDeck? onDeck { get; set; }
    public InHole? inHole { get; set; }
    public Pitcher? pitcher { get; set; }
    public int? battingOrder { get; set; }
    public Team? team { get; set; }
}

public class LinescoreDto
{
    public string? copyright { get; set; }
    public int? currentInning { get; set; }
    public string? currentInningOrdinal { get; set; }
    public string? inningState { get; set; }
    public string? inningHalf { get; set; }
    public bool? isTopInning { get; set; }
    public int? scheduledInnings { get; set; }
    public List<Innings>? innings { get; set; }
    public Teams? teams { get; set; }
    public Defense? defense { get; set; }
    public Offense? offense { get; set; }
    public int? balls { get; set; }
    public int? strikes { get; set; }
    public int? outs { get; set; }
}