using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    class Instruction
    {
        private string instruction;
        private Rider rider;

        public Instruction(string instruction)
        {
            this.instruction = instruction;

            string[] tokens = instruction.Split(' ');

            rider = new Rider(UInt32.Parse(tokens[0].TrimStart('R')).AddInstruction(line));

        }
    }
}
