namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public interface ILogger
    {
        void LogMessage();
    }

    public class FileLogger : ILogger
    {
        public void LogMessage()
        {
            /* Implementacja dla pliku */
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void LogMessage()
        {
            /* Implementacja dla bazy danych */
        }
    }

    public interface IExporter
    {
        void ExportData();
    }

    public class XmlExporter : IExporter
    {
        public void ExportData()
        {
            /* Implementacja dla XML */
        }
    }

    public class JsonExporter : IExporter
    {
        public void ExportData()
        {
            /* Implementacja dla JSON */
        }
    }
}