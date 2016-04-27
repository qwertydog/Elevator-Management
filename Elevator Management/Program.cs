using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Campbell\Documents\Visual Studio 2015\Projects\Elevator Management\Elevator Management\input.txt";
            InputData.Instance.Parse(fileName);

            var elevatorController = new ElevatorController();

            Instruction currentInstruction = InputData.Instance.GetNextInstruction();

            uint timer = 0;

            while (true)
            {
                elevatorController.Run(currentInstruction);

                try
                {
                    currentInstruction = InputData.Instance.GetNextInstruction();

                    while (timer != currentInstruction.startTime)
                    {
                        Console.WriteLine("Time is: {0}", timer);
                        timer++;
                    }

                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}