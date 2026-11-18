namespace StudentGradesManager.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public string Department { get; set; }

        public Student()
        {
            StudentName = string.Empty;
            StudentNumber = string.Empty;
            Department = string.Empty;
        }

        public Student(int studentId, string studentName, string studentNumber, string department)
        {
            StudentId = studentId;
            StudentName = studentName;
            StudentNumber = studentNumber;
            Department = department;
        }

        // Display string for ComboBox binding
        public override string ToString()
        {
            return $"{StudentName} ({StudentNumber})";
        }
    }
}
