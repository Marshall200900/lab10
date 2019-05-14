using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Menu1
    {
        private static Goods BinarySearchByPrice(Queue<Goods> g, int price)
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

        public static void Search(Queue<Goods> queue)
        {
            int price = Program.IntInput("Введите цену: ", 0);
            Goods g = BinarySearchByPrice(queue, price);
            if(g.Price != price)
            {
                Console.WriteLine("Очередь не содержит товара с данной ценой");
            }
            {
                Console.WriteLine("Товар с данной ценой:");
                g.Show();
            }
        }
        public static void Sort(ref Queue<Goods> queue)
        {
            Queue<Goods> q2 = new Queue<Goods>(queue.OrderBy(z => z.Price));
            queue = q2;
            Console.WriteLine("Очередь отсортирована по цене");
        }

        public static void Copy(Queue<Goods> queue)
        {
            Queue<Goods> q2 = new Queue<Goods>(queue);
            Console.WriteLine("Копия создана");
        }
        public static void ShowOnlyMilkProducts(Queue<Goods> goods)
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
        public static void ShowCheapExpensive(Queue<Goods> goods)
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
            
            if(cheap.Name == "")
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
        public static void ShowDateExpiration(Queue<Goods> q)
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
        private static Queue<Goods> GenerateCollection(int size)
        {
            Queue<Goods> q = new Queue<Goods>(size);
            for (int i = 0; i < size; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        q.Enqueue(new Product(true));
                        break;
                    case 1:
                        q.Enqueue(new Toy(true));
                        break;
                    case 2:
                        q.Enqueue(new MilkProduct(true));
                        break;

                }
            }
            return q;
        }
        public static void GenerationMenu(out Queue<Goods> queue)
        {
            Console.Write("Введите размер коллекции: ");
            int size = Program.IntInput("", 1);
            queue = GenerateCollection(size);
            Console.WriteLine("Коллекция сгенерирована");
        }

        public static void AddMenu(Queue<Goods> queue)
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
                    queue.Enqueue(new Toy(true));
                    break;
                case 2:
                    queue.Enqueue(new Product(true));
                    break;
                case 3:
                    queue.Enqueue(new MilkProduct(true));
                    break;
                case 4:
                    break;
            }
        }
        public static void DeleteMenu(Queue<Goods> queue)
        {
            if(queue.Count != 0)
            {
                queue.Dequeue();
                Console.WriteLine("Первый элемент удален");
            }
            else
            {
                Console.WriteLine("Очередь пуста");
            }
            
        }

    }
}
