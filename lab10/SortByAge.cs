using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class SortByAge : IComparer
    {
        public int Compare(object x, object y)
        {
            if ((x as Toy).Age > (y as Toy).Age)
            {
                return 1;
            }
            else if ((x as Toy).Age == (y as Toy).Age)
            {
                return 0;
            }
            else return -1;
        }
    }
}
