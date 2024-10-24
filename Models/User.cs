namespace TwoFactorAuthAPI.Models;

public class User
{
    string? Id { get; set; } = Guid.NewGuid().ToString(); 
    string Email { get; set; } = String.Empty;

    public User( string? Id, string Email )
    {
        this.Id = Id;
        this.Email = Email;
    }


}

