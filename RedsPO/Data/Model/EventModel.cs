using System;
using System.ComponentModel.DataAnnotations;

public class Event
{
    [Key]
    public int EventId { get; set; }
    public string Title { get; set; }
    public DateTime DueTime { get; set; }
    public bool IsDone { get; set; }
    public string Importance { get; set; }
    public int UserId { get; set; }
}