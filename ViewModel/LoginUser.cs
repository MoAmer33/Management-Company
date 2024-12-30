using System.ComponentModel.DataAnnotations;

namespace day2.ViewModel
{
    public class LoginUser
    {
        [Required(ErrorMessage ="*")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Rememmber Me")]
        public bool rememmberMe {  get; set; }
        [Display(Name ="Admin")]
        public bool CheckRole { get; set; }

    }

}
