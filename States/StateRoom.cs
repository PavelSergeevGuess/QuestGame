

namespace MyQuest
{
    class StateRoom
        : State
    {       
        private Room room;
        public StateRoom(Stack<State> states, Room room)
            : base(states)
        {
            this.room = room;
        }

        override public void Update()
        {
            this.room.RunAction();
            if (this.room.RequestEnd())
                this.end = true;
        }
    }
}
