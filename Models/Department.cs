namespace day2.Models
{
    public class Department
    {
     
        public int id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public List<Instructor>? instructors { get; set; }
        public List<Course>? courses { get; set; }

    }
}
