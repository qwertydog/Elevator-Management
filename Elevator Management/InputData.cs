using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    internal class InputData
    {
        public static readonly InputData Instance; 

        private List<Elevator> elevators;
        private Queue<Instruction> instructions;

        static InputData()
        {
            Instance = new InputData();
        }

        private InputData()
        {
            elevators = new List<Elevator>();
            instructions = new Queue<Instruction>();
        }

        public uint numElevators { get; private set; }
        public uint numInstructions { get; private set; }

        //public uint numFloors { get; private set; }

        public void Parse(string fileName)
        {
            try
            {
                StreamReader file = new StreamReader(fileName);

                numElevators = uint.Parse(file.ReadLine());
                for (int i = 0; i < numElevators; i++)
                {
                    string line = file.ReadLine();
                    string[] tokens = line.Split(' ');
                    elevators.Add(new Elevator(tokens[0], uint.Parse(tokens[1]), float.Parse(tokens[2]), uint.Parse(tokens[3])));
                }

                numInstructions = uint.Parse(file.ReadLine());
                for (int i = 0; i < numInstructions; i++)
                {
                    string line = file.ReadLine();
                    var instruction = new Instruction(line);
                    instructions.Enqueue(instruction);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        public IEnumerable<Elevator> GetElevators()
        {
            return elevators.AsReadOnly();
        }

        public Instruction GetNextInstruction()
        {
            try
            {
                return instructions.Dequeue();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            
        }
    }
}
