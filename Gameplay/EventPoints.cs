namespace MyQuest
{
    public class EventPoints
    {
        // Изменяемые объекты и отметки о прохождении событий игрового мира
        public Player player;
        public bool tavernStrangerRobbed;
        public bool tavernLookAround;
        public int tavernBeerDrinked;

        public EventPoints()
        {
            this.player = new Player();
            this.tavernStrangerRobbed = false;
            this.tavernLookAround = false;
            this.tavernBeerDrinked = 0;
        }
    }
}
