namespace MyQuest
{
    public class MyGame
    {
        private Stack<State> states;

        private void InitStates()
        {
            this.states = new Stack<State>();
            this.states.Push(new StateMainMenu(this.states));
        }
        
        public MyGame()
        {
            this.InitStates();
        }

        public void Run()
        {
            while (this.states.Count > 0)
            {
                this.states.Peek().Update();
                if (this.states.Peek().RequestEnd())
                {
                    this.states.Pop();
                }
            }
            Gui.Title("Конец игры");
        }

        public static void PressAnyKeyToContinue()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить");
            Console.ReadKey(true);
            Console.ResetColor();
        }

        public void AddStateLocation(Location location)
        {
            this.states.Push(new StateLocation(this.states, location));
        }

        public void ReplaceStateLocation(Location location)
        {
            this.states.Pop();
            this.states.Push(new StateLocation(this.states, location));
        }
    }
}