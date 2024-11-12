using Microsoft.AspNetCore.Identity;

namespace Xacadmey.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address {  get; set; }
    }
}
