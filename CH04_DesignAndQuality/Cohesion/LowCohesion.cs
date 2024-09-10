namespace CH3.Cohesion
{
    /// <summary>
    /// To jest przykład niskiej spójności. Klasę można podzielić na 
    /// 3 klasy, które byłyby bardziej spójne. Zwróć uwagę na 
    /// wiele odpowiedzoialności tej klasy. Oto one:
    /// 
    /// [1] Nawiązywanie połączenia ze źródłem danych i odłączanie się od źródła danych.
    /// [2] Wyodrębnianie i przekształcanie danych.
    /// [3] Generowanie i drukowanie raportu.
    /// </summary>
    public class LowCohesion
    {
        /// <summary>
        /// Ustanawia połączenie ze źródłem danych.
        /// </summary>
        public void ConnectToDatasource() { }

        /// <summary>
        /// Uzyskaj dane do raportu .
        /// </summary>
        public void ExtractDataFromDataSource() { }

        /// <summary>
        /// Sformatuj dane do raportu .
        /// </summary>
        public void TransformDataForReport() { }

        /// <summary>
        /// Załaduj raport i wypełnij go danymi.
        /// </summary>
        public void AssignDataAndGenerateReport() { }

        /// <summary>
        /// Wydrukuj raport.
        /// </summary>
        public void PrintReport() { }

        /// <summary>
        /// Zamyka połączenie ze źródłem danych i zwalnia zasoby.
        /// </summary>
        public void CloseConnectionToDataSource() { }
    }
}
