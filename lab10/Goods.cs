using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public abstract class Goods:IComparable
    {
        protected static Random rnd = new Random();
        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Цена не может быть отрицательной");
                }
                else
                {
                    price = value;
                }
            }
        }
        public string Name { get; set; }
        public string Department { get; set; }
        public Goods(string name, string department, double price)
        {
            Name = name;
            Department = department;
            Price = price;
        }
        public Goods(bool randomized)
        {
        }
        public virtual void Show()
        {
            Console.WriteLine($"name = {Name}\ndepartment = {Department}\nprice = {Price}");
        }

        public abstract double FindWeight();

        public int CompareTo(object obj)
        {
            if ((obj as Goods).Price > Price)
            {
                return -1;
            }
            else if ((obj as Goods).Price == Price)
            {
                return 0;
            }
            else return 1;
        }
    }
}
