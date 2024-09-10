namespace CH3.Cohesion
{
    /// <summary>
    /// Ta klasa prezentuje wysoką spójność 
    /// i przestrzega zasadę SRP.
    /// </summary>
    public class DataProcessor
    {
        /// <summary>
        /// Uzyskaj dane dla raportu .
        /// </summary>
        public void ExtractDataFromDataSource() { }

        /// <summary>
        /// Sformatuj dane do raportu .
        /// </summary>
        public void TransformDataForReport() { }
    }
}
