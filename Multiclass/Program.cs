namespace assignment8ex1
{
    class Program
    {
        public delegate void MyDelegate();

        public class HereComesTheSun
        {
            public static void chorus()
            {
                Console.Write("Here comes the sun, doo-doo-doo-doo\r\n");
                Console.WriteLine("Here comes the sun, and I say\r\nIt's alright");
                Console.WriteLine();
            }
            public static void chorus2()
            {
                Console.WriteLine("Here comes the sun\r\nHere comes the sun, and I say\r\nIt's alright");
                Console.WriteLine();
                Console.Write("Sun, sun, sun, here it comes\r\nSun, sun, sun, here it comes\r\n");
                Console.Write("Sun, sun, sun, here it comes\r\nSun, sun, sun, here it comes\r\n");
                Console.WriteLine("Sun, sun, sun, here it comes");
                Console.WriteLine();
            }
            public static void verse1()
            {
                Console.Write("Little darlin', it's been a long, cold, lonely winter\r\n");
                Console.WriteLine("Little darlin', it feels like years since it's been here");
                Console.WriteLine();
            }
            public static void verse2()
            {
                Console.Write("Little darlin', the smile's returning to their faces\r\n");
                Console.WriteLine("Little darlin', it seems like years since it's been here");
                Console.WriteLine();
            }
            public static void verse3()
            {
                Console.Write("Little darlin', I feel that ice is slowly melting\r\n");
                Console.WriteLine("Little darlin', it seems like years since it's been clear");
                Console.WriteLine();
            }
            public static void end()
            {
                Console.WriteLine("It's alright");
            }
        }

        static void Main(string[] args)
        {
            MyDelegate del1 = HereComesTheSun.chorus;
            MyDelegate del2 = HereComesTheSun.verse1;
            MyDelegate del3 = HereComesTheSun.verse2;
            MyDelegate del4 = HereComesTheSun.chorus2;
            MyDelegate del5 = HereComesTheSun.verse3;
            MyDelegate del6 = HereComesTheSun.end;

            MyDelegate del = del1 + del2 + del1 + del3 + del4 + del5 + del1 + del1 + del6;

            del.Invoke();

        }
    }
}