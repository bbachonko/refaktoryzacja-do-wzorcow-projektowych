namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{

    public class UserManager
    {
        public void ManageUsers()
        {
            Console.WriteLine("Managing users.");
        }
    }

    public class SystemConfigurator
    {
        public void ConfigureSystem()
        {
            Console.WriteLine("Configuring system.");
        }
    }

    public class LogRegistrar
    {
        public void RegisterLog(string log)
        {
            Console.WriteLine($"Log: {log}");
        }
    }

    public class SystemReportGenerator
    {
        public void GenerateSystemReport()
        {
            Console.WriteLine("System report generated.");
        }
    }

    public class AdminPanel
    {
        private readonly UserManager _userManager = new UserManager();
        private readonly SystemConfigurator _systemConfigurator = new SystemConfigurator();
        private readonly LogRegistrar _logRegistrar = new LogRegistrar();
        private readonly SystemReportGenerator _systemReportGenerator = new SystemReportGenerator();

        // Metody do wywoływania odpowiednich funkcji menedżerów, jeśli potrzebne
    }
}