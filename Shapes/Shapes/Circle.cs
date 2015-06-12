using System;

namespace Shapes.Shapes
{
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("radius", "Radius cannot be negative!");
                }
                this.radius = value;
            }
        }

        public double CalculateArea()
        {
            double area = Math.PI*this.Radius*this.Radius;
            return area;
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2 * this.Radius * Math.PI;
            return perimeter;
        }
    }
}
