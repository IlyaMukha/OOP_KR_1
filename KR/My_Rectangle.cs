using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class My_Rectangle : Figure
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public My_Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;

            count_R++;
            Name = "Rectangle" + count_R;
        }

        public override double Square()
        {
            double s = Width * Height;
            return s;
        }

        public override double Perimeter()
        {
            double p = (Width + Height) * 2;
            return p;
        }
    }
}
