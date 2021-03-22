using System;

namespace Basic
{
    class StringContains

    {
        static void Main(string[] args)
        {
            string userName = "bikang";
            string date = DateTime.Today.ToShortDateString();
            string strPlus = "Hello " + userName + ". Today is " + date + ".";
            Console.WriteLine(strPlus);
            string strFormat = String.Format("Hello {0}. Today is {1}.", userName, date);
            Console.WriteLine(strFormat);
            string strInterpolation = $"Hello {userName}. Today is {date}.";
            System.Console.WriteLine(strInterpolation);
            //string name = "bikang";
            //int age = 12;
            //Console.WriteLine($"{name} is {age} year{(age == 1 ? "" : "s")} old.");
            //Console.WriteLine(name + " is " + age + " year" + (age == 1 ? "" : "s") + " old.");
            string strConcat = String.Concat("Hello ", userName, ". Today is ", date, ".");
            Console.WriteLine(strConcat);
            string[] animals = { "mouse", "cow", "tiger", "rabbit", "dragon" };
            string s = String.Concat(animals);
            Console.WriteLine(s);
            s = String.Join(", ", animals);
            Console.WriteLine(s);
            int i = s1.IndexOf(s2, StringComparison.CurrentCultureIgnoreCase);
            if (i >= 0)
            {
                Console.WriteLine("'{0}' is in the string '{1}' ", s2, s1);
                Console.WriteLine("at index {0} (case insensitive)", i);



            }
    }
}


