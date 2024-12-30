using day2.Models;
using System.ComponentModel.DataAnnotations;

namespace day2.ValidationModel
{
    public class UniqueName:ValidationAttribute
    {
        Context context=new Context();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
                String valuee = value.ToString();
            Course course = context.Courses.FirstOrDefault(c => c.Name == valuee);
            if (course?.Id != null)
            {
                Course c1 = (Course)validationContext.ObjectInstance;
                if (course.Id == c1.Id)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Course Name Exist tryagin!");
            }
            else
            {
                return ValidationResult.Success;
            }

        }    }
}
