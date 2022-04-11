

namespace MyQuest
{
    class StateGame
        : State
    {
        public static EventPoints eventPoints;
        public static Dictionary<string, Location> locationDict;

        public StateGame(Stack<State> states)
            : base(states)
        {
            eventPoints = new EventPoints();
            locationDict = LocationContainer.GetStartLocation();
        }
        override public void Update()
        {
            Gui.MenuTitle("Выберите локацию");
            var toPrint = new List<string>(locationDict.Keys.ToList());
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
                    this.states.Push(new StateLocation(this.states, locationDict.ElementAt(0).Value));
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.Escape:
                    eventPoints.SetDefault();
                    locationDict = LocationContainer.GetStartLocation();
                    this.end = true;
                    break;
                default:
                    break;
            }
        }
    }
}
