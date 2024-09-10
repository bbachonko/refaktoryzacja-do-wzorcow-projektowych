using System.Diagnostics;

namespace CH3.Coupling
{
    /// <summary>
    /// Ta klasa pokazuje przykład ścisłych sprzężeń.
    /// </summary>
    public class TightCouplingA
    {
        /// <summary>
        /// Zmienna _name została zadeklarowana jako publiczna.
        /// </summary>
        /// <remarks>
        /// Nigdy nie należy tego robić. Zmienne obiektu zawsze powinny być
        /// prywatne i powinny być modyfikowane przez konstruktor,
        /// właściwości lub metody.
        /// </remarks>
        public string _name;

        /// <summary>
        /// Pobiera i ustawia nazwę.
        /// </summary>
        public string Name
        {
            get
            {
                if (!_name.Equals(string.Empty))
                    return _name;
                else
                    return "Nazwa jest pusta!";
            }
            set
            {
                if (value.Equals(string.Empty))
                    Debug.WriteLine("Nazwa jest pusta!");
            }
        }
    }
}

