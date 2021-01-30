using System;

namespace Algorithms
{
    // так же мног оинформации на сайте https://programm.top/c-sharp/, не реклама =)
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArr = new int[] { 6, 3, 8, 2, 6, 9, 4, 11, 1 };
            Console.WriteLine(string.Join(",", Sorting.QuickSorting(testArr)));
            //Console.WriteLine(string.Join(",", Sorting.Selection(testArr)));
            Console.ReadKey();
        }
    }
}
