//1. Strategy Pattern: Obliczanie kosztów dostawy
namespace RefactoringToDesignPatterns.CH06_NetDesignPatterns.Workshop01
{
    public interface IShippingCostStrategy
    {
        double CalculateShippingCost();
    }

    public class StandardShippingCost : IShippingCostStrategy
    {
        public double CalculateShippingCost()
        {
            return 10;
        }
    }

    public class ExpressShippingCost : IShippingCostStrategy
    {
        public double CalculateShippingCost()
        {
            return 20;
        }
    }
}
