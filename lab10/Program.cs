using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Program
    {
        public static Queue<Goods> queue = new Queue<Goods>();
        
        public static int IntInput(string sentence, int minBorder = int.MinValue, int maxBorder = int.MaxValue)
        {
            int result = 0;
            bool ok = true;
            do
            {
                Console.Write(sentence);
                ok = int.TryParse(Console.ReadLine(), out result);
                if (result < minBorder || result > maxBorder)
                {
                    ok = false;
                }
            }
            while (!ok);
            return result;
        }
        static void MenuCollection1()
        {
            bool created = false;
            bool sorted = false;
            int answer = 0;
            do
            {
                Console.WriteLine("-----------\nЗадание 1. Колллекция Queue\n" +
                    "1. Сгенерировать коллекцию\n" +
                    "2. Добавить элемент\n" +
                    "3. Удалить элемент\n" +
                    "4. Найти найти самую дорогую и дешевую игрушки\n" +
                    "5. Показать список всех товаров, имеющих срок годности\n" +
                    "6. Показать молочные продукты\n" +
                    "7. Печать коллекции\n" +
                    "8. Скопировать коллекцию \n" +
                    "9. Отсортировать коллекцию\n" +
                    "10. Найти элемент\n" +
                    "11. Назад");
                answer = IntInput("Пункт меню:", 1, 11);
                if(answer == 1)
                {
                    Menu1.GenerationMenu(out queue);
                    created = true;
                }
                if (created && answer != 11)
                {
                    switch (answer)
                    {

                        case 2:
                            Menu1.AddMenu(queue);
                            break;
                        case 3:
                            Menu1.DeleteMenu(queue);
                            break;
                        case 4:
                            Menu1.ShowCheapExpensive(queue);
                            break;
                        case 5:
                            Menu1.ShowDateExpiration(queue);
                            break;
                        case 6:
                            Menu1.ShowOnlyMilkProducts(queue);
                            break;
                        case 7:
                            foreach (Goods g in queue)
                            {
                                g.Show();
                            }
                            break;
                        case 8:
                            Menu1.Copy(queue);
                            break;
                        case 9:
                            if (sorted)
                            {
                                Console.WriteLine("Коллекция уже отсортирована");
                            }
                            else
                            {
                                Menu1.Sort(ref queue);
                            }
                            break;
                        case 10:
                            Menu1.Search(queue);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Коллекция ещё не создана");
                }
                
            } while (answer != 11);
        }
        static void MenuCollection2()
        {
            bool created = false;
            bool sorted = false;
            int answer = 0;
            do
            {
                Console.WriteLine("-----------\nЗадание 1. Колллекция Stack\n" +
                    "1. Сгенерировать коллекцию\n" +
                    "2. Добавить элемент\n" +
                    "3. Удалить элемент\n" +
                    "4. Найти найти самую дорогую и дешевую игрушки\n" +
                    "5. Показать список всех товаров, имеющих срок годности\n" +
                    "6. Показать молочные продукты\n" +
                    "7. Печать коллекции\n" +
                    "8. Скопировать коллекцию \n" +
                    "9. Отсортировать коллекцию\n" +
                    "10. Найти элемент\n" +
                    "11. Назад");
                answer = IntInput("Пункт меню:", 1, 11);
                if (answer == 1)
                {
                    Menu1.GenerationMenu(out queue);
                    created = true;
                }
                if (created && answer != 11)
                {
                    switch (answer)
                    {

                        case 2:
                            Menu1.AddMenu(queue);
                            break;
                        case 3:
                            Menu1.DeleteMenu(queue);
                            break;
                        case 4:
                            Menu1.ShowCheapExpensive(queue);
                            break;
                        case 5:
                            Menu1.ShowDateExpiration(queue);
                            break;
                        case 6:
                            Menu1.ShowOnlyMilkProducts(queue);
                            break;
                        case 7:
                            foreach (Goods g in queue)
                            {
                                g.Show();
                            }
                            break;
                        case 8:
                            Menu1.Copy(queue);
                            break;
                        case 9:
                            if (sorted)
                            {
                                Console.WriteLine("Коллекция уже отсортирована");
                            }
                            else
                            {
                                Menu1.Sort(ref queue);
                            }
                            break;
                        case 10:
                            Menu1.Search(queue);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Коллекция ещё не создана");
                }

            } while (answer != 11);
        }
        static void Main(string[] args)
        {
            int answer = 0;
            do
            {
                Console.WriteLine("" +
                    "1. Задание 1\n" +
                    "2. Задание 2\n" +
                    "3. Задание 3\n" +
                    "4. Выход");
                answer = IntInput("Пункт меню: ", 1, 4);
                switch (answer)
                {
                    case 1:
                        MenuCollection1();
                        break;
                    case 2:
                        MenuCollection2();
                        break;
                }
            } while (answer != 3);
        }
    }
}
