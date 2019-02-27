using System;
using System.ComponentModel.DataAnnotations;

public class Event
{
    [Key]
    [Required]
    public int EventId { get; set; }

    [Required]
    public string Title { get; set; }

    public DateTime DueTime { get; set; }

    [Required]
    public bool IsDone { get; set; }

    [Required]
    public string Importance { get; set; }

    [Required]
    public int UserId { get; set; }
}