using System.Diagnostics;

namespace CH3.Coupling
{
    /// <summary>
    /// Ta klasa pokazuje przykład ścisłych sprzężeń.
    /// </summary>
    public class TightCouplingB
    {
        /// <summary>
        /// Ta klasa pokazuje przykład ścisłych sprzężeń.
        /// </summary>
        public TightCouplingB()
        {
            TightCouplingA tca = new TightCouplingA();

            // Ponieważ bezpośrednio ustawiamy składową _name, tworzymy ścisłe sprzężenie dwóch klas.
            // To jest przykład ścisłego sprzężenia.
            tca._name = null;

            // Ponieważ bezpośrednio sięgamy do składowej _name, tworzymy ścisłe sprzężenie dwóch klas.
            // To jest przykład ścisłego sprzężenia.
            Debug.WriteLine("Nazwa to " + tca._name);
        }
    }
}

