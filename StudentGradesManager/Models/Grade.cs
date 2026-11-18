namespace StudentGradesManager.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal GradeValue { get; set; }

        // Extra helper properties for display/reporting
        public string StudentName { get; set; }
        public string SubjectName { get; set; }

        public Grade()
        {
            StudentName = string.Empty;
            SubjectName = string.Empty;
        }

        public Grade(int gradeId, int studentId, int subjectId, decimal gradeValue)
        {
            GradeId = gradeId;
            StudentId = studentId;
            SubjectId = subjectId;
            GradeValue = gradeValue;
            StudentName = string.Empty;
            SubjectName = string.Empty;
        }

        // Dynamic C# calculation for Result (Pass / Fail)
        public string GetResult()
        {
            if (GradeValue >= 50)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }

        // Dynamic C# calculation for Evaluation
        public string GetEvaluation()
        {
            if (GradeValue >= 90)
            {
                return "Excellent";
            }
            else if (GradeValue >= 80)
            {
                return "Very Good";
            }
            else if (GradeValue >= 70)
            {
                return "Good";
            }
            else if (GradeValue >= 60)
            {
                return "Acceptable";
            }
            else if (GradeValue >= 50)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }
    }
}
