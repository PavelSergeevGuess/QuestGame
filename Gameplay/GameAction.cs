

namespace MyQuest
{
    public class GameAction
    {
        private Dictionary<ConsoleKey, string> actionsAndKeysDict;
        private Dictionary<string, Action> actions;
        public GameAction(Dictionary<string, Action> actions)
        {
            this.actions = actions;
            this.CreateDictionary();
        }

        private void CreateDictionary()
        {
            this.actionsAndKeysDict = new Dictionary<ConsoleKey, string>();
            for (int i = 0; i < this.actions.Count; i++)
            {
                ConsoleKey key = (ConsoleKey) (i + 49);
                this.actionsAndKeysDict[key] = this.actions.ElementAt(i).Key;
            }
        }

        public Action ProcessAction()
        {
            Gui.PrintOptionGame(this.actions.Keys.ToList());
            var playerChoice = Console.ReadKey(true).Key;
            Console.Clear();
            if (this.actionsAndKeysDict.ContainsKey(playerChoice))
            {
                var act = this.actionsAndKeysDict[playerChoice];
                return this.actions[act];
            }
            return ProcessAction();
        }
    }
}
