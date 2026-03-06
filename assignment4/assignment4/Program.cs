namespace assignment4
{
    internal class Program
    {
        public struct point
        {
            public double x{get; set;}
            public double y{get; set;}
            
            public point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        static double distance(point p1, point p2)
        {
            double dx = p2.x - p1.x;
            double dy = p2.y - p1.y;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            return dist;
        }
        static void Main(string[] args)
        {
            point p1, p2;
            double x, y;
            Console.WriteLine("Enter coordinates for point 1 (x y):");

            Console.Write("x : ");

            while (!double.TryParse(Console.ReadLine(),out x))
            {
                 Console.WriteLine("Invalid input try again");
                Console.Write("x : ");
            }

            Console.Write("y : ");

            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Invalid input try again");
                Console.Write("y : ");
            }
            p1 = new point(x, y);

            Console.WriteLine("Enter coordinates for point 2 (x y):");

            Console.Write("x : ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Invalid input try again");
                Console.Write("x : ");
            }

            Console.Write("y : ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Invalid input try again");
                Console.Write("y : ");
            }
            p2 = new point(x, y);

            Console.WriteLine($"Distance between p1 and p2: {distance(p1, p2)}");
        }
    }
}
