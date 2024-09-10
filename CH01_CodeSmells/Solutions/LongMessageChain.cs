namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class School
    {
        public string GetTeacherName()
        {
            Classroom classroom = new Classroom();
            return classroom.GetTeacher().GetName();
        }
    }
}

// Przykład wywołania
// School school = new School();
// string teacherName = school.GetTeacherName();
