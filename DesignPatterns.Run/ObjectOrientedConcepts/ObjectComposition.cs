using System;

//[Object Composition Example] - How to enable code reuse without using inheritance.
namespace DesignPatterns.ObjectOrientedConcepts.ObjectComposition
{
    /// <summary>
    /// Represents a helper class for performing mathematical operations. 
    /// </summary>
    public class MathHelper
    {
        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The sum of 'a' and 'b'.</returns>
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    /// <summary>
    /// Represents an accounting process that uses object composition.
    /// </summary>
    public class Accounting
    {
        private readonly MathHelper _mathHelper;

        public Accounting()
        {
            // Initialize the MathHelper object for performing mathematical operations.
            _mathHelper = new MathHelper();
        }

        /// <summary>
        /// Generates an invoice and calculates the total invested amount.
        /// </summary>
        public void GenerateInvoice()
        {
            var initialInvestedAmount = 1000;
            var additionalInvestedAmount = 100;

            // Calculate the total invested amount using the MathHelper's Add method.
            var totalInvestedAmount = _mathHelper.Add(initialInvestedAmount, additionalInvestedAmount);

            Console.WriteLine($"Total invested amount = {totalInvestedAmount}");
        }
    }
}