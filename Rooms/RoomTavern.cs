

namespace MyQuest
{
    class RoomTavern
        : Room
    {
        private CharStranger stranger;
        public RoomTavern()
        {
            this.roomOptions = new Dictionary<string, Action>
            {
                { "Осмотреться", this.LookAround },
                { "Вернуться", this.GetBack }
            };
            this.roomName = "Таверна";
            this.characters = new List<Character>();
            this.stranger = new CharStranger("Бродяга");
            this.characters.Add(this.stranger);
            this.action = new GameAction(this.roomOptions);
        }

        override public void RunAction()
        {
            Gui.MenuTitle("Вы находитесь в таверне");
            this.UpdateTavernOptions();
            this.action.ProcessAction().Invoke();
            Console.Clear();
        }

        private void UpdateTavernOptions()
        {
            if (StateGame.eventPoints.tavernLookAround == true && !this.roomOptions.ContainsKey("Обокрасть бродягу"))
            {
                this.roomOptions.Add("Обокрасть бродягу", RobStranger);
                this.action = new GameAction(this.roomOptions);
            }
        }

        private void RobStranger()
        {
            if (StateGame.eventPoints.tavernStrangerRobbed == false)
            {
                var strangerActions = this.stranger.GetActions();
                var action = new GameAction(strangerActions);
                Gui.Dialogue(StateGame.eventPoints.player.GetName(), this.stranger.dialogues[0]);
                Gui.Dialogue(this.stranger.name, this.stranger.dialogues[1]);
                action.ProcessAction().Invoke();
                StateGame.eventPoints.tavernStrangerRobbed = true;
            }
            else
            {
                Gui.Dialogue(this.stranger.name, this.stranger.dialogues[this.stranger.dialogues.Count - 1]);
                MyGame.PressAnyKeyToContinue();
            }

        }

        private void LookAround()
        {
            Console.Clear();
            if (StateGame.eventPoints.tavernStrangerRobbed == false)
                Gui.DescriptionMessage("Таверна маленькая, почти никого нет внутри\n" +
                                       "Вы замечаете, что какой-то бродяга сидит в углу и пристально смотрит на вас\n" +
                                       "У бродяги шрам на глазу, неопрятный вид, руки спрятаны за спиной");
            else
                Gui.DescriptionMessage("В таверне никто на вас не обращает внимания\n" +
                                       "Бродяга продолжает сидеть на своем месте, ожидая чего-то");
            StateGame.eventPoints.tavernLookAround = true;
            MyGame.PressAnyKeyToContinue();
        }
    }
}
