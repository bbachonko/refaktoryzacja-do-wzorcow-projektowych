namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class MessagingService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Notification sent: {message}");
        }
    }
}