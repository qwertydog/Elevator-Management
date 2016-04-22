using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    static class InputData
    {
        private static Elevator[] elevators;
        private static Rider[] riders;
        private static List<Instruction> instructions;

        public static void ReadFromFile(string fileName)
        {
            try
            {
                StreamReader file = new StreamReader(fileName);

                for (int i = 0; i < Int32.Parse(file.ReadLine()); ++i)
                {
                    string[] tokens = file.ReadLine().Split(' ');

                    elevators[i] = new Elevator(UInt32.Parse(tokens[0]), float.Parse(tokens[1]), UInt32.Parse(tokens[2]));
                }

                for (int i = 0; i < Int32.Parse(file.ReadLine()); ++i)
                {
                    string line = file.ReadLine();
                    string[] tokens = line.Split(' ');

                    instructions.Add(new Instruction(line));

                    riders[UInt32.Parse(tokens[0].TrimStart('R'))].AddInstruction(line);
                }
            } 
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        public static void Run()
        {
            foreach (var instruction in instructions)
            {
                //
            }
        }

        public static Elevator ChooseElevator()
        {
            foreach (var elevator in elevators)
            {
                if (elevator.GetRiders().Count() < elevator.capacity)
                {
                    return elevator;
                }
            }
            throw new Exception();
        }
    }
}
