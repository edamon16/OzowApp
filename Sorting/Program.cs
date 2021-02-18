using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            SortingFacade sorting = new SortingFacade();
            Console.WriteLine("please enter text than press enter");
            string[] value = { Console.ReadLine() };
            var result = sorting.Sorting(value);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
