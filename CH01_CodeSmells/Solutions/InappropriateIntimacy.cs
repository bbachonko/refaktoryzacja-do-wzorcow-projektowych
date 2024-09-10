namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class Course
    {
        private int _credits;
        private bool _isCompleted;

        public int Credits => _credits;
        public bool IsCompleted => _isCompleted;

        public void SetCredits(int credits)
        {
            _credits = credits;
        }

        public void Complete()
        {
            _isCompleted = true;
        }
    }

    public class Student
    {
        public void CompleteCourse(Course course)
        {
            course.SetCredits(3); // Użycie metod publicznych
            course.Complete(); // Użycie metod publicznych
        }
    }
}