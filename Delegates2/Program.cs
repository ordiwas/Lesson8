namespace Assignment8ex2
{
    public delegate double Action(double x, double y);

    public delegate double Func(double a, double b);

    public delegate void Delegate(double a, double b);
    public class MathSolutions
    {

        public static double GetSum(double x, double y)
        {
            return x + y;
        }
        public static double GetProduct(double a, double b)
        {
            return a * b;
        }
        public static void GetSmaller(double a, double b)
        {
            if (a < b)
                Console.WriteLine($" {a} is smaller than {b}");
            else if (b < a)
                Console.WriteLine($" {b} is smaller than {a}");
            else
                Console.WriteLine($" {b} is equal to {a}");
        }
        static void Main(string[] args)
        {
            // create a class object

            Action del = MathSolutions.GetSum;
            Func del1 = MathSolutions.GetProduct;
            Delegate del2 = MathSolutions.GetSmaller;

            MathSolutions answer = new MathSolutions();
            Random r = new Random();
            double num1 = Math.Round(r.NextDouble() * 100);
            double num2 = Math.Round(r.NextDouble() * 100);
            Console.WriteLine($" {num1} + {num2} = {del(num1, num2)}");
            Console.WriteLine($" {num1} + {num2} = {del1(num1, num2)}");
            del2(num1, num2);


        }
    }
}