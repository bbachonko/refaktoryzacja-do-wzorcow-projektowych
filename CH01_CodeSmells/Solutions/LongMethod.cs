namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class StatisticsCalculator
    {
        public void CalculateStatistics(List<int> numbers)
        {
            double average = CalculateAverage(numbers);
            double median = CalculateMedian(numbers);
            double standardDeviation = CalculateStandardDeviation(numbers, average);

            DisplayResults(average, median, standardDeviation);
        }

        private double CalculateAverage(List<int> numbers)
        {
            return numbers.Average();
        }

        private double CalculateMedian(List<int> numbers)
        {
            numbers.Sort();
            int count = numbers.Count;
            if (count % 2 == 0)
            {
                return (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0;
            }

            return numbers[count / 2];
        }

        private double CalculateStandardDeviation(List<int> numbers, double average)
        {
            double sumOfSquares = numbers.Select(num => Math.Pow(num - average, 2)).Sum();
            return Math.Sqrt(sumOfSquares / numbers.Count);
        }

        private void DisplayResults(double average, double median, double standardDeviation)
        {
            Console.WriteLine($"Average: {average}, Median: {median}, Standard Deviation: {standardDeviation}");
        }
    }
}