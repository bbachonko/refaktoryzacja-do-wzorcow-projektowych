using System;

namespace CH3.DependencyInjection
{
    /// <summary>
    /// Loguje komunikaty do pliku tekstowego.
    /// </summary>
    public class TextFileLogger : ILogger
    {
        /// <summary>
        /// Umieszcza komunikaty w pliku tekstowym.
        /// </summary>
        /// <param name="message">
        /// Komunikat do zapisania w pliku tekstowym.
        /// </param>
        public void OutputMessage(string message)
        {
            System.IO.File.WriteAllText(FileName(), message);
        }

        private string FileName()
        {
            var timestamp = DateTime.Now.ToFileTimeUtc().ToString();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return $"{path}_{timestamp}";
        }
    }
}

