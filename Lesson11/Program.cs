using System;

namespace Lesson11
{
    class Program
    {
        static void Main(string[] args)
        {
            // var name = "xusan";
            // name = name.Capitalize();
            // Console.WriteLine($"{name}");

            var text = "12334";
            System.Console.WriteLine($"{ text.ToInt() }");

            text.TryToInt(out var x);
            System.Console.WriteLine($"{ x/100}");

        }
    }
}
