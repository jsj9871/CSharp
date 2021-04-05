using System;

namespace Class
{
    class PropertyWithoutField
    {
        public string Message
        {
            get { return Console.ReadLine(); }
            set { Console.WriteLine(value); }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            PropertyWithoutField obj = new PropertyWithoutField();
            obj.Message = obj.Message;




        }
    }
}

