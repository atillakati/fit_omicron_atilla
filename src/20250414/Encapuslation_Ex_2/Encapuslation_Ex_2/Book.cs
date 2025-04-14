using System;

namespace Encapuslation_Ex_2
{
    public class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _nextAvailability;
        private BookLendingState _lendingState;


        public Book(string title, string author, string isbn)
        {
            _title = title;
            _author = author;
            _isbn = isbn;

            _nextAvailability = DateTime.Now;
            _lendingState = BookLendingState.Available;
        }


        public BookLendingState LendingState
        {
            get { return _lendingState; }
        }

        public DateTime NextAvailablility
        {
            get { return _nextAvailability; }
        }

        public string Isnb
        {
            get { return _isbn; }        
        }

        public string Author
        {
            get { return _author; }            
        }        

        public string Title
        {
            get { return _title; }
        }

        public void Display()
        {
            Console.WriteLine($"{_title} -  {_author} [ISBN: {_isbn}]");
            Console.WriteLine($"State: {_lendingState.ToString().ToUpper()} Next availability: {_nextAvailability.ToShortDateString()}");
        }

        public void Borrow(TimeSpan borrowDuration)
        {
            if(_lendingState != BookLendingState.Available)
            {
                return;
            }

            _lendingState = BookLendingState.Borrowed;
            _nextAvailability = _nextAvailability.Add(borrowDuration);
        }
    }
}