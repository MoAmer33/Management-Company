using day2.Models;
using day2.SpecialCase;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2.Controllers
{
    public class DepartmentController : Controller
    {

            IDepartment _department;
            public DepartmentController(IDepartment department)
            {
            this._department = department;
            
            }
            public IActionResult Show()
            {
               List<Department> list = _department.Include_Instructors_Courses();
                return View("Show", list);
            }
        
    }
}
