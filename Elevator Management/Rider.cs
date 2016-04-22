using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    class Rider
    {
        private List<Instruction> instructions;
        private static uint nextID = 1;

        public string id { get; private set; }
        public uint time { get; private set; }
        public uint sourceFloor { get; private set; }
        public uint destinationFloor { get; private set; }

        public Rider(uint time, uint sourceFloor, uint destinationFloor)
        {
            id = "R" + nextID++;
            this.time = time;
            this.sourceFloor = sourceFloor;
            this.destinationFloor = destinationFloor;
        }

        public void AddInstruction(string instruction)
        {
            instructions.Add(new Instruction(instruction));
        }

    }
}
