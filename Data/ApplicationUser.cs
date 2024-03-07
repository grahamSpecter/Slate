using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace Slate.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties can be added here
        
        public required string Username { get; set; }
        public override string PasswordHash { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public override string? PhoneNumber {  get; set; }
    }
}
