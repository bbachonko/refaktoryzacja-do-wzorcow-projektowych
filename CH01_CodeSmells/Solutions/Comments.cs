namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class Transaction
    {
        public bool VerifyDetails()
        {

            return true;
        }
    }
    public class PaymentProcessor
    {
        public void PerformTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (AreTransactionDetailsValid(transaction))
            {
                CompletePayment(transaction);
                UpdateAccountBalance(transaction);
                GenerateReceipt(transaction);
            }
        }

        private bool AreTransactionDetailsValid(Transaction transaction)
        {
            return transaction.VerifyDetails();
        }

        private void CompletePayment(Transaction transaction)
        {
        }

        private void UpdateAccountBalance(Transaction transaction)
        {
        }

        private void GenerateReceipt(Transaction transaction)
        {
        }
    }
}
