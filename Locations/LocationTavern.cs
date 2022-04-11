

namespace MyQuest
{
    class LocationTavern
        : Location
    {
        private CharStranger stranger;
        public LocationTavern()
        {
            this.locationOptions = new Dictionary<string, Action>
            {
                { "Осмотреться", this.LookAround },
                { "Вернуться", this.GetBack }
            };
            this.characters = new List<Character>();
            this.stranger = new CharStranger("Бродяга");
            this.characters.Add(this.stranger);
            this.action = new GameAction(this.locationOptions);
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
            if (StateGame.eventPoints.tavernLookAround == true && !this.locationOptions.ContainsKey("Обокрасть бродягу"))
            {
                this.locationOptions.Add("Обокрасть бродягу", RobStranger);
                this.action = new GameAction(this.locationOptions);
            }
            if (StateGame.eventPoints.tavernStrangerRobbed == true && !this.locationOptions.ContainsKey("Отправиться домой"))
            {
                this.locationOptions.Add("Отправиться домой", GoHome);
                this.action = new GameAction(this.locationOptions);
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

        private void GoHome()
        {
            Console.Clear();
            Gui.DescriptionMessage("Вы отправляетесь к себе домой");
            this.GetBack();
            StateGame.locationDict = LocationContainer.GetLocationPt1();
            MyGame.PressAnyKeyToContinue();
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
