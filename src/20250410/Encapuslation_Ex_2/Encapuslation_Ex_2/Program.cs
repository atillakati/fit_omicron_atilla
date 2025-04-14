using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapuslation_Ex_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book myBook = new Book("The art of programming", "Marting Fowler", "X-321654-321-635-0");

            myBook.Display();

            myBook.Borrow(TimeSpan.FromDays(5.0));

            myBook.Display();

            myBook.LendingState = BookLendingState.Available;

        }
    }
}
