

namespace MyQuest
{
    public class Player
    {
        private string name;
        private int money;
        public List<string> items;
        private void ChooseName()
        {
            Console.WriteLine("Введите ваше имя: ");
            this.name = Console.ReadLine();
            if (this.name == null || this.name == "")
                ChooseName();
            Console.Clear();
        }
        public Player()
        {
            ChooseName();
            this.money = 0;
            this.items = new List<string>();
        }


        public void AddItem(string item)
        {
            Gui.NewItem(item);
            this.items.Add(item);
        }

        public void RemoveItem(string item)
        {
            Gui.RemoveItem(item);
            this.items.Remove(item);
        }




        public void ChangeMoney(int money)
        {
            this.money += money;
            Gui.MoneyChange(money);
        }

        public bool HasEnoughMoney(int money)
        {
            if (this.money < money)
            {
                Gui.DescriptionMessage("Недостаточно денег!");
                return false;
            }
            return true;
        }





        public void PrintItems()
        {
            Gui.PlayerItems(this.items);
        }

        public void PrintMoney()
        {
            Gui.PlayerMoney(this.money);
        }


        public void PrintName()
        {
            Gui.PlayerName(this.name);
        }





        public bool GetItemExist(string item)
        {
            return this.items.Contains(item);
        }

        public int GetMoney()
        {
            return this.money;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
