using System;

namespace DesignPatterns.Run
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine($"Design Patterns Refresher");

            //var accounting = new ObjectOrientedConcepts.ObjectComposition.Accounting();
            var accounting = new ObjectOrientedConcepts.Inheritance.Accounting();
            accounting.GenerateInvoice();
        }
    }
}
