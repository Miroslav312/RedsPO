using System;
using System.ComponentModel.DataAnnotations;

public class Task
{
    [Key]
    [Required]
    public int TaskId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public bool IsDone { get; set; }

    [Required]
    public int UserId { get; set; }
}