namespace eCommerce.Core.Domain.Entities;

/// <summary>
/// Entity model which is used to represent user details inside data store
/// </summary>
public class ApplicationUser
{
    public Guid UserID { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Gender { get; set; } = null!; 
}