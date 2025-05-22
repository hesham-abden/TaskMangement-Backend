using Microsoft.AspNetCore.Identity;
namespace TaskManagement.Domain.Identity;
    public class User : IdentityUser<long>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

