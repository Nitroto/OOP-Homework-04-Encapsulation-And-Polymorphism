using System;

namespace Shapes.Shapes
{
    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        protected BasicShape(double width, double height)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("width", "Width cannot be negative!");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("height", "Height cannot be negative!");
                }
                this.height = value;
            }
        }
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}
