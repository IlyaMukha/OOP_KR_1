using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    abstract class Figure
    {
        public string Name { get; set; }


        public static int count_C { get; set; }
        public static int count_R { get; set; }
        public static int count_T { get; set; }
        public virtual double Square()
        {
            return 0;
        }

        public virtual double Perimeter()
        {
            return 0;
        }
    }
}
