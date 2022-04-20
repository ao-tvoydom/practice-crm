namespace Migrations.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
    
    public string? Role { get; set; }
    
}