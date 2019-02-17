using System.Data.Entity;

public class PODbContext : DbContext
{
    public PODbContext()
        : base("name=PODbContext")
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
}