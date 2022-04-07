

namespace MyQuest
{
    public class StateGame
        : State
    {
        public static EventPoints eventPoints;
        static Dictionary<string, Room> roomDict;

        public StateGame(Stack<State> states)
            : base(states)
        {
            eventPoints = new EventPoints();
            roomDict = Room.roomDict;
        }
        override public void Update()
        {
            Gui.MenuTitle("Выберите локацию");
            var toPrint = new List<string>(roomDict.Keys.ToList());
            toPrint.Add("Выйти в главное меню");
            Gui.PrintOptionMenu(toPrint);
            var playerChoice = Console.ReadKey(true).Key;
            this.ProcessInput(playerChoice);
            Console.Clear();
        }

        private void ProcessInput(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    this.states.Push(new StateRoom(this.states, roomDict.ElementAt(0).Value));
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.Escape:
                    eventPoints.SetDefault();
                    Room.SetDefault();
                    this.end = true;
                    break;
                default:
                    break;
            }
        }
    }
}
