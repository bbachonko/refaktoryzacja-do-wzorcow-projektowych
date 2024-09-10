using System;
using System.Collections.Generic;

namespace CH3.InversionOfControl
{
    /// <summary>
    /// Kontener odwracania zależności.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Kontener używany do tworzenia i wstrzykiwania zależności.
        /// </summary>
        /// <param name="container">Kontener</param>
        /// <returns></returns>
        public delegate object Creator(Container container);

        private readonly Dictionary<string, object> configuration = new Dictionary<string, object>();
        private readonly Dictionary<Type, Creator> typeToCreator = new Dictionary<Type, Creator>();

        /// <summary>
        /// Odczytuje metadane konfiguracji.
        /// </summary>
        public Dictionary<string, object> Configuration
        {
            get { return configuration; }
        }

        /// <summary>
        /// Rejestracja zależności.
        /// </summary>
        /// <typeparam name="T">Typ zależności </typeparam>
        /// <param name="creator"></param>
        public void Register<T>(Creator creator)
        {
            typeToCreator.Add(typeof(T), creator);
        }

        /// <summary>
        /// Zwraca egzemplarz typu T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Egzemplarz typu T.</returns>
        public T Create<T>()
        {
            return (T)typeToCreator[typeof(T)](this);
        }

        /// <summary>
        /// Odczytuje konfigurację.
        /// </summary>
        /// <typeparam name="T">Typ konfiguracji </typeparam>
        /// <param name="name">Nazwa konfiguracji</param>
        /// <returns>Konfiguracja</returns>
        public T GetConfiguration<T>(string name)
        {
            return (T)configuration[name];
        }
    }
}
