
namespace MyQuest
{
    public class State
    {
        protected bool end = false;
        protected Stack<State> states;
        public State(Stack<State> states)
        {
            this.states = states;
        }
        public bool RequestEnd()
        {
            return this.end;
        }
        virtual public void Update()
        {

        }
    }
}
