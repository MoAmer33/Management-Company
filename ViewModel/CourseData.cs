using day2.Models;

namespace day2.ViewModel
{
    public class CourseData
    {
        public CourseResult course_result { get; set; }
        public string color {  get; set; }
        public CourseData(CourseResult course_result,string color)
        {
            this.course_result = course_result;
            this.color = color;
        }
        
    }
}
