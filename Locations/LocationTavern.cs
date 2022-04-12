

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
                { "Вернуться", this.GetBack },
                { "Выпить пива (15 монет)", this.DrinkBeer }
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
            if (StateGame.eventPoints.tavernLookAround == true
                && !this.locationOptions.ContainsKey("Обокрасть бродягу")
                && !(StateGame.eventPoints.tavernBeerDrinked == 3))
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

        private void LookAround()
        {
            Console.Clear();
            if (StateGame.eventPoints.tavernStrangerRobbed == false)
                Gui.DescriptionMessage("Таверна маленькая, почти никого нет внутри\n" +
                                       "Вы замечаете, что какой-то бродяга сидит в углу и пристально смотрит на вас\n" +
                                       "У бродяги шрам на глазу, неопрятный вид, руки спрятаны за спиной");
            else if (StateGame.eventPoints.tavernStrangerRobbed == true && !(StateGame.eventPoints.tavernBeerDrinked == 3))
                Gui.DescriptionMessage("Бродяга продолжает сидеть на своем месте, ожидая чего-то");
            else
                Gui.DescriptionMessage("Тело хозяина таверны лежит неподвижно\n" +
                                       "Бродяга покинул таверну, проследить за ним не получится");
            StateGame.eventPoints.tavernLookAround = true;
            MyGame.PressAnyKeyToContinue();
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
            Gui.Dialogue(StateGame.eventPoints.player.GetName(), "С этим бродягой явно что-то не так...");
            Gui.Dialogue("Встречный прохожий", "А я то думал я один сам с собой болтаю!");
            Gui.Dialogue(StateGame.eventPoints.player.GetName(), "Проваливай, живо");
            Program.ReplaceStateLocation(new LocationHome());
            MyGame.PressAnyKeyToContinue();
        }



        private void DrinkBeer()
        {
            var beerPrice = 15;
            if (StateGame.eventPoints.player.HasEnoughMoney(beerPrice))
            {
                StateGame.eventPoints.player.ChangeMoney(-beerPrice);
                Gui.DescriptionMessage("Хозяин таверны налил вам пиво");
                Console.WriteLine();
                switch (StateGame.eventPoints.tavernBeerDrinked)
                {
                    case 0:
                        Gui.DescriptionMessage("Вы замечаете, что бродяга пристально наблюдает за вами");
                        StateGame.eventPoints.tavernBeerDrinked += 1;
                        break;
                    case 1:
                        Gui.DescriptionMessage("Хозяин таверны, кажется, дрожит");
                        Gui.Dialogue("Хозяин таверны", "Я скоро закрываю таверну, тебе пора завязывать");
                        StateGame.eventPoints.tavernBeerDrinked += 1;
                        break;
                    case 2:
                        Gui.DescriptionMessage("Бродяга подходит к стойке и вонзает кинжал в сердце хозяина таверны");
                        Gui.Dialogue(this.stranger.name, this.stranger.dialogues[4]);
                        this.locationOptions = new Dictionary<string, Action>
                        {
                            { "Осмотреться", this.LookAround },
                        };
                        StateGame.eventPoints.tavernBeerDrinked += 1;
                        break;
                    default:
                        break;
                }
            }
            MyGame.PressAnyKeyToContinue();
        }
    }
}
