using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    class Elevator
    {
        private static uint nextid = 1;
        private List<Rider> riders;

        public string id { get; private set;  }
        public uint capacity { get; private set; }
        public float speed { get; private set; }
        public uint startingFloor { get; private set; }
        public bool isReady { get; private set; }

        public Elevator(uint capacity, float speed, uint startingFloor)
        {
            id = "C" + nextid++;
            this.capacity = capacity;
            this.speed = speed;
            this.startingFloor = startingFloor;
            isReady = true;
        }

        public void AddRider(Rider rider)
        {
            if (riders.Count >= capacity)
            {
                throw new InsufficientMemoryException();
            }
            riders.Add(rider);
        }

        public Rider[] GetRiders()
        {
            return riders.ToArray();
        }

        public void RemoveRider(Rider rider)
        {
            riders.Remove(rider);
        }
    }
}
