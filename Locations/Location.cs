

namespace MyQuest
{
    class Location
    {
        protected List <Character> characters;
        protected Dictionary<string, Action> locationOptions;
        protected GameAction action;
        protected bool end;


        public Location()
        {
            
        }

        virtual public void RunAction()
        {

        }

        protected void GetBack()
        {
            this.end = true;
        }

        public bool RequestEnd()
        {
            var tempend = this.end;
            this.end = false;
            return tempend;
        }
    }
}
