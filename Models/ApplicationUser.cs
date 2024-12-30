using Microsoft.AspNetCore.Identity;

namespace day2.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string?  Address  {get; set;}

        public byte[]?  Image {get; set;}
    }
}
