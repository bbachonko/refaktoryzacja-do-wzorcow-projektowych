using System;
using System.Diagnostics;

namespace CH3.Coupling
{
    /// <summary>
    /// Klasa pokazuje przykład luźnych sprzężeń.
    /// </summary>
    public class LooseCouplingB
    {
        /// <summary>
        /// W konstruktorze nie można uzyskać dostępu do właściwości _name klasy 
        /// LooseCouplingA, dlatego mamy do czynienia z luźnym sprzężeniem.
        /// </summary>
        public LooseCouplingB()
        {
            var lca = new LooseCouplingA
            {
                Name = string.Empty
            };
            Debug.WriteLine($"Nazwa to {lca.Name}");
        }
    }
}

