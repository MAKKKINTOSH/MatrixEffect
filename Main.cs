using System.Drawing;

namespace MatrixEffect
{
    class Program
    {
        private static AutoResetEvent wait = new AutoResetEvent(true);
        public static void Main(string[] args)
        {   
            Console.WriteLine("Press any key");
            Console.ReadKey();
            Console.Clear();
            Matrix matrix = new Matrix();
            matrix.Start();
        }
    }
}