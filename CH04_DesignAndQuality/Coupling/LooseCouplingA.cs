using System.Diagnostics;

namespace CH3.Coupling
{
    /// <summary>
    /// Klasa pokazuje przykład luźnych sprzężeń.
    /// </summary>
    public class LooseCouplingA
    {
        /// <summary>
        /// Modyfikator private zapobiega dostępowi do składowej danych.
        /// </summary>
        private readonly string _name = string.Empty;

        private const string StringIsEmpty = "Ciąg jest pusty ";

        /// <summary>
        /// Właściwość umożliwia pośredni dostęp do składowej danych.
        /// Podczas sięgania do składowej lub jej ustawiania wykonywana jest walidacja.
        /// Można zmieniać wewnętrzne elementy klasy bez wpływu na klasy, 
        /// które korzystają z właściwości.
        /// </summary>
        public string Name
        {
            get => _name.Equals(string.Empty) ? StringIsEmpty : _name;

            set
            {
                if (value.Equals(string.Empty))
                    Debug.WriteLine("Wyjątek: Ciąg musi mieć długość większą od zera.");
            }
        }
    }
}

