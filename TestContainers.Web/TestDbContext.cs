using Microsoft.EntityFrameworkCore;

namespace TestContainers.Web;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) {}

    public DbSet<Todo> Todos => Set<Todo>();
}