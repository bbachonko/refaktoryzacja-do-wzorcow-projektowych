namespace CH3.DependencyInjection
{
    /// <summary>
    /// Interfejs logowania.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Wyświetla komunikat w zależności od 
        /// implementacji.
        /// </summary>
        /// <param name="message">
        /// Komunikat do umieszczenia w logu.
        /// </param>
        void OutputMessage(string message);
    }
}
