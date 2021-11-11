using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            var noti = new Notification();

            noti.StartListening();

            Console.ReadKey();
            
        }
    }
}
