namespace eCommerce.Core.Domain.Entities;

/// <summary>
/// Entity model which is used to represent user details inside data store
/// </summary>
public class ApplicationUser
{
    public Guid UserID { get; set; }
    public string? PersonName { get; set; } 
    public string? Email { get; set; }  
    public string? Password { get; set; }  
    public string? Gender { get; set; }  
}