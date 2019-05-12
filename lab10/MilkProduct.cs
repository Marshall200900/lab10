using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class MilkProduct :Product, ISpoilable, ICloneable
    {
        public static string[,] namesAndDepartments = new string[1, 3] { { "молоко", "сыр", "кефир"} };
        public static string[] departments = { "молочный" };
        public static string[] factories = { "Кунгурский", "Нытвенский", "Пермский" };
        public string Factory { get; set; }
        public MilkProduct(string name, string department, DateTime time, string factory, double price):base(name, department, time, price)
        {
            Factory = factory;
        }
        public MilkProduct(bool random):base(random)
        {
            
            int r = rnd.Next(0, departments.Length);

            Name = namesAndDepartments[r, rnd.Next(0, 2)];
            Department = departments[r];
            ExpDate = DateTime.Now;
            Price = rnd.Next(1, 100);
            Weight = rnd.Next(1, 1000);
            Factory = factories[rnd.Next(0, factories.Length)];
        }
        public override void Show()
        {
            Console.WriteLine($"name = {Name}\ndepartment = {Department}\nexpiration date = {ExpDate}\nfactory = {Factory}\nprice = {Price}\n");
        }

        public object Clone()
        {
            return new MilkProduct(Name, Department, ExpDate, Factory, Price);
        }
        
    }
}
