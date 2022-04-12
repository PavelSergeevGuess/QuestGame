

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
            this.RunStartDialogue();
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
                    if (this.AskForQuit())
                    {
                        locationDict = LocationContainer.GetStartLocation();
                        this.end = true;
                        break;
                    }
                    break;
                default:
                    break;
            }
        }

        private bool AskForQuit()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("Вы точно хотите выйти?");
            Console.WriteLine("Несохраненные данные будут утеряны");
            Console.ResetColor();
            var toPrint = new List<string> { "Выйти", "Остаться" };
            Gui.PrintOptionGame(toPrint);
            var playerChoice = Console.ReadKey(true).Key;
            switch (playerChoice)
            {
                case ConsoleKey.D1:
                    return true;
                case ConsoleKey.D2:
                    return false;
            }
            return false;
        }

        private void RunStartDialogue()
        {
            Gui.DescriptionMessage("В нижнем мире, или как его еще называют, гетто, считается нормальным грабить и убивать");
            Gui.DescriptionMessage("Все равно никто не интересуется судьбами тех людей, что погибают на улицах");
            Gui.DescriptionMessage("Солнце уже садится и вы, как и подобает разбойнику, ищете себе развлечение на вечер");
            Console.WriteLine();
            Gui.Dialogue(eventPoints.player.GetName(), "Пожалуй, сегодня мне не помешает немного пива");
            Gui.Dialogue(eventPoints.player.GetName() + " (с ухмылкой)", "Надеюсь, деньги на него сами меня найдут");
            Console.WriteLine();
        }
    }
}
