namespace StudentGradesManager.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Hours { get; set; }

        public Subject()
        {
            SubjectName = string.Empty;
        }

        public Subject(int subjectId, string subjectName, int hours)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            Hours = hours;
        }

        // Display string for ComboBox binding
        public override string ToString()
        {
            return $"{SubjectName} ({Hours} Hours)";
        }
    }
}
