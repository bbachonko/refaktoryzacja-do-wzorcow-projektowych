namespace CH3.DependencyInjection
{
    /// <summary>
    /// Przykładowa klasa demonstrująca wstrzykiwanie zależności.
    /// </summary>
    public class Worker
    {
        private ILogger _logger;

        /// <summary>
        /// Przykład wstrzykiwania przez konstruktor.
        /// </summary>
        /// <param name="logger">
        /// Logger, który zostanie wstrzyknięty i 
        /// wykorzystany do logowania komunikatów.
        /// </param>
        public Worker(ILogger logger)
        {
            _logger = logger;
            _logger.OutputMessage(" Do tego konstruktora został wstrzyknięty logger!");
        }

        /// <summary>
        /// Przykład wstrzykiwania przez metodę.
        /// </summary>
        /// <param name="logger">
        /// Logger, który zostanie wstrzyknięty i 
        /// wykorzystany do logowania komunikatów.
        /// </param>
        public void DoSomeWork(ILogger logger)
        {
            logger.OutputMessage("Do tej metody został wstrzyknięty logger!");
        }
    }
}

