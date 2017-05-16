using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var arr = new int[10];
            int j;

            for (int i = 0; i < arr.Length; i++)
                arr[i] = i;
            

            foreach (int i in arr)
                Console.WriteLine($"{i}");
            
        }
    }
}
