using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
            count_C++;
            Name = "Circle" + count_C;
        }

        public override double Square()
        {
            double s = Math.PI * Math.Pow(Radius, 2);
            return s;
        }

        public override double Perimeter()
        {
            double p = 2 * Math.PI * Radius;
            return p;
        }
    }
}
