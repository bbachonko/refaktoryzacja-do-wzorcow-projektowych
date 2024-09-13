// Command Pattern: Obsługa działań związanych z zamówieniem
namespace RefactoringToDesignPatterns.CH06_NetDesignPatterns.Workshop01
{
    public interface ICommand
    {
        void Execute();
    }

    public class ProcessOrderCommand : ICommand
    {
        private readonly Order _order;

        public ProcessOrderCommand(Order order)
        {
            _order = order;
        }

        public void Execute()
        {
            _order.ProcessOrder();
        }
    }

}
