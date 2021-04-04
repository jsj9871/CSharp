using System;

namespace SentenceExample
{
    class A060_ArraySorting
    {
        static void Main(string[] args)
        {
            string[] name = { "Mouse", "Cow", "Tiger", "Rabiit", "Dragon", "Snake", "Horse" };
            PrintArray("Before Sort: ", name);
            Array.Reverse(name);
            PrintArray("After Reverse: ", name);
            Array.Sort(name);
            PrintArray("After Sort: ", name);
            Array.Reverse(name);
            PrintArray("After Reverse: ", name);
        }
        private static void PrintArray(string s, string[] name)
        {
            Console.WriteLine(s);
            foreach (var n in name)
                Console.Write("{0} ", n);
            Console.WriteLine();






        }
    }
}




















