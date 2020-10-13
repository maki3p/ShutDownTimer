using System;
using System.Diagnostics;

namespace ShutDownTimer
{
    class Program
    {
        public class ShutDownClass
        {
            public int Minuts { get; set; }
            public DateTime DateTime { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=================== Shutdown PC =======================");
            ShutDown();
        }

        public static void ShutDown()
        {
            ShutDownClass shutDown = new ShutDownClass();

            Console.WriteLine("Choice Option");
            Console.WriteLine("Press 1 to schedule a shutdown");
            Console.WriteLine("Press 2 to cancel previues scheduled shutdown");
            Console.WriteLine("Press 3 for exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter Minutes");
                    shutDown.Minuts = Convert.ToInt32(Console.ReadLine());
                    ShutdownApp(shutDown.Minuts);
                    break;
                case "2":
                    CancelShutdown();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("You choice is not valid");
                    Console.WriteLine("-------------------------------------------------------");
                    ShutDown();
                    break;
            }
        }
        public static void ShutdownApp(int? minutes = null, DateTime? date = null)
        {
            if (minutes.HasValue)
            {
                var timer = minutes * 60;

                Process.Start("shutdown.exe", "/a");
                Process.Start("shutdown.exe", "-s -t " + timer + "");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Your pc will be shutdown in " + minutes + " minutes!");
                Console.WriteLine("-------------------------------------------------------");


            }

            ShutDown();
        }

        public static void CancelShutdown()
        {

            Process.Start("shutdown.exe", "/a");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("previous scheduled shutdown was canceled!");
            Console.WriteLine("-------------------------------------------------------");
            ShutDown();

        }

    }
}
