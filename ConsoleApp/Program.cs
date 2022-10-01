using System;

// The following program assumes that shapes entered are either triangles, squares, or rectangles.
// For triangles, it is assumed that the lowest value is the base.

namespace ProgramNamespace
{
    public interface Polygon
    {
        string polygonName { get; set; }
        int height_ { get; set; }
        int[] sides { get; set; }
        void findPerimeter();
        void findArea();
    }
    public class Shape: Polygon
    {
        private int base_ = 0;
        public int height_ { get; set; }
        private void TriangleLengths()
        {
            int smallest = int.MaxValue;

            foreach(int i in sides)
            {
                if (i < smallest) 
                { 
                    smallest = i;
                }
            }
            base_ = smallest;
        }
        private void RectangleLengths()
        {
            int smallest = int.MaxValue;
            int largest = 0;

            foreach(int i in sides)
            {
                if (i > largest)
                {
                    largest = i;
                }
                if (i < smallest)
                {
                    smallest = i;
                }
            }
            base_ = smallest;
            height_ = largest;
        }
        public string polygonName { get; set; }
        public int[] sides { get; set;}
        public void findPerimeter()
        {
            int perimeter = 0;
            for (int i = 0; i < sides.Length; i++)
            {
                perimeter += sides[i];
            }
            Console.WriteLine($"The perimeter of {polygonName} is {perimeter}");
        }
        public void findArea()
        {
            if (sides.Length == 4)
            {
                int area = base_*height_;
                Console.WriteLine($"The area of {polygonName} is {area}");
            }
            else if (sides.Length == 3)
            {
                TriangleLengths();
                int area = base_*height_/2;
                Console.WriteLine($"The area of {polygonName} is {area}");
            }
        }
        public Shape() : this("", Array.Empty<int>()) { }

        public Shape(string name, int[] lengths, int shapeHeight=0)
        {
            polygonName = name;
            sides = lengths;
            if (shapeHeight <= 0)
            {
                RectangleLengths();
            }
            else
            {
                height_ = shapeHeight;
            }
        }
    };
    class ShapeCollection<Shape>
    {
        private Shape[] arr = new Shape[10];
        public Shape[] shapes { get {return arr; }}
        public Shape this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }

    class Program
    {
        static void Main()
        {
            var shapesCollection = new ShapeCollection<Shape>();
            var shape0 = new Shape("Shape A", new int[] {10, 10, 10, 10});
            var shape1 = new Shape("Shape B", new int[] { 20, 40, 40, 20 });
            var shape2 = new Shape("Shape C", new int[] { 30, 40, 50 }, 40);

            shapesCollection[0] = shape0;
            shapesCollection[1] = shape1;
            shapesCollection[2] = shape2;

            foreach(var figure in shapesCollection.shapes)
            {
                if (figure != null)
                {
                    Console.WriteLine($"{figure.polygonName}:");
                    figure.findPerimeter();
                    figure.findArea();
                }
            }
            Console.ReadKey();
        }
    };
}

