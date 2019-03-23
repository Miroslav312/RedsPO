using System;
using System.ComponentModel.DataAnnotations;

public partial class Reminder
{
    [Key]
    [Required]
    public int ReminderId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime DueTime { get; set; }

    [Required]
    public int UserId { get; set; }
}

public partial class Reminder
{
    public override string ToString()
    {
        return $"{this.Name} {this.DueTime.ToString("d")}";
    }
}