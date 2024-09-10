namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class EventDetails
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

        public void RegisterEvent(EventDetails details)
        {
            Console.WriteLine($"Event: {details.EventName}, Date: {details.EventDate}, Location: {details.Location}");
        }
    }
}
