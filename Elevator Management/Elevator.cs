using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Management
{
    class Elevator
    {
        private enum Direction
        {
            Down,
            Up
        }

        private List<Rider> riders;
        private uint currentPosition;

        public uint targetFloor { private get; set; }
        public uint currentFloor {
            get
            {
                return currentPosition / 10;
            }
            private set { }
        }

        public uint RiderCount {
            get
            {
                return Convert.ToUInt32(riders.Count);
            }
            private set { }
        }

        public readonly string ID;
        public readonly uint capacity, speed, startingFloor;

        public Elevator(string ID, uint capacity, float speed, uint startingFloor)
        {
            riders = new List<Rider>();

            this.ID = ID;
            this.capacity = capacity;
            this.speed = Convert.ToUInt32(speed * 10);
            this.startingFloor = startingFloor;

            currentPosition = startingFloor * 10;
            //targetFloor = GetInitialTargetFloor();
        }

        public void AddRider(Rider rider)
        {
            if (riders.Count == capacity)
            {
                throw new InvalidOperationException();
            }
            else
            {
                riders.Add(rider);
            }
        }

        public void UpdateFloor()
        {
            
        }

        public void RemoveRider(Rider rider)
        {
            RemoveRider(rider.ID);
        }

        public void RemoveRider(string riderID)
        {
            riders.RemoveAll(x => x.ID == riderID);
        }

        public void Move()
        {
            var targetPosition = targetFloor * 10;

            if (targetPosition > currentPosition)
            {
                Move(Direction.Up);
            }
            else if (targetFloor < currentPosition)
            {
                Move(Direction.Down);
            }
        }

        private void Move(Direction direction)
        {
            if (direction == Direction.Down)
            {
                currentPosition -= speed;
            }
            else if (direction == Direction.Up)
            {
                currentPosition += speed;
            }
        }

        /*private uint GetInitialTargetFloor()
        {
            uint numBuildingSections = InputData.Instance.numElevators + 1;
            double potentialFloor = InputData.Instance.numFloors / Convert.ToDouble(numBuildingSections);

            if (startingFloor > potentialFloor)
            {
                return Convert.ToUInt32(Math.Round(InputData.Instance.numFloors - potentialFloor));
            }
            else
            {
                return Convert.ToUInt32(Math.Round(potentialFloor));
            }
        }*/

        /*private uint GetNewTargetFloor()
        {   
            int newFloor = Convert.ToInt32(riders.First().Instruction.toFloor);
            int currentFloor = Convert.ToInt32(targetFloor);

            foreach (var rider in riders)
            {
                if (Math.Abs(newFloor - currentFloor) > Math.Abs(rider.Instruction.toFloor - currentFloor))
                {
                    newFloor = Convert.ToInt32(rider.Instruction.toFloor);
                }
            }

            return Convert.ToUInt32(newFloor);
            
            return 0;
        }*/
    }
}
