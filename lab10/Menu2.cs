using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Menu2
    {
        private static Goods BinarySearchByPrice(Stack<Goods> g, int price)
        {
            Goods[] goods = g.ToArray();
            int left = 0;
            int right = goods.Length - 1;
            int mid = (right + left) / 2;
            Array.Sort(goods);
            while (left <= right)
            {
                mid = (right + left) / 2;
                if (price < goods[mid].Price)
                {
                    right = mid - 1;

                }
                else if (price > goods[mid].Price)
                {
                    left = mid + 1;

                }
                else
                {
                    return goods[mid];
                }
            }
            return goods[mid];
        }

        public static void Search(Stack<Goods> stack)
        {
            int price = Program.IntInput("Введите цену: ", 0);
            Goods g = BinarySearchByPrice(stack, price);
            if (g.Price != price)
            {
                Console.WriteLine("Очередь не содержит товара с данной ценой");
            }
            {
                Console.WriteLine("Товар с данной ценой:");
                g.Show();
            }
        }
        public static void Sort(ref Stack<Goods> stack)
        {
            Stack<Goods> q2 = new Stack<Goods>(stack.OrderBy(z => z.Price));
            stack = q2;
            Console.WriteLine("Очередь отсортирована по цене");
        }

        public static void Copy(Stack<Goods> stack)
        {
            Stack<Goods> q2 = new Stack<Goods>(stack);
            Console.WriteLine("Копия создана");
        }
        public static void ShowOnlyMilkProducts(Stack<Goods> goods)
        {
            Console.WriteLine("\nОбъекты класса MilkProducts:");
            foreach (Goods g in goods)
            {
                if (g is MilkProduct)
                {
                    g.Show();
                }
            }
        }
        public static void ShowCheapExpensive(Stack<Goods> goods)
        {
            Console.WriteLine("\nСамая дорогая и дешевая игрушки в отделе:");
            Toy cheap = new Toy("", "", 10, int.MaxValue);
            Toy exp = new Toy("", "", 10, 0);
            foreach (Goods g in goods)
            {
                if (g is Toy)
                {
                    if (g.Price < cheap.Price)
                    {
                        cheap = g as Toy;
                    }
                    if (g.Price > exp.Price)
                    {
                        exp = g as Toy;
                    }
                }
            }

            if (cheap.Name == "")
            {
                Console.WriteLine("В коллекции нет игрушек");
            }
            else
            {
                Console.WriteLine("Самая дорогая и дешевая игрушки в коллекции");
                cheap.Show();
                exp.Show();
            }
        }
        public static void ShowDateExpiration(Stack<Goods> q)
        {

            Console.WriteLine("\nСроки годности всех товаров, которые имеют срок годности: ");
            foreach (Goods g in q)
            {
                if (g is Product)
                {
                    Console.WriteLine((g as Product).Name + "\n" + (g as Product).ExpDate + "\n");
                }
            }
        }
        static Stack<Goods> GenerateCollection(int size)
        {
            Stack<Goods> q = new Stack<Goods>(size);
            for (int i = 0; i < size; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        q.Push(new Product(true));
                        break;
                    case 1:
                        q.Push(new Toy(true));
                        break;
                    case 2:
                        q.Push(new MilkProduct(true));
                        break;

                }
            }
            return q;
        }
        public static void GenerationMenu(out Stack<Goods> stack)
        {
            Console.Write("Введите размер коллекции: ");
            int size = Program.IntInput("", 1);
            stack = GenerateCollection(size);
            Console.WriteLine("Коллекция сгенерирована");
        }

        public static void AddMenu(Stack<Goods> stack)
        {
            Console.WriteLine("Тип добавляемого элемента:\n" +
                "1. Toy\n" +
                "2. Product\n" +
                "3. MilkProduct\n" +
                "4. Назад");
            int answer = Program.IntInput("", 1, 4);
            switch (answer)
            {
                case 1:
                    stack.Push(new Toy(true));
                    break;
                case 2:
                    stack.Push(new Product(true));
                    break;
                case 3:
                    stack.Push(new MilkProduct(true));
                    break;
                case 4:
                    break;
            }
        }
        public static void DeleteMenu(Stack<Goods> stack)
        {
            if (stack.Count != 0)
            {
                stack.Pop();
                Console.WriteLine("Первый элемент удален");
            }
            else
            {
                Console.WriteLine("Очередь пуста");
            }

        }

    }
}
