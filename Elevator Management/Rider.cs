using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    internal struct Rider
    {
        public readonly string ID;

        public Instruction instruction { get; set; }

        public Rider(Instruction instruction)
        {
            ID = instruction.riderID;
            this.instruction = instruction;
        }
    }
}
