using System.Drawing;

namespace MatrixEffect
{
    class Program
    {
        private static AutoResetEvent wait = new AutoResetEvent(true);
        public static void Main(string[] args)
        {
            /*Matrix matrix = new Matrix();
            matrix.Start();*/

            Console.CursorVisible = false;
            MatrixSegment segment = new MatrixSegment();
            segment.Print(wait);

            /*for (int i = 0; i < 16; i++)
            {
                Console.ForegroundColor = (ConsoleColor)i;
                Console.WriteLine(Console.ForegroundColor + i.ToString());
            }*/
        }
    }
}