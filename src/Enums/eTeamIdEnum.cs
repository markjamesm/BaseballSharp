namespace BaseballSharp.Enums;

public sealed class eTeamIdEnum
{
    public static eTeamIdEnum Angels { get; } = new(108, "Angels") ;
    public static eTeamIdEnum DBacks { get; } = new(109, "DBacks") ;
    public static eTeamIdEnum Orioles { get; } = new(110, "Orioles") ;
    public static eTeamIdEnum RedSox { get; } = new(111, "RedSox") ;
    public static eTeamIdEnum Cubs { get; } = new(112, "Cubs") ;
    public static eTeamIdEnum Reds { get; } = new(113, "Reds") ;
    public static eTeamIdEnum Indians { get; } = new(114, "Indians") ;
    public static eTeamIdEnum Rockies { get; } = new(115, "Rockies") ;
    public static eTeamIdEnum Tigers { get; } = new(116, "Tigers") ;
    public static eTeamIdEnum Astros { get; } = new(117, "Astros") ;
    public static eTeamIdEnum Royals { get; } = new(118, "Royals") ;
    public static eTeamIdEnum Dodgers { get; } = new(119, "Dodgers") ;
    public static eTeamIdEnum Nationals { get; } = new(120, "Nationals") ;
    public static eTeamIdEnum Mets { get; } = new(121, "Mets") ;
    public static eTeamIdEnum Athletics { get; } = new(133, "Athletics") ;
    public static eTeamIdEnum Pirates { get; } = new(134, "Pirates") ;
    public static eTeamIdEnum Padres { get; } = new(135, "Padres") ;
    public static eTeamIdEnum Mariners { get; } = new(136, "Mariners") ;
    public static eTeamIdEnum Giants { get; } = new(137, "Giants") ;
    public static eTeamIdEnum Cardinals { get; } = new(138, "Cardinals") ;
    public static eTeamIdEnum Rays { get; } = new(139, "Rays") ;
    public static eTeamIdEnum Rangers { get; } = new(140, "Rangers") ;
    public static eTeamIdEnum BlueJays { get; } = new(141, "BlueJays") ;
    public static eTeamIdEnum Twins { get; } = new(142, "Twins") ;
    public static eTeamIdEnum Phillies { get; } = new(143, "Phillies") ;
    public static eTeamIdEnum Braves { get; } = new(144, "Braves") ;
    public static eTeamIdEnum WhiteSox { get; } = new(145, "WhiteSox") ;
    public static eTeamIdEnum Marlins { get; } = new(146, "Marlins") ;
    public static eTeamIdEnum Yankees { get; } = new(147, "Yankees") ;
    public static eTeamIdEnum Brewers { get; } = new(158, "Brewers") ;
    private eTeamIdEnum(int id, string teamName)
    {
        Id = id;
        TeamName = teamName;
    }
    
    public readonly int Id;
    public readonly string TeamName;
}