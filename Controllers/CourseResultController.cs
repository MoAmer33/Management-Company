using day2.Models;
using day2.Repositry;
using day2.SpecialCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2.Controllers
{
    public class CourseResultController : Controller
    {
        ICourseResult _courseResult;
        public CourseResultController(ICourseResult courseResult)
        {
            this._courseResult = courseResult;
        }
        public IActionResult Show()
        {
            List<CourseResult> courses_result = _courseResult.Include_Trainee_Course_Class();
            return View("Show", courses_result);
        }
        


    }
}
