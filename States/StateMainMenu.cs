

namespace MyQuest
{
    class StateMainMenu
        : State
    {
        public StateMainMenu(Stack<State> states)
            : base(states)
        {

        }

        override public void Update()
        {
            Gui.MenuTitle("Главное меню");
            List <string> options = new List<string>
            {
                "Начать игру",
                "Загрузить",
                "Выйти из игры"
            };
            Gui.PrintOptionMenu(options);
            var playerChoice = Console.ReadKey(true).Key;
            Console.Clear();
            this.ProcessInput(playerChoice);
        }

        public void ProcessInput(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    this.states.Push(new StateGame(this.states));
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.Escape:
                    this.end = true;
                    break;
                default:
                    break;
            }
        }
    }
}
