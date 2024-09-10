namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public interface IPaymentFeeStrategy
    {
        decimal DeterminePaymentFee(decimal amount);
    }

    public class CreditCardFeeStrategy : IPaymentFeeStrategy
    {
        public decimal DeterminePaymentFee(decimal amount)
        {
            return amount * 0.02m;
        }
    }

    public class PayPalFeeStrategy : IPaymentFeeStrategy
    {
        public decimal DeterminePaymentFee(decimal amount)
        {
            return amount * 0.03m;
        }
    }

    public class BankTransferFeeStrategy : IPaymentFeeStrategy
    {
        public decimal DeterminePaymentFee(decimal amount)
        {
            return amount * 0.01m;
        }
    }

    public class Payment
    {
        private readonly IPaymentFeeStrategy _paymentFeeStrategy;

        public Payment(IPaymentFeeStrategy paymentFeeStrategy)
        {
            _paymentFeeStrategy = paymentFeeStrategy;
        }

        public decimal CalculatePaymentFee(decimal amount)
        {
            return _paymentFeeStrategy.DeterminePaymentFee(amount);
        }
    }
}