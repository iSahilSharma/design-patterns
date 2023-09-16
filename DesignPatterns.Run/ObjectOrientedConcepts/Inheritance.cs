using System;

//[Inheritance Example] - How to enable code reuse without using object composition.
namespace DesignPatterns.ObjectOrientedConcepts.Inheritance
{
    /// <summary>
    /// Base class for performing mathematical operations.
    /// </summary>
    public class MathHelper
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    /// <summary>
    /// Represents an accounting process that inherits from MathHelper.
    /// </summary>
    public class Accounting : MathHelper
    {
        public void GenerateInvoice()
        {
            var initialInvestedAmount = 1000;
            var additionalInvestedAmount = 100;

            // Calculate the total invested amount using the inherited Add method.
            var totalInvestedAmount = Add(initialInvestedAmount, additionalInvestedAmount);

            Console.WriteLine($"Total invested amount = {totalInvestedAmount}");
        }
    }
}
