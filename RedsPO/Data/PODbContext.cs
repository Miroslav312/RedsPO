using System.Data.Entity;

[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
public class PODbContext : DbContext
{
    public PODbContext()
        : base("name = PODbContext")
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
}