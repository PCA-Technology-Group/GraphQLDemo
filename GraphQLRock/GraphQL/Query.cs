using HotChocolate.Types;

[GraphQLDescription("Queries for sports teams and leagues")]
public class Query
{
    private static List<Team> _teams = new List<Team>
    {
        new Team 
        { 
            Id = 1, 
            Name = "Chelsea FC", 
            Sport = "Football",
            Country = "England",
            Founded = 1905,
            Stadium = "Stamford Bridge"
        },
        new Team 
        { 
            Id = 2, 
            Name = "Los Angeles Lakers", 
            Sport = "Basketball",
            Country = "United States",
            Founded = 1947,
            Stadium = "Crypto.com Arena"
        },
        new Team 
        { 
            Id = 3, 
            Name = "New York Yankees", 
            Sport = "Baseball",
            Country = "United States",
            Founded = 1903,
            Stadium = "Yankee Stadium"
        }
    };

    private static List<League> _leagues = new List<League>
    {
        new League
        {
            Id = 1,
            Name = "Premier League",
            Country = "England",
            Teams = _teams.Where(t => t.Sport == "Football" && t.Country == "England").ToList()
        },
        new League
        {
            Id = 2,
            Name = "NBA",
            Country = "United States",
            Teams = _teams.Where(t => t.Sport == "Basketball").ToList()
        },
        new League
        {
            Id = 3,
            Name = "MLB",
            Country = "United States",
            Teams = _teams.Where(t => t.Sport == "Baseball").ToList()
        }
    };

    [GraphQLDescription("Get all teams")]
    public IQueryable<Team> GetTeams() => _teams.AsQueryable();
    
    [GraphQLDescription("Get a team by ID")]
    public Team GetTeam(int id) => _teams.FirstOrDefault(t => t.Id == id);
    
    [GraphQLDescription("Get teams by sport")]
    public IQueryable<Team> GetTeamsBySport(string sport) => 
        _teams.Where(t => t.Sport.Equals(sport, StringComparison.OrdinalIgnoreCase)).AsQueryable();

    [GraphQLDescription("Get all leagues")]
    public IQueryable<League> GetLeagues() => _leagues.AsQueryable();

    [GraphQLDescription("Get a league by ID")]
    public League GetLeague(int id) => _leagues.FirstOrDefault(l => l.Id == id);
} 