

namespace MyQuest
{
    class Room
    {
        public static Dictionary<string, Room> roomDict = new Dictionary<string, Room>
        {
            { "Таверна", new RoomTavern() },
            { "-------", new Room() }
        };
        public static void SetDefault()
        {
            roomDict = new Dictionary<string, Room>
            {
               { "Таверна", new RoomTavern() },
               { "-------", new Room() }
            };
        }



        protected string roomName;
        protected List <Character> characters;
        protected Dictionary<string, Action> roomOptions;
        protected GameAction action;
        protected bool end;


        public Room()
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
