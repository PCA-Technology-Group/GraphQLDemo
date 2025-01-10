using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Clear and simple GraphQL configuration
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<Team>()
    .AddType<League>();

var app = builder.Build();

// Minimal middleware setup
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
