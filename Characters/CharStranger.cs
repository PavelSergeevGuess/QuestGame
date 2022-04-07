

namespace MyQuest
{
    class CharStranger
        : Character
    {
        public CharStranger(string name)
        {
            this.name = name;
            this.dialogues = new List<string>
            {
                "Деньги или смерть, грязный бродяга!",
                "Вот возьми всё что у меня есть, только не трогай меня\n",
                "Я теперь умру с голоду!",
                "У меня больше ничего нет"
            };
            this.description = "Человек с темным прошлым, к которому не стоит лишний раз обращаться за помощью";
            this.charOptions = new Dictionary<string, Action>
            {
                { "Взять все что у него есть", RobStranger },
                { "Оставить бродягу в покое", LeaveStranger }
            };
        }

        private void RobStranger()
        {
            StateGame.eventPoints.player.AddItem("Золотой медальон");
            StateGame.eventPoints.player.ChangeMoney(50);
            Console.WriteLine();
            Gui.Dialogue(this.name, this.dialogues[2]);
            MyGame.PressAnyKeyToContinue();
        }

        private void LeaveStranger()
        {
            Gui.DescriptionMessage("Бродяга всадил вам нож в спину как только вы отвернулись");
            MyGame.PressAnyKeyToContinue();
            Gui.Title("Конец игры");
            Environment.Exit(0);
        }
    }
}
