using System;
using System.ComponentModel.DataAnnotations;

public partial class Task
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

public partial class Task
{
    public override string ToString()
    {
        return $"{this.Name} {this.Date.ToString("d")} {(IsDone ? "✔" : "✖")}";
    }
}