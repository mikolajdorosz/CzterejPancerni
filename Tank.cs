using System;

namespace CzterejPancerni
{
    internal class Tank : ObjectToGather
    {
        private bool approachable;
        private bool efficient;
        
        public bool Approachable { 
            get { return approachable; } 
            private set { approachable = value; } }
        public bool Efficient { get; private set; }

        public Tank()
        {
            approachable = true;
            efficient = true;
        }
        public void GetIn()
        {
            approachable = true;
            Events.Add("+Tank", "");
        }
        public void GetOut()
        {
            approachable = false;
            Events.Add("-Tank", "");
        }
        public bool ChangeState() { return !efficient; }
    }
}
