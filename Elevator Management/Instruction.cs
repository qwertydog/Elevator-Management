using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    internal struct Instruction
    {
        public readonly string riderID;
        public readonly uint startTime, fromFloor, toFloor;

        public bool isCompleted;
        
        public Instruction(string instruction)
        {
            string[] tokens = instruction.Split(' ');

            riderID = tokens[0];
            startTime = uint.Parse(tokens[1]);
            fromFloor = uint.Parse(tokens[2]);
            toFloor = uint.Parse(tokens[3]);

            isCompleted = false;

            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return riderID + ' ' + 
                startTime.ToString() + ' ' + 
                fromFloor.ToString() + ' ' + 
                toFloor.ToString();
        }
    }
}
