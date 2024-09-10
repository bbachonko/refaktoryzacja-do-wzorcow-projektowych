namespace CH3.ImmutableObjectsAndDataStructures
{
    /// <summary>
    /// Obiekt niemutowalny
    /// </summary>
    public class Person
    {
        private readonly int _id;
        private readonly string _firstName;
        private readonly string _lastName;

        /// <summary>
        /// Odczytuje unikatowy identyfikator osoby.
        /// </summary>
        public int Id => _id;
        /// <summary>
        /// Odczytuje imię osoby.
        /// </summary>
        public string FirstName => _firstName;
        /// <summary>
        /// Odczytuje nazwisko osoby.
        /// </summary>
        public string LastName => _lastName;
        /// <summary>
        /// Odczytuje imię i nazwisko osoby.
        /// </summary>
        public string FullName => $"{_firstName} {_lastName}";
        /// <summary>
        /// Odczytuje imię i nazwisko osoby w odwróconym porządku
        /// rozdzielone przecinkiem.
        /// </summary>
        public string FullNameReversed => $"{_lastName}, {_firstName}";

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="id">Unikatowy identyfikator osoby.</param>
        /// <param name="firstName">Imię osoby.</param>
        /// <param name="lastName">Nazwisko osoby.</param>
        public Person(int id, string firstName, string lastName)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
        }
    }
}
