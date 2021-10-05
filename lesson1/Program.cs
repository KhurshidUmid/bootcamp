using System;
using System.Linq;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(int.MaxValue.ToString() + " " + int.MinValue.ToString());
            // string input = Console.ReadLine();
            // Console.WriteLine("jsd,kj: " + input);
            var inputs = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            // foreach(string input in inputs)
            // {
            //     // int son = int.Parse(input);
            //     // Console.WriteLine(son * 10);

            //     int son = 0;
            //     bool parsed = int.TryParse(input, out son);
            //     if(parsed)
            //     {
            //         System.Console.WriteLine(son);
            //     }
            //     else
            //     {
            //         System.Console.WriteLine("Not son");
            //     }
            // }

            // var ints = inputs.Select(i => int.Parse(i)).ToList();
            var ints = inputs.Select(i => 
            {
                int son = int.Parse(i);
                Console.WriteLine(son); 
                return son;
            }). ToList();

        }
    }
}
