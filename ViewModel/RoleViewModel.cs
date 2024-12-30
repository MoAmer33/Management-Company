using System.ComponentModel.DataAnnotations;

namespace day2.ViewModel
{
    public class RoleViewModel
    {
        [RegularExpression(@"(Admin|Employee|Instructor)")]
        public string Name { get; set; }
    }
}
