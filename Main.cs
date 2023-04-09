using System.Drawing;

namespace MatrixEffect
{
    class Program
    {
        public static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            matrix.Start();
            for (int i = 0; i<20; i++)
            {
                Console.ForegroundColor = (ConsoleColor)i;
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
    }
}