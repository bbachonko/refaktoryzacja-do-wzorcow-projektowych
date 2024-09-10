namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationService
    {
        public void Login(UserAccount user, string username, string password)
        {
            // Logika logowania
            Console.WriteLine("User logged in.");
        }

        public void Logout(UserAccount user)
        {
            // Logika wylogowania
            Console.WriteLine("User logged out.");
        }
    }

    public class UserReportGenerator
    {
        public void GenerateReport(UserAccount user)
        {
            // Logika generowania raportu
            Console.WriteLine("Generating user report.");
        }
    }
}