using System.Data.Entity;

[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
public class PODbContext : DbContext
{
    public PODbContext()
        : base("SERVER=localhost; DATABASE=redspo; UID=root; PASSWORD=root")
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
}