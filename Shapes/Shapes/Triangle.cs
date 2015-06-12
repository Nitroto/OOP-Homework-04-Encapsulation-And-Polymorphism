using System;

namespace Shapes.Shapes
{
    public class Triangle:BasicShape
    {
        private double thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide)
            :base(firstSide, secondSide)
        {
            this.ThirdSide = thirdSide;
        }

        public double ThirdSide
        {
            get
            {
                return this.thirdSide;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("thirdSide", "Side cannot be negative!");
                }
                this.thirdSide = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Height+this.Width+this.ThirdSide;
            return perimeter;
        }
        public override double CalculateArea()
        {   //Heron's Formula
            double s = this.CalculatePerimeter()/2.0;
            double area = Math.Sqrt(s * (s - this.Height) * (s - this.Width) * (s - this.ThirdSide));
            return area;
        }

    }
}
