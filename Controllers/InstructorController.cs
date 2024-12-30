using day2.Models;
using day2.SpecialCase;
using day2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2.Controllers
{
    public class InstructorController : Controller
    {
        IInstructors _instructors;
        ICourseResult _courseResult;
        ICourse _course;
        IDepartment _department;
        public InstructorController(IInstructors instructors, ICourseResult courseResult, ICourse course, IDepartment department)
        {
            this._instructors = instructors;
            this._courseResult = courseResult;
            this._course = course;
            this._department = department;
        }
        public IActionResult Show(string InstructorName)
        {
            List<Instructor> list = _instructors.Include_Department_Courses();
            if (!String.IsNullOrEmpty(InstructorName))
            {

                list = _instructors.GetSpecificInstructor(InstructorName);

            }
            ViewBag.InstructorName = InstructorName;
            return View("Show", list);
        }

        public IActionResult ShowSingleInstructor(int id)
        {
            StudentGradeForEachInstructor com = new StudentGradeForEachInstructor();
            com.ins = _instructors.GetInstructor_Include_Department_Courses(id);
            com.res = _courseResult.Include_Trainee_Course_Class();

            return View("ShowSingleInstructor", com);
        }
        public IActionResult AddInstructor()
        {
            Instructor instr = new Instructor();
            ViewBag.courses = _course.GetAll();
            ViewBag.dapartment = _department.GetAll();
            return View("AddInstructor", instr);
        }

        public IActionResult EditInstructor(int id)
        {
            Instructor instr = _instructors.GetById(id);
            ViewBag.courses = _course.GetAll();
            ViewBag.dapartment = _department.GetAll();
            return View("EditInstructor", instr);
        }
        public IActionResult SaveUpdate(Instructor Ins)
        {
            if (Ins.address != null && Ins.name != null && !float.IsNaN(Ins.salary) && (float)Ins.salary != 0 && Ins.img != null)
            {
                _instructors.Update(Ins);
                _instructors.Save();
                return RedirectToAction("Show");
            }
            ViewBag.courses = _course.GetAll();
            ViewBag.dapartment = _department.GetAll();
            return View("EditInstructor", Ins);

        }
        [HttpPost]
        public IActionResult SaveAdd(Instructor Ins)
        {
            if (Ins.address != null && Ins.name != null && !float.IsNaN(Ins.salary) && (float)Ins.salary != 0 && Ins.img != null)
            {
                _instructors.Add(Ins);
                _instructors.Save();
                return RedirectToAction("Show");
            }
            ViewBag.courses = _course.GetAll();
            ViewBag.dapartment = _department.GetAll();
            return View("AddInstructor", Ins);

        }
        public IActionResult Delete(Instructor ins)
        {
            _instructors.Delete(ins);
            _instructors.Save();
          return  RedirectToAction("Show");
        }
    }
}
