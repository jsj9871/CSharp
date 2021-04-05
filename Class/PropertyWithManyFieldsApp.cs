using System;

namespace Class
{
    class PropertyWithManyFields
    {
        private string text = "Dept. of Software";
        private bool isModified = false;
        public string Text
        {
            get { return text; }
            set { text = value; isModified = true; }
        }
        public void PrintStatus()
        {
            Console.WriteLine("text is \"" + text + "\", and " +
            (isModified ? "is" : "not") + " modified.");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            PropertyWithManyFields obj = new PropertyWithManyFields();
            obj.PrintStatus();
            obj.Text = "Programming Language Lab";
            obj.PrintStatus();





        }
    }
}

