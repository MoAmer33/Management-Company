using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace day2.ViewModel
{
    public class AddRoleToUser
    {     
        public string Name { get; set; }
        
        public dynamic Roles { get; set; }
        
        public string RoleName { get; set; }
    }
}
