using System;
using System.ComponentModel.DataAnnotations;

public class Reminder
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