using System.Data.Common;
using System.Data.Entity;

[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
public class PODbContext : DbContext
{
    public PODbContext()
        : base("name = PODbContext")
    {

    }

    public PODbContext(string connectionString)
        : base(connectionString)
    {
        Configuration.LazyLoadingEnabled = false;
    }

    public PODbContext(DbConnection connection)
        : base(connection, true)
    {
        Configuration.LazyLoadingEnabled = false;
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<Task> Tasks { get; set; }
    public virtual DbSet<Reminder> Reminders { get; set; }
}