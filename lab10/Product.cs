using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Product : Goods, ISpoilable, IComparable
    {
        private static string[,] namesAndDepartments = new string[2, 2] { { "карандаш", "ручка" }, { "стол", "стул" } };
        private static string[] departments = { "канцтовары", "мебель" };
        public double Weight { get; set; }
        public DateTime ExpDate { get; set; }
        public Product(string name, string department, DateTime expDate, double price):base(name, department, price)
        {
            ExpDate = expDate;
        }
        
        public Product(string name, string department, DateTime expDate, double price, double weight) : base(name, department, price)
        {
            Weight = weight;
            ExpDate = expDate;
        }
        public Product(bool random):base(random)
        {
            int r = rnd.Next(0, departments.Length);

            Name = namesAndDepartments[r, rnd.Next(0, 2)];
            Department = departments[r];
            ExpDate = DateTime.Now;
            Price = rnd.Next(1, 100);
            Weight = rnd.Next(1, 1000);
        }
        public override void Show()
        {
            Console.WriteLine($"name = {Name}\ndepartment = {Department}\nexpiration date = {ExpDate}\nprice = {Price}\n");
        }


        public void SubtractDay()
        {
            ExpDate = ExpDate.Subtract(TimeSpan.FromDays(1));
        }

        
        public override double FindWeight()
        {
            return Weight;
        }
    }
}
