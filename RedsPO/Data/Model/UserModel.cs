using System.ComponentModel.DataAnnotations;

public partial class User
{
    [Key]
    [Required]
    public int UserId { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
}