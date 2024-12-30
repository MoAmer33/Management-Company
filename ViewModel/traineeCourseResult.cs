namespace day2.ViewModel
{
    public enum Color{
        red,
        green
    }
    public enum Status
    {
        Pass,
        Fail
    }
    public class traineeCourseResult
    {
        public string TraineeName { get; set; }
        public string CourseName  { get; set; }
        public Color color { get; set; }
        public Status status { get; set; }

    }
}
