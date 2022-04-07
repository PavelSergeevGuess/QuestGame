namespace MyQuest
{
    public class EventPoints
    {
        // Изменяемые объекты и отметки о прохождении событий игрового мира
        public Player player;
        public bool tavernStrangerRobbed;
        public bool tavernLookAround;

        public EventPoints()
        {
            this.player = new Player();
            this.tavernStrangerRobbed = false;
            this.tavernLookAround = false;
        }
        public void SetDefault()
        {
            this.player = null;
            this.tavernStrangerRobbed = false;
            this.tavernLookAround = false;
        }
    }
}
