using day2.Models;
using day2.Repositry;
using day2.SpecialCase;
using day2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace day2.Controllers
{
    public class CourseController : Controller
    {
        IInstructors _instructor;
        IDepartment _department;
        ICourseResult _courseResult;
        ICourse _course;
        public CourseController(IInstructors instructor, ICourseResult course_result,IDepartment department,ICourse course)
        {
            this._course = course;
            this._department = department;
            this._courseResult = course_result;
            this._instructor = instructor;
            
        }

        public IActionResult Show()
        {
            List<Course> courses=_course.IncludeDepartments();
            return View("Show",courses);
        }
        public IActionResult CheckDegree(int MinDgree, int MaxDgree)
        {
            if (MinDgree < MaxDgree)
                return Json(true);
            return Json(false);
        }
        public IActionResult Add()
        {
            Course course = new Course();
            ViewBag.Department = _department.GetAll();
            return View("Add",course);
        }
        public IActionResult Edit(int id)
        {
            Course course = _course.GetById(id);
            ViewBag.Department= _department.GetAll();
            return View("Edit",course);
        }
        [HttpPost]
        public IActionResult SaveEdit(Course EditCourse)
        {
            if (ModelState.IsValid==true)
            {
                _course.Update(EditCourse);
                _course.Save();
                return RedirectToAction("Show");
            }
            ViewBag.Department = _department.GetAll();
            return View("Edit", EditCourse);
            
        }
        [HttpPost]
        public IActionResult SaveAdd(Course crs)
        {
            if (ModelState.IsValid==true)
            {
                if (crs.DepartmentId!= -1)
                {
                 _course.Add(crs);
                 _course.Save();
                return RedirectToAction("Show");
                }
                else
                {
                 ModelState.AddModelError("DepartmentId", "Select Department");
                }
            }
            ViewBag.Department = _department.GetAll();
                 return View("Add", crs);
            
        }
        //Get the All Trainee Data that Registerd in this Course
        public IActionResult CourseDetails(int id)
        {
           
            List<CourseResult> result =_courseResult.Include_Trainee_Course_InCase_CourseId(id);
            List<CourseData> data = new List<CourseData>();
            foreach (var c in result)
            {
                string s=float.Parse(c.DgreeOfTrainee) >= c.Course.MinDgree?"green":"red";
                data.Add(new CourseData(c, s));
            }
            return View("CourseDetails",data);
        }
        [HttpPost]
     
        public IActionResult Delete(int id)
        {
            Course course = _course.GetById(id);
            Instructor instructor =_instructor.GetInstructorByCourseId(id); 
            if (instructor==null)
            {
                _course.Delete(course);
                _course.Save();
                ViewBag.AlertMessage = "Deleted Successfuly";
            }
            else
            {
                ViewBag.AlertMessage = "Cannot Delete the course Because there is Instrcutor teach this course Should Delete Instructor before Delete it";
               
            }
            List<Course> courses = new List<Course>();
            courses = _course.IncludeDepartments();
            return View("Show", courses);
        }

    }
}
