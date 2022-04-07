namespace MyQuest
{
    public static class Program
    {
        static void Main()
        {
            MyGame game = new MyGame();
            Gui.Title("Добро пожаловать в этот мир!");
            game.Run();
        }
    }
}