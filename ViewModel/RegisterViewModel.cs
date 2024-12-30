using System.ComponentModel.DataAnnotations;

namespace day2.ViewModel
{
    public class RegisterViewModel
    {
        [RegularExpression(@"[A-Za-z]{2,}",ErrorMessage ="must be chracter more than 2")]
        public string Name { get; set; }

        
        [RegularExpression(@"[A-z0-9]{5,20}\@[A-za-z]+\.(com)",ErrorMessage ="Should be like character@character.com")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Address {  get; set; }

    }
}
