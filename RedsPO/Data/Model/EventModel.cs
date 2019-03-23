using System;
using System.ComponentModel.DataAnnotations;

public partial class Event
{
    [Key]
    [Required]
    public int EventId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime DueTime { get; set; }

    [Required]
    public int UserId { get; set; }
}


public partial class Event
{
    public override string ToString()
    {
        return $"{this.Name} {this.DueTime.ToString("d")}";
    }
}