using System.Data.Entity;

public class DataContext : DbContext
{
    public DataContext()
        : base("name=DataContext")
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
}