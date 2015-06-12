namespace Shapes.Shapes
{
    public class Rectangle : BasicShape
    {
        public Rectangle(double width, double hight)
            :base(width,hight)
        {
        }

        public override double CalculateArea()
        {
            double area = this.Width * this.Height;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = (this.Height + this.Width) * 2;
            return perimeter;
        }
    }
}
