namespace CH3.Core.Security
{
    /// <summary>
    /// Struktura opisująca osobę.
    /// </summary>
    public struct Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="id">Unikatowy identyfikator.</param>
        /// <param name="firstName">Imię osoby.</param>
        /// <param name="lastName">Nazwisko osoby.</param>
        public Person(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

