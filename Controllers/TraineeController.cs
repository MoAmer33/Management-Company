using day2.Models;
using day2.SpecialCase;
using day2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2.Controllers
{
    public class TraineeController : Controller
    {
        ITrainee _trainee;
        ICourseResult _courseResult;
        ICourse _course;
        public TraineeController(ITrainee trainee,ICourseResult courseResult,ICourse course)
        {
            this._trainee = trainee;
            this._courseResult = courseResult;
            this._course = course;
        }
        public IActionResult Show()
        {
            List<Trainee> trainees = _trainee.GetAll();

            return View("Show",trainees);
        }
        //This action get all TraineeId from Table CourseResult that match with the TraineeId for Each Trainee and Show It
        public IActionResult TraineeDetails(int id)
        {
            List<CourseResult> course_result = new List<CourseResult>();
            course_result = _courseResult.Include_Trainee_Course_InCase_TraineeId(id);
            return View("TraineeDetails", course_result);
        }
        // Show Trainee If Pass or Fail
        [HttpPost]    
        public IActionResult ShowResult(int TraineeId,int CourseId,string TraineeDegree)
        {
            traineeCourseResult traineeCourseResult = new traineeCourseResult();
            traineeCourseResult.TraineeName =_trainee.GetTrianeeName(TraineeId);
            Course course = _course.GetById(CourseId);
            traineeCourseResult.CourseName = course.Name;
            if (float.Parse(TraineeDegree) > course.MinDgree) {
            
                traineeCourseResult.color=Color.green;
                traineeCourseResult.status = Status.Pass;
            }
            else
            {
                traineeCourseResult.color = Color.red;
                traineeCourseResult.status = Status.Fail;
            }
            return View("ShowResult",traineeCourseResult);
        }

    }
}
