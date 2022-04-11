namespace MyQuest
{
    public static class Program
    {
        public static MyGame game;
        static void Main()
        {
            game = new MyGame();
            Gui.Title("Добро пожаловать в этот мир!");
            game.Run();
        }

        public static void AddStateLocation(Location location)
        {
            game.AddStateLocation(location);
        }

        public static void ReplaceStateLocation(Location location)
        {
            game.ReplaceStateLocation(location);
        }
    }
}