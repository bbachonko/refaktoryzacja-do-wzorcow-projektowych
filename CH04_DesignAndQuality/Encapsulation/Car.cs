using System;

namespace CH3.Core.Security
{
    /// <summary>
    /// Obiekt Car.
    /// </summary>
    public class Car
    {
        private string _make;
        private string _model;
        private int _year;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="make">Marka samochodu.</param>
        /// <param name="model">Model samochodu.</param>
        /// <param name="year">Rocznik, w którym wyprodukowano markę i model.</param>
        public Car(string make, string model, int year)
        {
            _make = ValidateMake(make);
            _model = ValidateModel(model);
            _year = ValidateYear(year);
        }

        private string ValidateMake(string make)
        {
            if (make.Length >= 3)
                return make;
            throw new ArgumentException("Marka musi składać się co najmniej z trzech znaków.");
        }

        private string ValidateModel(string model)
        {
            if (model.Length >= 2)
                return model;
            throw new ArgumentException("Model musi składać się co najmniej z trzech znaków.");
        }

        private int ValidateYear(int year)
        {
            if (year > 1885 && year <= DateTime.Now.Year + 1)
                return year;
            throw new ArgumentException($"Rocznik musi się mieścić pomiędzy 1885, a {DateTime.Now.Year + 1}");
        }

        /// <summary>
        /// Pobiera i ustawia markę samochodu.
        /// </summary>
        public string Make
        {
            get { return _make; }
            set { _make = ValidateMake(value); }
        }

        /// <summary>
        /// Pobiera i ustawia model samochodu.
        /// </summary>
        public string Model
        {
            get { return _model; }
            set { _model = ValidateModel(value); }
        }

        /// <summary>
        /// Pobiera i ustawia rok, w którym samochód został wyprodukowany.
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { _year = ValidateYear(value); }
        }
    }
}
