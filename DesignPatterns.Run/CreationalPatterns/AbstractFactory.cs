using System;

namespace DesignPatterns.CreationalPatterns.AbstractFactory
{
    // Abstract Product interface
    public interface IComponent
    {
        void DisplayInfo();
    }

    // Concrete Products
    public class CPU17 : IComponent
    {
        public void DisplayInfo()
        {
            Console.WriteLine("This is an Intel Core i7 CPU.");
        }
    }

    public class GPUNvidia : IComponent
    {
        public void DisplayInfo()
        {
            Console.WriteLine("This is an Nvidia GPU.");
        }
    }

    // Abstract Factory interface
    public interface IComputerFactory
    {
        IComponent CreateCPU();
        IComponent CreateGPU();
    }

    // Concrete Factory
    public class HighEndComputerFactory : IComputerFactory
    {
        public IComponent CreateCPU()
        {
            return new CPU17(); // Creates a CPU17 component
        }

        public IComponent CreateGPU()
        {
            return new GPUNvidia(); // Creates a GPUNvidia component
        }
    }

    // Test class to demonstrate Factory usage
    public class TestPaymentProcessorFactory
    {
        public void EntryPoint()
        {
            // Create a factory for high-end computers
            IComputerFactory factory = new HighEndComputerFactory();
            
            // Create CPU and GPU components using the factory
            IComponent cpu = factory.CreateCPU();
            IComponent gpu = factory.CreateGPU();

            // Display information about the created components
            cpu.DisplayInfo();
            gpu.DisplayInfo();
        }
    }
}
