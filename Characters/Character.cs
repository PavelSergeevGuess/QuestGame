

namespace MyQuest
{
    public class Character
    {
        public string name { get; set; }
        public List <string> dialogues { get; set; }
        public string description { get; set; }
        protected Dictionary<string, Action> charOptions;
        public Character()
        {

        }

        public Dictionary<string, Action> GetActions()
        {
            return this.charOptions;
        }
    }
}
