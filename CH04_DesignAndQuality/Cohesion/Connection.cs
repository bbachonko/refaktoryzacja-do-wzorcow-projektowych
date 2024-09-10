namespace CH3.Cohesion
{
    /// <summary>
    /// Ta klasa prezentuje wysoką spójność 
    /// i przestrzega zasadę SRP.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Ustanawia połączenie ze źródłem danych.
        /// </summary>
        public void ConnectToDatasource() { }

        /// <summary>
        /// Zamyka połączenie ze źródłem danych i zwalnia zasoby.
        /// </summary>
        public void CloseConnectionToDataSource() { }
    }
}

