

namespace MyQuest
{
    class StateLocation
        : State
    {       
        private Location location;
        public StateLocation(Stack<State> states, Location location)
            : base(states)
        {
            this.location = location;
        }

        override public void Update()
        {
            this.location.RunAction();
            if (this.location.RequestEnd())
                this.end = true;
        }
    }
}
