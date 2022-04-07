namespace MyQuest
{
    class Gui
    {
        public static void Title(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            str = string.Format("=== {0} ===\n\n", str);
            Console.Write(str);
            Console.ResetColor();
        }

        public static void MenuTitle(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            str = string.Format("--{0}--\n\n", str);
            Console.Write(str);
            Console.ResetColor();
        }

        public static void PrintOptionGame(List<string> options)
        {
            string str;
            for (int i = 0; i < options.Count; i++)
            {
                str = string.Format("{0}. {1}\n", i + 1, options[i]);
                Console.Write(str);
            }
        }

        public static void PrintOptionMenu(List<string> options)
        {
            string str;
            for (int i = 0; i < options.Count - 1; i++)
            {
                str = string.Format("{0}. {1}\n", i + 1, options[i]);
                Console.Write(str);
            }
            str = string.Format("Esc. {0}\n", options[options.Count - 1]);
            Console.Write(str);
        }

        public static void DescriptionMessage(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            var splitstr = str.Split('\n');
            foreach (var line in splitstr)
            {
                str = string.Format(" - {0}\n", line);
                Console.Write(str);
            }
            Console.ResetColor();
        }

        public static void Dialogue(string speaker, string str)
        {
            str = string.Format("{0}: {1}\n", speaker, str);
            Console.Write(str);
        }

        public static void PlayerMoney(int money)
        {
            var str = string.Format(" - Ваши деньги: {0}\n", money);
            Console.Write(str);
        }

        public static void PlayerName(string str)
        {
            str = string.Format(" - Ваше имя: {0}\n", str);
            Console.Write(str);
        }

        public static void PlayerItems(List<string> items)
        {
            Console.Write("Ваш инвентарь:\n");
            foreach (var item in items)
            {
                var str = string.Format(" - {0}\n", item);
                Console.Write(str);
            }
        }

        public static void NewItem(string item)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var str = string.Format("Вы получили новый предмет: {0}\n", item);
            Console.Write(str);
            Console.ResetColor();
        }

        public static void RemoveItem(string item)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var str = string.Format("Вы лишились предмета: {0}\n", item);
            Console.Write(str);
            Console.ResetColor();
        }

        public static void MoneyChange(int money)
        {
            string str;
            if (money < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                str = string.Format("Ваше состояние уменьшелилось на {0} монет\n", -1 * money);
                Console.Write(str);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                str = string.Format("Вы получили {0} монет\n", money);
                Console.Write(str);
                Console.ResetColor();
            }
        }
    }
}
