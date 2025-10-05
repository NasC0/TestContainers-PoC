using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

using Testcontainers.PostgreSql;

using Program = TestContainers.Web.Program;

namespace TestContainers.IntegrationTests;

public class ApiFactory : WebApplicationFactory<Program>,
    IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer;

    public ApiFactory()
    {
        _dbContainer = new PostgreSqlBuilder()
            .WithImage("pgvector/pgvector:pg17")
            .WithDatabase("test-db")
            .WithUsername("postgre-user")
            .WithPassword("postgre-password")
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
        await _dbContainer.DisposeAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var connectionString = _dbContainer.GetConnectionString();
        builder.UseSetting("ConnectionStrings:Postgres", connectionString);
    }
}
