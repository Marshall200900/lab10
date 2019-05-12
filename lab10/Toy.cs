using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Toy:Goods
    {
        private static string[,] namesAndDepartments = new string[1, 4] { { "машина","кукла","пистолет","конструктор"} };
        private static string[] departments = { "игрушки" };
        public double WeightofBox { get; set; }
        public double WeightofToy { get; set; }
        private int age;
        public int Age
        {
            get
            {
                return age; 
            }
            set
            {
                if (value < 0)
                    throw new Exception("Возраст не может быть меньше нуля");
                else
                    age = value;
            }
        }

        public Toy(string name, string department, int age, double price):base(name, department, price)
        {
            Age = age;
        }
        public Toy(string name, string department, int age, double price, double w1, double w2) : base(name, department, price)
        {
            Age = age;
            WeightofToy = w2;
            WeightofBox = w1;
        }
        public Toy(bool random):base(random)
        {
            int r = rnd.Next(0, departments.Length);

            Name = namesAndDepartments[r, rnd.Next(0, 2)];
            Department = departments[r];
            Price = rnd.Next(1, 1000);
            WeightofToy = rnd.Next(1, 1000);
            WeightofBox = rnd.Next(1, 1000);
        }
        public override void Show()
        {
            Console.WriteLine($"name = {Name}\ndepartment = {Department}\nage = {age}\nprice = {Price}\n");
        }

        public override double FindWeight()
        {
            return WeightofBox + WeightofToy;
        }
    }
}
